// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MercenaryType : SpawnType
    {
        internal MercenaryType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Number of unspent mercenary AA points
        /// </summary>
        public IntType AAPoints => GetMember<IntType>("AAPoints");

        /// <summary>
        /// Current stance of the mercenary e.g. Balanced
        /// </summary>
        public string Stance => GetMember<StringType>("Stance");

        /// <summary>
        /// Current state of the mercenary (returns "DEAD","SUSPENDED","ACTIVE", or "UNKNOWN")
        /// </summary>
        public new string State => GetMember<StringType>("State");

        /// <summary>
        /// Current state ID of the mercenary as a number.
        /// </summary>
        public IntType StateID => GetMember<IntType>("StateID");

        /// <summary>
        /// Index of the mercenary in your mercenary list (1 based)
        /// </summary>
        public IntType Index => GetMember<IntType>("Index");
    }
}