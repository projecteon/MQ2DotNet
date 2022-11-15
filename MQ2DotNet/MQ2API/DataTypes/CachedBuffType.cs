using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a cached buff (i.e. a buff that's been "remembered" after you've targeted another spawn
    /// </summary>
    [PublicAPI]
    [MQ2Type("cachedbuff")]
    public class CachedBuffType : SpellType
    {
        internal CachedBuffType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the SPELLBUFF struct
        /// </summary>
        public string CasterName => GetMember<StringType>("CasterName");

        /// <summary>
        /// Returns the amount of buffs catched, or -1 it none
        /// </summary>
        public int? Count => GetMember<IntType>("Count");

        /// <summary>
        /// The ID of the buff or shortbuff slot
        /// </summary>
        public int? Slot => GetMember<IntType>("Slot");

        /// <summary>
        /// Id of the spell
        /// </summary>
        public int? SpellID => GetMember<IntType>("SpellID");

        /// <summary>
        /// Original duration of the buff.
        /// </summary>
        public TimeStampType OriginalDuration => GetMember<TimeStampType>("OriginalDuration");

        /// <summary>
        /// The spell
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");

        /// <summary>
        /// How long it has been since this information was refreshed.
        /// </summary>
        public TimeStampType Staleness => GetMember<TimeStampType>("Staleness");
    }
}