using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Utility;

namespace MQ2DotNet
{
    internal class ScriptRunner : MarshalByRefObject, IDisposable
    {
        private ScriptLoaderProxy _loaderProxy;
        private AppDomain _appDomain;

        public ScriptRunner(string appDomainName)
        {
            // Configure & create a new app domain
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = MQ2.INIPath
            };
            _appDomain = AppDomain.CreateDomain(appDomainName, null, appDomainSetup);

            // The default (current) appdomain will have the EQ folder as the base directory, so will fail to resolve this assembly as it's in the MQ2 directory
            // This custom resolver fixes that by searching in the directory the assembly is actually in
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            // If anything goes wrong from here on out, unload the app domain before rethrowing
            try
            {
                // Create an instance of ScriptLoaderProxy in the new app domain
                var proxy = _appDomain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(ScriptLoaderProxy)).FullName, typeof(ScriptLoaderProxy).FullName) as ScriptLoaderProxy;

                // Now _loaderProxy proxies all calls over to the new app domain!
                _loaderProxy = proxy;
            }
            catch (Exception)
            {
                AppDomain.Unload(_appDomain);
                throw;
            }
        }

        /// <summary>
        /// Loads and runs a new C# script from the specified file
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="args"></param>
        public void RunScript(string scriptName, params string[] args)
        {
            // Get the LoaderProxy to load & run it in the appdomain
            _loaderProxy.RunScript(scriptName, args);
        }

        /// <summary>
        /// Stop the currently running script. If no script is running, no action is taken
        /// </summary>
        public void Stop()
        {
            _loaderProxy.Stop();
        }

        public void OnPulse()
        {
            _loaderProxy.OnPulse();
        }

        /// <summary>
        /// Name of the current running script, or null if no script is running
        /// </summary>
        public string Name => _loaderProxy.Name;

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (!File.Exists(assemblyPath)) return null;
            return Assembly.LoadFrom(assemblyPath);
        }

        private void Unload()
        {
            _loaderProxy.Stop();
            _loaderProxy = null;
            AppDomain.Unload(_appDomain);
            _appDomain = null;
        }

        private class ScriptLoaderProxy : MarshalByRefObject
        {
            private ScriptRunner<object> _action;
            private Task _compileTask;
            private CancellationTokenSource _cts;
            private Task _runTask;
            private EventLoopContext _context;
            private string[] _args;
            private State _state = State.Idle;

            private enum State
            {
                Idle,
                Compiling,
                Running
            }
            
            public string Name { get; private set; }

            /// <summary>
            /// Loads a new C# script from the specified file
            /// </summary>
            /// <param name="scriptName"></param>
            /// <param name="args"></param>
            public void RunScript(string scriptName, params string[] args)
            {
                // If a script is already running, stop it
                Stop();

                try
                {
                    // Find the file
                    var filePath = MQ2.INIPath + "\\DotNet\\Scripts\\" + scriptName;
                    if (!filePath.EndsWith(".csx"))
                        filePath += ".csx";

                    if (!File.Exists(filePath))
                        throw new FileNotFoundException($"Couldn't find script: {scriptName}");

                    // Add a few default references & usings
                    var options = ScriptOptions.Default
                        .WithFilePath(filePath)
                        .AddReferences(Assembly.GetExecutingAssembly())
                        .AddImports("MQ2DotNet.MQ2API", "MQ2DotNet.MQ2API.DataTypes", "System.Threading.Tasks");

                    // Even though it's not actually running yet, set it as the currently running script to prevent others being run
                    Name = scriptName;

                    // Compile it. This takes a while, and there's no reason it needs to happen on the main thread
                    _args = args;
                    _compileTask = Task.Run(() =>
                    {
                        _action = CSharpScript.Create(File.ReadAllText(filePath), options, typeof(ScriptGlobals)).CreateDelegate();
                    });
                    _state = State.Compiling;
                    MQ2.WriteChatScript($"Compiling: {scriptName}");
                }
                catch (Exception e)
                {
                    MQ2.WriteChatScriptError($"Exception during load: {e}");
                }
            }

            public void Stop()
            {
                try
                {
                    switch (_state)
                    {
                        case State.Compiling:
                            _compileTask.Wait();
                            MQ2.WriteChatScript("Compilation cancelled");
                            break;

                        case State.Running:
                            _cts.Cancel();
                            MQ2.WriteChatScript($"{Name} ended, status = {_runTask.Status}");
                            break;
                    }

                    _compileTask = null;
                    _runTask = null;
                    _context = null;
                    _action = null;
                    Name = null;
                    _state = State.Idle;
                }
                catch (Exception e)
                {
                    MQ2.WriteChatScriptError($"Exception ending script: {e}");
                }
            }

            private async Task Run()
            {
                await _action(new ScriptGlobals { Args = _args, Token = _cts.Token}, _cts.Token);
            }

            public void OnPulse()
            {
                switch (_state)
                {
                    case State.Compiling:
                        if (_compileTask.Status == TaskStatus.RanToCompletion)
                        {
                            try
                            {
                                // If compilation succeeded, start the run task
                                _cts = new CancellationTokenSource();
                                // In case the script isn't well behaved with cancellation, use an entirely new context for it
                                // If the script gets ended but posts a continuation, it won't get run cause we'll no longer have a reference to the context
                                // It would be nice if this could be detected, but this will do for now
                                _context = new EventLoopContext();
                                MQ2.WriteChatScript($"Running: {Name}");
                                _context.SetExecuteRestore(() => _runTask = Run());
                                _state = State.Running;
                            }
                            catch (Exception e)
                            {
                                MQ2.WriteChatScriptError($"Exception starting script: {e}");
                                _state = State.Idle;
                            }
                        }
                        else if (_compileTask.Status == TaskStatus.Faulted)
                        {
                            // If it failed, print any errors
                            Debug.Assert(_compileTask.Exception != null);

                            if (_compileTask.Exception.InnerException is CompilationErrorException e)
                            {
                                foreach (var error in e.Diagnostics.Where(d =>
                                    d.Severity == Microsoft.CodeAnalysis.DiagnosticSeverity.Error))
                                    MQ2.WriteChatScriptError($"Compilation error {error}");
                            }
                            else
                            {
                                MQ2.WriteChatScriptError("Exception during compilation: " + _compileTask.Exception.InnerException);
                            }

                            _state = State.Idle;
                        }

                        break;

                    case State.Running:
                        // If the script has finished, clean up
                        if (_runTask.Status == TaskStatus.RanToCompletion || _runTask.Status == TaskStatus.Canceled ||
                            _runTask.Status == TaskStatus.Faulted)
                        {
                            Stop();
                        }
                        else
                            _context.SetExecuteRestore(() => _context.DoEvents());

                        break;
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool safeToFreeManagedObjects)
        {
            if (!disposedValue)
            {
                if (safeToFreeManagedObjects)
                {
                    Unload();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}