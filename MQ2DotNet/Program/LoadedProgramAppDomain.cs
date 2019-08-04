using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;
using Ninject;

namespace MQ2DotNet.Program
{
    internal class LoadedProgramAppDomain : LoadedAppDomainBase
    {
        private readonly IProgram _program;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private Task _task;

        public LoadedProgramAppDomain(string assemblyFilePath)
        {
            Name = Path.GetFileNameWithoutExtension(assemblyFilePath);

            // See LoadedPluginAppDomain for why we're stuck with doing all this in the constructor

            // Load the assembly, and find the first/only class that inherits IProgram
            var assembly = Assembly.LoadFile(assemblyFilePath);
            
            var pluginClass = assembly.GetExportedTypes().Single(t => t.GetInterfaces().Contains(typeof(IProgram)) && !t.IsAbstract);

            // Create an instance of the class, using Ninject to resolve any constructor dependencies
            using (var kernel = GetInjectionKernel())
            {
                kernel.Bind<IProgram>().To(pluginClass);
                _program = kernel.Get<IProgram>();
            }
        }

        public override bool Finished => new TaskStatus?[] { TaskStatus.RanToCompletion, TaskStatus.Canceled, TaskStatus.Faulted }.Contains(_task?.Status);

        protected override void AfterPulse()
        {
            // If it's faulted, show some details
            if (_task.IsFaulted)
            {
                Debug.Assert(_task.Exception != null);
                var stackFrame = (new StackTrace(_task.Exception, true)).GetFrame(0);
                if (stackFrame != null)
                {
                    var file = stackFrame.GetFileName();
                    var line = stackFrame.GetFileLineNumber();
                    MQ2.WriteChatProgramError($"Exception in \ag{Name}\ax at \ag{file}:{line}\ax: {Exception}");
                }
                else
                    MQ2.WriteChatProgramError($"Exception in \ag{Name}\ax: {Exception}");
            }
        }

        public Exception Exception => _task.Exception?.InnerException;

        public TaskStatus Status => _task?.Status ?? TaskStatus.Created;

        public void Start(string[] args)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedProgramAppDomain));
            if (_task != null)
                throw new InvalidOperationException("Program has already been started");
            
            EventLoopContext.SetExecuteRestore(() =>
            {
                _task = _program.Main(_cts.Token, args);
            });
        }

        public void Cancel()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedProgramAppDomain));
            if (_cts.IsCancellationRequested)
                throw new InvalidOperationException("Program has already been cancelled");
            
            _cts.Cancel();
            
            // Give the program a chance to respond to the cancellation
            EventLoopContext.DoEvents(true);
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