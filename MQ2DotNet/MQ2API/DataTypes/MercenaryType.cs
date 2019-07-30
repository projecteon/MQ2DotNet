using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a mercenary
    /// </summary>
    [PublicAPI]
    [MQ2Type("mercenary")]
    public class MercenaryType : SpawnType
    {
        internal MercenaryType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Number of unspent mercenary AA points
        /// </summary>
        public int? AAPoints => GetMember<IntType>("AAPoints");

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
        public int? StateID => GetMember<IntType>("StateID");

        /// <summary>
        /// Index of the mercenary in your mercenary list (1 based)
        /// </summary>
        public int? Index => GetMember<IntType>("Index");
    }
}