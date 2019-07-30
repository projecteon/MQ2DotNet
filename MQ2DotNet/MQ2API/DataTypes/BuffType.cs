using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a buff on the local character
    /// </summary>
    [PublicAPI]
    [MQ2Type("buff")]
    public class BuffType : MQ2DataType //SpellType
    {
        // SpellType inheritance would be nice but is problematic. BuffType.VarPtr is a PSPELLBUFF, but SpellType.VarPtr requires a PSPELL
        // MQ2 system gets around this by finding the spell before calling the base class, but we don't have that luxury here.
        // Use .Spell instead
        internal BuffType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the SPELLBUFF struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// The ID of the buff or shortbuff slot
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// The level of the person that cast the buff on you (not the level of the spell)
        /// </summary>
        public int? Level => GetMember<IntType>("Level");

        /// <summary>
        /// The spell
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");

        /// <summary>
        /// The modifier to a bard song
        /// </summary>
        public float? Mod => GetMember<FloatType>("Mod");

        /// <summary>
        /// The time remaining before the buff fades (not total duration)
        /// </summary>
        public TimeStampType Duration => GetMember<TimeStampType>("Duration");

        /// <summary>
        /// The remaining damage absorption of the buff (if any)
        /// This is not entirely accurate, it will only show you to the Dar of your spell when it was initially cast, or what it was when you last zoned (whichever is more recent)
        /// </summary>
        public int? Dar => GetMember<IntType>("Dar");

        /// <summary>
        /// Total number of counters (disease, poison, curse, corruption) added by the buff
        /// </summary>
        public int? TotalCounters => GetMember<IntType>("TotalCounters");

        /// <summary>
        /// Total number of counters disease added by the buff
        /// </summary>
        public int? CountersDisease => GetMember<IntType>("CountersDisease");

        /// <summary>
        /// Total number of counters poison added by the buff
        /// </summary>
        public int? CountersPoison => GetMember<IntType>("CountersPoison");

        /// <summary>
        /// Total number of counters curse added by the buff
        /// </summary>
        public int? CountersCurse => GetMember<IntType>("CountersCurse");

        /// <summary>
        /// Total number of counters corruption added by the buff
        /// </summary>
        public int? CountersCorruption => GetMember<IntType>("CountersCorruption");

        /// <summary>
        /// Number of hit counts remaining on the buff
        /// </summary>
        public int? HitCount => GetMember<IntType>("HitCount");

        /// <summary>
        /// Remove the buff
        /// </summary>
        public void Remove() => GetMember<MQ2DataType>("Remove");
    }
}