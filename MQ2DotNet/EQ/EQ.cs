using JetBrains.Annotations;

namespace MQ2DotNet.EQ
{
    /// <summary>
    /// Static class through which all EQ data and methods are exposed
    /// </summary>
    [PublicAPI]
    public static class EQ
    {
        /// <summary>
        /// Contains utility methods and properties relating to spawns
        /// </summary>
        public static Spawns Spawns { get; } = new Spawns();

        /// <summary>
        /// Contains utility methods and properties relating to ingame chat (messages in a chat window, from EQ or MQ2)
        /// </summary>
        public static Chat Chat { get; } = new Chat();
    }
}
