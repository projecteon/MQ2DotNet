using System;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Services;
using MQ2DotNet.Utility;
using Ninject;
using WeakEvent;

namespace MQ2DotNet
{
    /// <summary>
    /// An instance of this class sits in each newly loaded AppDomain, and serves as an access point into it from the DefaultDomain
    /// </summary>
    internal class LoadedAppDomainBase : MarshalByRefObject, IDisposable
    {
        private readonly MQ2TypeFactory _typeFactory = new MQ2TypeFactory();

        protected LoadedAppDomainBase()
        {
        }

        ~LoadedAppDomainBase()
        {
            Dispose(false);
        }

        public override object InitializeLifetimeService()
        {
            // Without this override, the "connection" between app domains can expire, throwing an exception when cross-domain calls are made
            return null;
        }

        /// <summary>
        /// Friendly name for the app domain
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Called each pulse, from the main thread
        /// </summary>
        public void OnPulse()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() =>
            {
                BeforePulse();
                EventLoopContext.DoEvents(false);
                AfterPulse();
            });
        }

        protected EventLoopContext EventLoopContext { get; } = new EventLoopContext();

        /// <summary>
        /// Indicates that the AppDomain has finished whatever it was doing, and can be disposed
        /// Return false here doesn't mean it can't/won't be disposed, just that it shouldn't be automatically
        /// </summary>
        public virtual bool Finished => false;

        /// <summary>
        /// Called from OnPulse, prior to any continuations on the sync context
        /// </summary>
        protected virtual void BeforePulse()
        {

        }

        /// <summary>
        /// Called from OnPulse, after any continuations on the sync context
        /// </summary>
        protected virtual void AfterPulse()
        {

        }

        protected StandardKernel GetInjectionKernel()
        {
            var kernel = new StandardKernel(new NinjectSettings {InjectNonPublic = true});
            kernel.Bind<LoadedAppDomainBase>().ToConstant(this).InTransientScope();
            //kernel.Bind<Chat>().ToSelf();
            //kernel.Bind<Commands>().ToSelf();
            //kernel.Bind<Events>().ToSelf();
            //kernel.Bind<Spawns>().ToSelf();
            //kernel.Bind<TLO>().ToSelf();
            return kernel;
        }

        #region Events
        // These events are all invoked from the corresponding MQ2 plugin API in the default AppDomain
        // All access in programs/plugins/scripts will be through an instance of the Events class, which subscribes to the ones here
        // They are weak events here so the instances of Events aren't kept alive longer than desired

        /// <summary>
        /// Fired on a line of chat from EQ
        /// </summary>
        public WeakEventSource<string> OnChatEQ = new WeakEventSource<string>();
        internal void InvokeOnChatEQ(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnChatEQ.Raise(null, text));
        }

        /// <summary>
        /// Fired on a line of chat from MQ2
        /// </summary>
        public WeakEventSource<string> OnChatMQ2 = new WeakEventSource<string>();
        internal void InvokeOnChatMQ2(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnChatMQ2.Raise(null, text));
        }

        /// <summary>
        /// Fired from a line of chat from either EQ or MQ2
        /// </summary>
        public WeakEventSource<string> OnChat = new WeakEventSource<string>();
        internal void InvokeOnChat(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnChat.Raise(null, text));
        }

        /// <summary>
        /// This is called when we receive the EQ_BEGIN_ZONE packet
        /// </summary>
        public WeakEventSource<EventArgs> BeginZone = new WeakEventSource<EventArgs>();
        internal void InvokeBeginZone()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => BeginZone.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// This is called when we receive the EQ_END_ZONE packet
        /// </summary>
        public WeakEventSource<EventArgs> EndZone = new WeakEventSource<EventArgs>();
        internal void InvokeEndZone()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => EndZone.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// Fired when a new ground item is added. Will be fired once for each ground item in the zone when entering a new zone
        /// </summary>
        public WeakEventSource<GroundType> OnAddGroundItem = new WeakEventSource<GroundType>();
        internal void InvokeOnAddGroundItem(IntPtr pItem)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            var item = new GroundType(_typeFactory, pItem);

            EventLoopContext.SetExecuteRestore(() => OnAddGroundItem.Raise(null, item));
        }

        /// <summary>
        /// Fired when a ground item is removed. Will be fired once for each ground item in the zone when exiting a zone
        /// </summary>
        public WeakEventSource<GroundType> OnRemoveGroundItem = new WeakEventSource<GroundType>();
        internal void InvokeOnRemoveGroundItem(IntPtr pItem)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            var item = new GroundType(_typeFactory, pItem);

            EventLoopContext.SetExecuteRestore(() => OnRemoveGroundItem.Raise(null, item));
        }

        /// <summary>
        /// Fired when a new spawn is added. Will be fired once for each spawn in the zone when entering a new zone
        /// </summary>
        public WeakEventSource<SpawnType> OnAddSpawn = new WeakEventSource<SpawnType>();
        internal void InvokeOnAddSpawn(IntPtr pSpawn)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            var spawn = new SpawnType(_typeFactory, pSpawn);

            EventLoopContext.SetExecuteRestore(() => OnAddSpawn.Raise(null, spawn));
        }

        /// <summary>
        /// Fired when a spawn is removed. Will be fired once for each spawn in the zone when exiting a zone
        /// </summary>
        public WeakEventSource<SpawnType> OnRemoveSpawn = new WeakEventSource<SpawnType>();
        internal void InvokeOnRemoveSpawn(IntPtr pSpawn)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            var spawn = new SpawnType(_typeFactory, pSpawn);

            EventLoopContext.SetExecuteRestore(() => OnRemoveSpawn.Raise(null, spawn));
        }

        /// <summary>
        /// Called once directly before shutdown of the new ui system, and also every time the game calls CDisplay::CleanGameUI()
        /// </summary>
        public WeakEventSource<EventArgs> OnCleanUI = new WeakEventSource<EventArgs>();
        internal void InvokeOnCleanUI()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnCleanUI.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// Called every frame that the "HUD" is drawn -- e.g. net status / packet loss bar
        /// </summary>
        public WeakEventSource<EventArgs> OnDrawHUD = new WeakEventSource<EventArgs>();
        internal void InvokeOnDrawHUD()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnDrawHUD.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// Called once directly after the game ui is reloaded, after issuing /loadskin
        /// </summary>
        public WeakEventSource<EventArgs> OnReloadUI = new WeakEventSource<EventArgs>();
        internal void InvokeOnReloadUI()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnReloadUI.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// Similar/same as EndZone ?
        /// </summary>
        public WeakEventSource<EventArgs> OnZoned = new WeakEventSource<EventArgs>();
        internal void InvokeOnZoned()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => OnZoned.Raise(null, new EventArgs()));
        }

        /// <summary>
        /// Called once directly after initialization, and then every time the gamestate changes
        /// </summary>
        public WeakEventSource<GameState> SetGameState = new WeakEventSource<GameState>();
        internal void InvokeSetGameState(GameState gameState)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LoadedAppDomainBase));

            EventLoopContext.SetExecuteRestore(() => SetGameState.Raise(null, gameState));
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
                }

                EventLoopContext.RemoveAll();

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