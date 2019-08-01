using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Services;
using MQ2DotNet.Utility;
using Ninject;

namespace MQ2DotNet.Script
{
    internal class LoadedScriptAppDomain : LoadedAppDomainBase
    {
        private CancellationTokenSource _cts;
        private Task _task;
        private Task<object> _runTask;

        public LoadedScriptAppDomain()
        {
            // Compile & run a nothing script on the thread pool. This will force it to load all the assemblies required for compilation and make it much quicker when we run something
            Task.Run(async () => await CSharpScript.RunAsync("return true;"));
        }

        public override bool Finished => new TaskStatus?[] { TaskStatus.RanToCompletion, TaskStatus.Canceled, TaskStatus.Faulted }.Contains(_task?.Status);

        public TaskStatus Status => _task?.Status ?? TaskStatus.Created;

        public bool Active => _task?.IsCompleted == false;

        /// <summary>
        /// Loads and runs a new C# script from the specified file
        /// </summary>
        /// <param name="scriptFilePath"></param>
        /// <param name="args"></param>
        public void Start(string scriptFilePath, string[] args)
        {
            if (Active)
                throw new InvalidOperationException("A script is already running");

            _cts = new CancellationTokenSource();
            _task = EventLoopContext.SetExecuteRestore(() => CompileAndRun(scriptFilePath, args));
            Name = Path.GetFileNameWithoutExtension(scriptFilePath);
        }

        public void Cancel()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedScriptAppDomain));
            if (_cts.IsCancellationRequested)
                throw new InvalidOperationException("Program has already been cancelled");

            _cts.Cancel();

            // Give the script a chance to respond. Need to do this twice - the first one gives the script an opportunity to throw TaskCancelledException
            EventLoopContext.DoEvents(true);
            // If it does throw, a continuation to CompileAndRun will be posted. This second one will run that.
            EventLoopContext.DoEvents(true);
        }

        private async Task CompileAndRun(string scriptFilePath, string[] args)
        {
            try
            {
                var sw = new Stopwatch();
                ScriptRunner<object> scriptRunner;
                try
                {
                    MQ2.WriteChatScript($"Compiling: {scriptFilePath}");

                    sw.Start();

                    // Compile it. This takes a while, and there's no reason it needs to happen on the main thread
                    scriptRunner = await Task.Run(() =>
                    {
                        var options = ScriptOptions.Default
                            .WithFilePath(scriptFilePath)
                            .WithFileEncoding(Encoding.UTF8)
                            .WithEmitDebugInformation(true)
                            // Add a reference to the MQ2DotNet assembly
                            .AddReferences(Assembly.GetExecutingAssembly())
                            // And our namespaces
                            .AddImports("MQ2DotNet.EQ",
                                "MQ2DotNet.MQ2API",
                                "MQ2DotNet.MQ2API.DataTypes")
                            // OmniSharp (vscode intellisense) adds these by default, might as well here too so things match
                            .AddImports("System",
                                "System.IO",
                                "System.Collections.Generic",
                                "System.Console",
                                "System.Diagnostics",
                                "System.Dynamic",
                                "System.Linq",
                                "System.Linq.Expressions",
                                "System.Text",
                                "System.Threading.Tasks");

                        return CSharpScript.Create(File.ReadAllText(scriptFilePath), options, typeof(ScriptGlobals))
                            .CreateDelegate();
                    }, _cts.Token);

                    sw.Stop();
                }
                catch (CompilationErrorException compileException)
                {
                    foreach (var error in compileException.Diagnostics.Where(d =>
                        d.Severity == Microsoft.CodeAnalysis.DiagnosticSeverity.Error))
                        MQ2.WriteChatScriptError($"Compilation error {error}");
                    throw;
                }
                catch (Exception e)
                {
                    MQ2.WriteChatScriptError($"Error compiling script {Name}: {e}");
                    throw;
                }

                MQ2.WriteChatScript($"Compilation completed in {sw.Elapsed.TotalSeconds:0.##}s, running script: {Name}");

                try
                {
                    // Run it
                    using (var kernel = GetInjectionKernel())
                    {
                        _runTask = scriptRunner(new ScriptGlobals
                        {
                            Args = args,
                            Token = _cts.Token,
                            MQ2 = kernel.Get<MQ2>(),
                            Chat = kernel.Get<Chat>(),
                            Commands = kernel.Get<Commands>(),
                            Events = kernel.Get<Events>(),
                            Spawns = kernel.Get<Spawns>(),
                            TLO = kernel.Get<TLO>()
                        }, _cts.Token);

                        await _runTask;
                    }

                    MQ2.WriteChatScript($"{Name} finished");
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    MQ2.WriteChatScriptError($"Exception in \ag{Name}\ax at line \ag{(new StackTrace(e, true)).GetFrame(0).GetFileLineNumber()}\ax: {e}");
                }
            }
            finally
            {
                Name = "";
            }
        }

        #region IDisposable
        private bool _disposed;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}