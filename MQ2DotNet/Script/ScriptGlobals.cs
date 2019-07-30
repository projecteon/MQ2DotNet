using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Services;

namespace MQ2DotNet.Script
{
    /// <summary>
    /// Used to pass arguments to scripts
    /// </summary>
    [PublicAPI]
    public class ScriptGlobals
    {
        /// <summary>
        /// Arguments passed to /cs
        /// </summary>
        public IList<string> Args;

        /// <summary>
        /// Cancellation token that will be cancelled when a user does /endcs
        /// </summary>
        public CancellationToken Token;

        /// <summary>
        /// Basic MQ2 functions - execute commands, write chat, parse strings
        /// </summary>
        public MQ2 MQ2;

        /// <summary>
        /// Functions for adding/removing commands
        /// </summary>
        public Commands Commands;

        /// <summary>
        /// Contains utility methods and properties relating to ingame chat (messages in a chat window, from EQ or MQ2)
        /// </summary>
        public Chat Chat;

        /// <summary>
        /// Contains all standard top level objects
        /// </summary>
        public TLO TLO;

        /// <summary>
        /// Contains events for all standard MQ2 plugin callbacks
        /// </summary>
        public Events Events;

        /// <summary>
        /// Contains utility methods and properties relating to spawns
        /// </summary>
        public Spawns Spawns;
    }
}