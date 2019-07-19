using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MQ2DotNet.MQ2API;

namespace MQ2DotNet
{
    internal class PluginLoader : Plugin, IDisposable
    {
        private LoaderProxy _loaderProxy;
        private AppDomain _appDomain;

        /// <summary>
        /// Loads a new .NET plugin from the specified assembly file, in a new app domain
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="appDomainName"></param>
        public PluginLoader(string assemblyName, string appDomainName)
        {
            // First look for it in its own folder
            var applicationBase = MQ2.INIPath + "\\DotNet\\Plugins\\" + assemblyName + "\\";
            if (!File.Exists(applicationBase + assemblyName + ".dll"))
            {
                // Then in the plugins folder
                applicationBase = MQ2.INIPath + "\\DotNet\\Plugins\\";
                if (!File.Exists(applicationBase + assemblyName + ".dll"))
                    throw new FileNotFoundException($"Couldn't find plugin: {assemblyName}");
            }

            // Configure & create a new app domain
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = applicationBase
            };
            _appDomain = AppDomain.CreateDomain(appDomainName, null, appDomainSetup);

            // The default (current) appdomain will have the EQ folder as the base directory, so will fail to resolve this assembly as it's in the MQ2 directory
            // This custom resolver fixes that by searching in the directory the assembly is actually in
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            // If anything goes wrong from here on out, unload the app domain before rethrowing
            try
            {
                // Create an instance of LoaderProxy in the new app domain
                var proxy = (LoaderProxy) _appDomain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(LoaderProxy)).FullName, typeof(LoaderProxy).FullName);

                // Get the LoaderProxy to load the new assembly
                proxy.LoadAndCreatePlugin(assemblyName);

                // Now _loaderProxy proxies all calls over to the newly loaded dll in the new app domain!
                _loaderProxy = proxy;

                // Start by calling InitializePlugin
                _loaderProxy.InitializePlugin();
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
            _loaderProxy.ShutdownPlugin();
            _loaderProxy = null;
            AppDomain.Unload(_appDomain);
            _appDomain = null;
        }

        private class LoaderProxy : Plugin
        {
            private Plugin _plugin;

            public void LoadAndCreatePlugin(string assemblyName)
            {
                // Load the assembly, and find the first/only class that inherits IPlugin
                var assembly = Assembly.Load(assemblyName);

                var pluginClass = assembly.GetExportedTypes().Single(t => t.IsSubclassOf(typeof(Plugin)) && !t.IsAbstract);

                _plugin = (Plugin)Activator.CreateInstance(pluginClass);
            }

            #region Plugin methods, delegated to the subclass of Plugin in the loaded assembly
            // All methods are invoked within our sync context
            public override void OnZoned() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnZoned());
            public override void OnCleanUI() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnCleanUI());
            public override void OnReloadUI() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnReloadUI());
            public override void OnDrawHUD() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnDrawHUD());
            public override void SetGameState(uint GameState) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.SetGameState(GameState));
            public override uint OnWriteChatColor(string Line, uint Color, uint Filter) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnWriteChatColor(Line, Color, Filter));
            public override uint OnIncomingChat(string Line, uint Color) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnIncomingChat(Line, Color));
            public override void OnAddSpawn(IntPtr pNewSpawn) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnAddSpawn(pNewSpawn));
            public override void OnRemoveSpawn(IntPtr pSpawn) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnRemoveSpawn(pSpawn));
            public override void OnAddGroundItem(IntPtr pNewGroundItem) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnAddGroundItem(pNewGroundItem));
            public override void OnRemoveGroundItem(IntPtr pGroundItem) => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.OnRemoveGroundItem(pGroundItem));
            public override void BeginZone() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.BeginZone());
            public override void EndZone() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.EndZone());
            public override void Zoned() => EventLoopContext.Instance.SetExecuteRestore(() => _plugin.Zoned());

            public override void InitializePlugin() => EventLoopContext.Instance.SetExecuteRestore(() =>
            {
                MQ2TypeFactory.RegisterBuiltInTypes();
                _plugin.InitializePlugin();
            });

            public override void ShutdownPlugin() => EventLoopContext.Instance.SetExecuteRestore(() =>
            {
                _plugin.ShutdownPlugin();

                // Cleanup anything left over
                var removedCommandCount = Commands.RemoveAllCommands();
                var removedContinuationCount = EventLoopContext.Instance.RemoveAll();

                if (removedContinuationCount > 0)
                    MQ2.WriteChatPluginWarning($"Removed {removedContinuationCount} continuations from queue");
            });

            public override void OnPulse()
            {
                EventLoopContext.Instance.SetExecuteRestore(() =>
                {
                    // In addition to the loaded plugin's OnPulse method, we also need to invoke any continuations that have been posted
                    EventLoopContext.Instance.DoEvents();
                    _plugin.OnPulse();
                });
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

        #region Plugin methods, delegated to LoaderProxy in the loaded DLL
        public override void InitializePlugin() => _loaderProxy.InitializePlugin();
        public override void ShutdownPlugin() => _loaderProxy.ShutdownPlugin();
        public override void OnZoned() => _loaderProxy.OnZoned();
        public override void OnCleanUI() => _loaderProxy.OnCleanUI();
        public override void OnReloadUI() => _loaderProxy.OnReloadUI();
        public override void OnDrawHUD() => _loaderProxy.OnDrawHUD();
        public override void SetGameState(uint GameState) => _loaderProxy.SetGameState(GameState);
        public override void OnPulse() => _loaderProxy.OnPulse();
        public override uint OnWriteChatColor(string Line, uint Color, uint Filter) => _loaderProxy.OnWriteChatColor(Line, Color, Filter);
        public override uint OnIncomingChat(string Line, uint Color) => _loaderProxy.OnIncomingChat(Line, Color);
        public override void OnAddSpawn(IntPtr pNewSpawn) => _loaderProxy.OnAddSpawn(pNewSpawn);
        public override void OnRemoveSpawn(IntPtr pSpawn) => _loaderProxy.OnRemoveSpawn(pSpawn);
        public override void OnAddGroundItem(IntPtr pNewGroundItem) => _loaderProxy.OnAddGroundItem(pNewGroundItem);
        public override void OnRemoveGroundItem(IntPtr pGroundItem) => _loaderProxy.OnRemoveGroundItem(pGroundItem);
        public override void BeginZone() => _loaderProxy.BeginZone();
        public override void EndZone() => _loaderProxy.EndZone();
        public override void Zoned() => _loaderProxy.Zoned();
        #endregion
    }
}