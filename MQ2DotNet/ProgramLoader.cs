using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;

namespace MQ2DotNet
{
    internal class ProgramLoader : Program, IDisposable
    {
        private LoaderProxy _loaderProxy;
        private AppDomain _appDomain;

        /// <summary>
        /// Loads a new .NET program from the specified assembly file, in a new app domain
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="appDomainName"></param>
        public ProgramLoader(string assemblyName, string appDomainName)
        {
            // First look for it in its own folder
            var applicationBase = MQ2.INIPath + "\\DotNet\\Programs\\" + assemblyName + "\\";
            if (!File.Exists(applicationBase + assemblyName + ".dll"))
            {
                // Then in the plugins folder
                applicationBase = MQ2.INIPath + "\\DotNet\\Programs\\";
                if (!File.Exists(applicationBase + assemblyName + ".dll"))
                    throw new FileNotFoundException($"Couldn't find program: {assemblyName}");
            }

            // Configure & create a new app domain
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = MQ2.INIPath,
                PrivateBinPath = applicationBase
            };
            _appDomain = AppDomain.CreateDomain(appDomainName, null, appDomainSetup);

            // The default (current) appdomain will have the EQ folder as the base directory, so will fail to resolve this assembly as it's in the MQ2 directory
            // This custom resolver fixes that by searching in the directory the assembly is actually in
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            // If anything goes wrong from here on out, unload the app domain before rethrowing
            try
            {
                // Create an instance of LoaderProxy in the new app domain
                var proxy = _appDomain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(LoaderProxy)).FullName, typeof(LoaderProxy).FullName) as LoaderProxy;

                // Get the LoaderProxy to load the new assembly
                proxy.LoadAndCreateProgram(assemblyName);

                // Now _loaderProxy proxies all calls over to the newly loaded dll in the new app domain!
                _loaderProxy = proxy;
            }
            catch (Exception)
            {
                AppDomain.Unload(_appDomain);
                throw;
            }
        }

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

        private class LoaderProxy : Program
        {
            private MethodInfo _mainMethod;
            private Task _task;

            public void LoadAndCreateProgram(string assemblyName)
            {
                // Load the assembly, and get all exported methods
                var assembly = Assembly.Load(assemblyName);
                
                var assemblyMethods = assembly.GetExportedTypes().SelectMany(t => t.GetMethods()).Where(m => m.IsPublic);

                // Find a method called Main with the required signature
                _mainMethod = assemblyMethods.SingleOrDefault(m => m.Name == "Main"
                                                              && m.IsStatic
                                                              && m.ReturnType == typeof(Task)
                                                              && m.GetParameters().Length == 1
                                                              && m.GetParameters()[0].ParameterType == typeof(string[]));

                if (_mainMethod == null)
                    throw new MissingMethodException(
                        "Failed to find a unique method with the signature: static async Task Main(string[])");
            }

            #region Plugin methods, delegated to the subclass of Plugin in the loaded assembly
            // All methods are invoked within our sync context

            public override void Start(string[] args) => EventLoopContext.Instance.SetExecuteRestore(() =>
            {
                MQ2TypeFactory.RegisterBuiltInTypes();
                
                // This returns a task, which is never actually ran, and yet it seems to work...
                _task = (Task)_mainMethod.Invoke(null, new object[] { args });
            });

            public override void Stop() => EventLoopContext.Instance.SetExecuteRestore(() =>
            {
                // Cleanup anything left over
                var removedContinuationCount = EventLoopContext.Instance.RemoveAll();

                if (removedContinuationCount > 0)
                    MQ2.WriteChatProgramWarning($"Removed {removedContinuationCount} continuations from queue");
            });

            public override TaskStatus OnPulse()
            {
                EventLoopContext.Instance.SetExecuteRestore(() =>
                {
                    // Invoke any continuations that have been posted
                    EventLoopContext.Instance.DoEvents();
                });

                return _task.Status;
            }
            #endregion
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

        #region Program methods, delegated to LoaderProxy in the loaded DLL
        public override void Start(string[] args) => _loaderProxy.Start(args);
        public override void Stop() => _loaderProxy.Stop();
        public override TaskStatus OnPulse() => _loaderProxy.OnPulse();
        #endregion
    }
}