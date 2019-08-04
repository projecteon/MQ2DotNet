using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet
{
    /// <summary>
    /// An instance of this class is created in the default domain for each newly loaded AppDomain
    /// </summary>
    internal abstract class AppDomainBase : IDisposable
    {
        protected AppDomain AppDomain { get; }
        protected LoadedAppDomainBase LoadedAppDomain { get; }

        static AppDomainBase()
        {
            // The default (current) appdomain will have the EQ folder as the base directory, so will fail to resolve this assembly as it's in the MQ2 directory
            // This custom resolver fixes that by searching in the directory the assembly is actually in
            AppDomain.CurrentDomain.AssemblyResolve += ResolveCurrentAssembly;
        }

        protected AppDomainBase(AppDomain appDomain, LoadedAppDomainBase loadedAppDomain)
        {
            AppDomain = appDomain;
            LoadedAppDomain = loadedAppDomain;
        }

        ~AppDomainBase()
        {
            AppDomain.Unload(AppDomain);
        }

        public string Name => LoadedAppDomain.Name;

        public bool Finished => LoadedAppDomain.Finished;

        /// <summary>
        /// Allow's the AppDomain to resolve the currently executing assembly, e.g. to load in a new AppDomain
        /// This will need to be added to <code>AppDomain.CurrentDomain.AssemblyResolve</code> if this assembly is not in the AppDomain's base directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected static Assembly ResolveCurrentAssembly(object sender, ResolveEventArgs args)
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            return File.Exists(assemblyPath) ? Assembly.LoadFrom(assemblyPath) : null;
        }

        ///  <summary>
        ///  This function:
        ///  * Creates a new AppDomain
        ///  * Loads in it the assembly containing <typeparamref name="TLoaded"/>
        ///  * Creates an instance of <typeparamref name="TLoaded"/> in the new appdomain
        ///  * Creates and returns new instance of <typeparamref name="T"/>
        /// 
        ///  If an exception is thrown after the AppDomain is created, it is unloaded before rethrowing
        ///  </summary>
        ///  <typeparam name="T">Type to create in the current appdomain</typeparam>
        ///  <typeparam name="TLoaded">Type to create in the newly loaded appdomain</typeparam>
        ///  <param name="appDomainName"></param>
        ///  <param name="constructor">Function to create an instance of <typeparamref name="T"/> given an AppDomain and a <typeparamref name="TLoaded"/></param>
        /// <param name="args">Arguments to pass to the constructor of <typeparamref name="TLoaded"/></param>
        /// <returns></returns>
        protected static T Load<T, TLoaded>(string appDomainName, Func<AppDomain, TLoaded, T> constructor, IEnumerable<string> binPaths, params object[] args)
            where T : AppDomainBase
            where TLoaded : LoadedAppDomainBase
        {
            // Configure & create a new app domain
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = new MQ2().INIPath, // TODO: Not hardcode this
                PrivateBinPath = string.Join(";", binPaths)
            };
            var appDomain = AppDomain.CreateDomain(appDomainName, null, appDomainSetup);

            // If anything goes wrong from here on out, unload the app domain before rethrowing
            try
            {
                // Create an instance of LoadedPluginAppDomain in the new app domain
                var loaded = (TLoaded)appDomain.CreateInstanceAndUnwrap(
                                 assemblyName: Assembly.GetAssembly(typeof(TLoaded)).FullName, 
                                 typeName: typeof(TLoaded).FullName ?? throw new InvalidOperationException(), 
                                 ignoreCase: false, 
                                 bindingAttr: BindingFlags.Default, 
                                 binder: null, 
                                 args: args, 
                                 culture: null, 
                                 activationAttributes: null) 
                             ?? throw new InvalidOperationException();

                return constructor(appDomain, loaded);
            }
            catch (Exception)
            {
                AppDomain.Unload(appDomain);
                throw;
            }
        }
        
        #region Events
        // All these methods forward over to the other app domain that the plugin/program/script/etc resides in
        internal void OnPulse()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.OnPulse();
        }

        internal void InvokeOnChatEQ(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnChatEQ(text);
        }

        internal void InvokeOnChatMQ2(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnChatMQ2(text);
        }

        internal void InvokeOnChat(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnChat(text);
        }

        internal void InvokeBeginZone()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeBeginZone();
        }

        internal void InvokeEndZone()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeEndZone();
        }

        internal void InvokeOnAddGroundItem(IntPtr pItem)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnAddGroundItem(pItem);
        }

        internal void InvokeOnRemoveGroundItem(IntPtr pItem)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnRemoveGroundItem(pItem);
        }

        internal void InvokeOnAddSpawn(IntPtr pSpawn)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnAddSpawn(pSpawn);
        }

        internal void InvokeOnRemoveSpawn(IntPtr pSpawn)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnRemoveSpawn(pSpawn);
        }

        internal void InvokeOnCleanUI()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnCleanUI();
        }

        internal void InvokeOnDrawHUD()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnDrawHUD();
        }

        internal void InvokeOnReloadUI()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnReloadUI();
        }

        internal void InvokeOnZoned()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeOnZoned();
        }

        internal void InvokeSetGameState(GameState gameState)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AppDomainBase));

            LoadedAppDomain.InvokeSetGameState(gameState);
        }
        #endregion

        #region IDisposable
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    LoadedAppDomain.Dispose();
                    AppDomain.Unload(AppDomain);
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
