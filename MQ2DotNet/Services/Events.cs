using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.Services
{
    /// <summary>
    /// Contains events a plugin/program/script can subscribe to
    /// </summary>
    [PublicAPI]
    public sealed class Events : IDisposable
    {
        private readonly LoadedAppDomainBase _appDomainBase;
        private bool _disposed;

        internal Events(LoadedAppDomainBase appDomainBase)
        {
            _appDomainBase = appDomainBase;
            SubscribeAll();
            // Events on AppDomainBase are WeakEvents, so won't keep this class alive
        }

        /// <inheritdoc />
        ~Events()
        {
            // I don't think this is strictly necessary as they are weak events...
            UnsubscribeAll();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            UnsubscribeAll();
            _disposed = true;
        }

        /// <summary>
        /// Fired on a line of chat from EQ
        /// </summary>
        public event EventHandler<string> OnChatEQ
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChatEQ += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChatEQ -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<string> _onChatEQ;

        /// <summary>
        /// Fired on a line of chat from MQ2
        /// </summary>
        public event EventHandler<string> OnChatMQ2
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChatMQ2 += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChatMQ2 -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<string> _onChatMQ2;

        /// <summary>
        /// Fired from a line of chat from either EQ or MQ2
        /// </summary>
        public event EventHandler<string> OnChat
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChat += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onChat -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<string> _onChat;

        /// <summary>
        /// This is called when we receive the EQ_BEGIN_ZONE packet
        /// </summary>
        public event EventHandler BeginZone
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _beginZone += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _beginZone -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _beginZone;

        /// <summary>
        /// This is called when we receive the EQ_END_ZONE packet
        /// </summary>
        public event EventHandler EndZone
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _endZone += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _endZone -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _endZone;

        /// <summary>
        /// Fired when a new ground item is added. Will be fired once for each ground item in the zone when entering a new zone
        /// </summary>
        public event EventHandler<GroundType> OnAddGroundItem
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onAddGroundItem += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onAddGroundItem -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<GroundType> _onAddGroundItem;

        /// <summary>
        /// Fired when a ground item is removed. Will be fired once for each ground item in the zone when exiting a zone
        /// </summary>
        public event EventHandler<GroundType> OnRemoveGroundItem
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onRemoveGroundItem += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onRemoveGroundItem -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<GroundType> _onRemoveGroundItem;

        /// <summary>
        /// Fired when a new spawn is added. Will be fired once for each spawn in the zone when entering a new zone
        /// </summary>
        public event EventHandler<SpawnType> OnAddSpawn
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onAddSpawn += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onAddSpawn -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<SpawnType> _onAddSpawn;

        /// <summary>
        /// Fired when a spawn is removed. Will be fired once for each spawn in the zone when exiting a zone
        /// </summary>
        public event EventHandler<SpawnType> OnRemoveSpawn
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onRemoveSpawn += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onRemoveSpawn -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<SpawnType> _onRemoveSpawn;

        /// <summary>
        /// Called once directly before shutdown of the new ui system, and also every time the game calls CDisplay::CleanGameUI()
        /// </summary>
        public event EventHandler OnCleanUI
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onCleanUI += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onCleanUI -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _onCleanUI;

        /// <summary>
        /// Called every frame that the "HUD" is drawn -- e.g. net status / packet loss bar
        /// </summary>
        public event EventHandler OnDrawHUD
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onDrawHUD += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onDrawHUD -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _onDrawHUD;

        /// <summary>
        /// Called once directly after the game ui is reloaded, after issuing /loadskin
        /// </summary>
        public event EventHandler OnReloadUI
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onReloadUI += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onReloadUI -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _onReloadUI;

        /// <summary>
        /// Similar/same as EndZone ?
        /// </summary>
        public event EventHandler OnZoned
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onZoned += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _onZoned -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler _onZoned;

        /// <summary>
        /// Called once directly after initialization, and then every time the gamestate changes
        /// </summary>
        public event EventHandler<GameState> SetGameState
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _setGameState += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(nameof(Events));
                _setGameState -= value;
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")] private event EventHandler<GameState> _setGameState;

        private void SubscribeAll()
        {
            _appDomainBase.BeginZone.Subscribe(_appDomainBase_BeginZone);
            _appDomainBase.EndZone.Subscribe(_appDomainBase_EndZone);
            _appDomainBase.OnAddGroundItem.Subscribe(_appDomainBase_OnAddGroundItem);
            _appDomainBase.OnAddSpawn.Subscribe(_appDomainBase_OnAddSpawn);
            _appDomainBase.OnChat.Subscribe(_appDomainBase_OnChat);
            _appDomainBase.OnChatEQ.Subscribe(_appDomainBase_OnChatEQ);
            _appDomainBase.OnChatMQ2.Subscribe(_appDomainBase_OnChatMQ2);
            _appDomainBase.OnCleanUI.Subscribe(_appDomainBase_OnCleanUI);
            _appDomainBase.OnDrawHUD.Subscribe(_appDomainBase_OnDrawHUD);
            _appDomainBase.OnReloadUI.Subscribe(_appDomainBase_OnReloadUI);
            _appDomainBase.OnRemoveGroundItem.Subscribe(_appDomainBase_OnRemoveGroundItem);
            _appDomainBase.OnRemoveSpawn.Subscribe(_appDomainBase_OnRemoveSpawn);
            _appDomainBase.OnZoned.Subscribe(_appDomainBase_OnZoned);
            _appDomainBase.SetGameState.Subscribe(_appDomainBase_SetGameState);
        }

        private void UnsubscribeAll()
        {
            _appDomainBase.BeginZone.Unsubscribe(_appDomainBase_BeginZone);
            _appDomainBase.EndZone.Unsubscribe(_appDomainBase_EndZone);
            _appDomainBase.OnAddGroundItem.Unsubscribe(_appDomainBase_OnAddGroundItem);
            _appDomainBase.OnAddSpawn.Unsubscribe(_appDomainBase_OnAddSpawn);
            _appDomainBase.OnChat.Unsubscribe(_appDomainBase_OnChat);
            _appDomainBase.OnChatEQ.Unsubscribe(_appDomainBase_OnChatEQ);
            _appDomainBase.OnChatMQ2.Unsubscribe(_appDomainBase_OnChatMQ2);
            _appDomainBase.OnCleanUI.Unsubscribe(_appDomainBase_OnCleanUI);
            _appDomainBase.OnDrawHUD.Unsubscribe(_appDomainBase_OnDrawHUD);
            _appDomainBase.OnReloadUI.Unsubscribe(_appDomainBase_OnReloadUI);
            _appDomainBase.OnRemoveGroundItem.Unsubscribe(_appDomainBase_OnRemoveGroundItem);
            _appDomainBase.OnRemoveSpawn.Unsubscribe(_appDomainBase_OnRemoveSpawn);
            _appDomainBase.OnZoned.Unsubscribe(_appDomainBase_OnZoned);
            _appDomainBase.SetGameState.Unsubscribe(_appDomainBase_SetGameState);
        }

        private void _appDomainBase_BeginZone(object sender, EventArgs e)
        {
            _beginZone?.Invoke(this, e);
        }

        private void _appDomainBase_EndZone(object sender, EventArgs e)
        {
            _endZone?.Invoke(this, e);
        }

        private void _appDomainBase_OnAddGroundItem(object sender, GroundType e)
        {
            _onAddGroundItem?.Invoke(this, e);
        }

        private void _appDomainBase_OnAddSpawn(object sender, SpawnType e)
        {
            _onAddSpawn?.Invoke(this, e);
        }

        private void _appDomainBase_OnChat(object sender, string e)
        {
            _onChat?.Invoke(this, e);
        }

        private void _appDomainBase_OnChatEQ(object sender, string e)
        {
            _onChatEQ?.Invoke(this, e);
        }

        private void _appDomainBase_OnChatMQ2(object sender, string e)
        {
            _onChatMQ2?.Invoke(this, e);
        }

        private void _appDomainBase_OnCleanUI(object sender, EventArgs e)
        {
            _onCleanUI?.Invoke(this, e);
        }

        private void _appDomainBase_OnDrawHUD(object sender, EventArgs e)
        {
            _onDrawHUD?.Invoke(this, e);
        }

        private void _appDomainBase_OnReloadUI(object sender, EventArgs e)
        {
            _onReloadUI?.Invoke(this, e);
        }

        private void _appDomainBase_OnRemoveGroundItem(object sender, GroundType e)
        {
            _onRemoveGroundItem?.Invoke(this, e);
        }

        private void _appDomainBase_OnRemoveSpawn(object sender, SpawnType e)
        {
            _onRemoveSpawn?.Invoke(this, e);
        }

        private void _appDomainBase_OnZoned(object sender, EventArgs e)
        {
            _onZoned?.Invoke(this, e);
        }

        private void _appDomainBase_SetGameState(object sender, GameState e)
        {
            _setGameState?.Invoke(this, e);
        }
    }
}
