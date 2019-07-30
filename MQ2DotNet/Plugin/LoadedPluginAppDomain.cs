using System.IO;
using System.Linq;
using System.Reflection;
using Ninject;

namespace MQ2DotNet.Plugin
{
    internal class LoadedPluginAppDomain : LoadedAppDomainBase
    {
        private readonly IPlugin _plugin;

        public LoadedPluginAppDomain(string assemblyFilePath)
        {
            Name = Path.GetFileNameWithoutExtension(assemblyFilePath);

            // Would prefer that this was a static Load method, but that's difficult (impossible?) to call in another AppDomain and get the return value
            // Instead this is called using AppDomain.CreateInstanceAndUnwrap. Means there's no compile time safety for the arguments to this constructor
            // when calling AppDomainBase.Load, but it does guarantee that any instance of this class that's created is actually valid

            // Load the assembly, and find the first/only class that inherits IPlugin
            var assembly = Assembly.LoadFile(assemblyFilePath);

            var pluginClass = assembly.GetExportedTypes().Single(t => t.GetInterfaces().Contains(typeof(IPlugin)) && !t.IsAbstract);

            // Create an instance of the class, using Ninject to resolve any constructor dependencies
            using (var kernel = GetInjectionKernel())
            {
                kernel.Bind<IPlugin>().To(pluginClass);
                _plugin = kernel.Get<IPlugin>();
            }

            EventLoopContext.SetExecuteRestore(_plugin.InitializePlugin);
        }

        protected override void BeforePulse()
        {
            EventLoopContext.SetExecuteRestore(_plugin.OnPulse);
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
                
                // Even if the constructor throws, the object is still created somehow? Guessing a nuance of AppDomain.CreateInstanceAndUnwrap
                // So we need to check for null here :/
                if (_plugin != null)
                    EventLoopContext.SetExecuteRestore(_plugin.ShutdownPlugin);

                _disposed = true;
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}