using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Utility;

namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Contains events a plugin/program/script can subscribe to
    /// </summary>
    public static class Events
    {
        static Events()
        {
            // Register this AppDomain with the process-wide invoker helper, so we actually get some events
            Singleton<GlobalEventsInvoker>.Instance.Add(new EventsInvoker());
        }

        /// <summary>
        /// Fire on a line of chat from EQ
        /// </summary>
        public static event EventHandler<string> OnChatEQ;
        internal static void InvokeOnChatEQ(string text) => OnChatEQ?.Invoke(null, text);

        /// <summary>
        /// Fired on a line of chat from MQ2
        /// </summary>
        public static event EventHandler<string> OnChatMQ2;
        internal static void InvokeOnChatMQ2(string text) => OnChatMQ2?.Invoke(null, text);

        /// <summary>
        /// Fired from a line of chat from either EQ or MQ2
        /// </summary>
        public static event EventHandler<string> OnChat;
        internal static void InvokeOnChat(string text) => OnChat?.Invoke(null, text);

        /// <summary>
        /// This is called when we receive the EQ_BEGIN_ZONE packet
        /// </summary>
        public static event EventHandler BeginZone;
        internal static void InvokeBeginZone() => BeginZone?.Invoke(null, new EventArgs());

        /// <summary>
        /// This is called when we receive the EQ_END_ZONE packet
        /// </summary>
        public static event EventHandler EndZone;
        internal static void InvokeEndZone() => EndZone?.Invoke(null, new EventArgs());

        /// <summary>
        /// Fired when a new ground item is added. Will be fired once for each ground item in the zone when entering a new zone
        /// </summary>
        public static event EventHandler<GroundType> OnAddGroundItem;
        internal static void InvokeOnAddGroundItem(GroundType item) => OnAddGroundItem?.Invoke(null, item);

        /// <summary>
        /// Fired when a ground item is removed. Will be fired once for each ground item in the zone when exiting a zone
        /// </summary>
        public static event EventHandler<GroundType> OnRemoveGroundItem;
        internal static void InvokeOnRemoveGroundItem(GroundType item) => OnRemoveGroundItem?.Invoke(null, item);

        /// <summary>
        /// Fired when a new spawn is added. Will be fired once for each spawn in the zone when entering a new zone
        /// </summary>
        public static event EventHandler<SpawnType> OnAddSpawn;
        internal static void InvokeOnAddSpawn(SpawnType spawn) => OnAddSpawn?.Invoke(null, spawn);

        /// <summary>
        /// Fired when a spawn is removed. Will be fired once for each spawn in the zone when exiting a zone
        /// </summary>
        public static event EventHandler<SpawnType> OnRemoveSpawn;
        internal static void InvokeOnRemoveSpawn(SpawnType spawn) => OnRemoveSpawn?.Invoke(null, spawn);

        /// <summary>
        /// Called once directly before shutdown of the new ui system, and also every time the game calls CDisplay::CleanGameUI()
        /// </summary>
        public static event EventHandler OnCleanUI;
        internal static void InvokeOnCleanUI() => OnCleanUI?.Invoke(null, new EventArgs());

        /// <summary>
        /// Called every frame that the "HUD" is drawn -- e.g. net status / packet loss bar
        /// </summary>
        public static event EventHandler OnDrawHUD;
        internal static void InvokeOnDrawHUD() => OnDrawHUD?.Invoke(null, new EventArgs());

        /// <summary>
        /// Called once directly after the game ui is reloaded, after issuing /loadskin
        /// </summary>
        public static event EventHandler OnReloadUI;
        internal static void InvokeOnReloadUI() => OnReloadUI?.Invoke(null, new EventArgs());

        /// <summary>
        /// Similar/same as EndZone ?
        /// </summary>
        public static event EventHandler OnZoned;
        internal static void InvokeOnZoned() => OnZoned?.Invoke(null, new EventArgs());

        /// <summary>
        /// Called once directly after initialization, and then every time the gamestate changes
        /// </summary>
        public static event EventHandler<uint> SetGameState;
        internal static void InvokeSetGameState(uint gameState) => SetGameState?.Invoke(null, gameState);

        /// <summary>
        /// Even though <see cref="Events"/> is a static class, there will still be one of it per AppDomain
        /// Through Events' static constructor, a new instance of this is created for each AppDomain, and added to a list stored in a process-wide GlobalEventsInvoker (using Singleton)
        /// The InvokeAll* helper methods, called on the singleton, will then call Invoke* on each of these instances, which in turn call Events.Invoke*
        /// A bit convoluted, it'd be vastly simpler if Events wasn't static, but I want it to be easy to use from scripts, and this is the tradeoff
        /// </summary>
        [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
        internal class EventsInvoker
        {
            internal void InvokeOnChatEQ(string text) => Events.InvokeOnChatEQ(text);
            internal void InvokeOnChatMQ2(string text) => Events.InvokeOnChatMQ2(text);
            internal void InvokeOnChat(string text) => Events.InvokeOnChat(text);
            internal void InvokeBeginZone() => Events.InvokeBeginZone();
            internal void InvokeEndZone() => Events.InvokeEndZone();
            internal void InvokeOnAddGroundItem(GroundType item) => Events.InvokeOnAddGroundItem(item);
            internal void InvokeOnRemoveGroundItem(GroundType item) => Events.InvokeOnRemoveGroundItem(item);
            internal void InvokeOnAddSpawn(SpawnType spawn) => Events.InvokeOnAddSpawn(spawn);
            internal void InvokeOnRemoveSpawn(SpawnType spawn) => Events.InvokeOnRemoveSpawn(spawn);
            internal void InvokeOnCleanUI() => Events.InvokeOnCleanUI();
            internal void InvokeOnDrawHUD() => Events.InvokeOnDrawHUD();
            internal void InvokeOnReloadUI() => Events.InvokeOnReloadUI();
            internal void InvokeOnZoned() => Events.InvokeOnZoned();
            internal void InvokeSetGameState(uint gameState) => Events.InvokeSetGameState(gameState);
        }

        internal class GlobalEventsInvoker : MarshalByRefObject
        {
            private readonly List<EventsInvoker> _invokers = new List<EventsInvoker>();

            public void Add(EventsInvoker instance)
            {
                _invokers.Add(instance);
            }

            private static void TryCatch(Action action)
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatGeneralWarning($"Exception in event handler: {e}");
                }
            }

            internal void InvokeAllOnChatEQ(string text) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnChatEQ(text)));
            internal void InvokeAllOnChatMQ2(string text) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnChatMQ2(text)));
            internal void InvokeAllOnChat(string text) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnChat(text)));
            internal void InvokeAllBeginZone() => _invokers.ForEach(i => TryCatch(i.InvokeBeginZone));
            internal void InvokeAllEndZone() => _invokers.ForEach(i => TryCatch(i.InvokeEndZone));
            internal void InvokeAllOnAddGroundItem(GroundType item) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnAddGroundItem(item)));
            internal void InvokeAllOnRemoveGroundItem(GroundType item) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnRemoveGroundItem(item)));
            internal void InvokeAllOnAddSpawn(SpawnType spawn) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnAddSpawn(spawn)));
            internal void InvokeAllOnRemoveSpawn(SpawnType spawn) => _invokers.ForEach(i => TryCatch(() => i.InvokeOnRemoveSpawn(spawn)));
            internal void InvokeAllOnCleanUI() => _invokers.ForEach(i => TryCatch(i.InvokeOnCleanUI));
            internal void InvokeAllOnDrawHUD() => _invokers.ForEach(i => TryCatch(i.InvokeOnDrawHUD));
            internal void InvokeAllOnReloadUI() => _invokers.ForEach(i => TryCatch(i.InvokeOnReloadUI));
            internal void InvokeAllOnZoned() => _invokers.ForEach(i => TryCatch(i.InvokeOnZoned));
            internal void InvokeAllSetGameState(uint gameState) => _invokers.ForEach(i => TryCatch(() => i.InvokeSetGameState(gameState)));
        }
    }
}
