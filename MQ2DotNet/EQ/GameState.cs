using JetBrains.Annotations;

namespace MQ2DotNet.EQ
{
    /// <summary>
    /// State of the game, e.g. char select, in game
    /// </summary>
    [PublicAPI]
    public enum GameState : uint
    {
#pragma warning disable 1591
        CharSelect = 1,
        CharCreate = 2,
        Something = 4,
        InGame = 5,
        PreCharSelect = uint.MaxValue,
        PostFrontLoad = 500,
        LoggingIn = 253,
        Unloading = 255,
        Unknown = 65535
#pragma warning restore 1591
    }
}
