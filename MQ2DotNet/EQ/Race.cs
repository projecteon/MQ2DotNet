using System;
using JetBrains.Annotations;

namespace MQ2DotNet.EQ
{
    /// <summary>
    /// In game race
    /// TODO: Add other races
    /// </summary>
    [PublicAPI]
    [Flags]
    public enum Race
    {
#pragma warning disable 1591
        Human = 1
#pragma warning restore 1591
    }
}