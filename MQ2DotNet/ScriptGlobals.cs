using System.Collections.Generic;
using System.Threading;

namespace MQ2DotNet
{
    /// <summary>
    /// Used to pass arguments to scripts
    /// </summary>
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
    }
}