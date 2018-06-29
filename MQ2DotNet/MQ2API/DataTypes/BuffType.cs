namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for BuffType
    public class BuffType : SpellType
    {
        /// <summary>
        /// Memory address of the SPELLBUFF struct
        /// </summary>
        public new IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// The ID of the buff or shortbuff slot
        /// </summary>
        public new IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// The level of the person that cast the buff on you (not the level of the spell)
        /// </summary>
        public new IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// The spell
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");

        /// <summary>
        /// The modifier to a bard song
        /// </summary>
        public FloatType Mod => GetMember<FloatType>("Mod");

        /// <summary>
        /// The time remaining before the buff fades (not total duration)
        /// </summary>
        public new TimeStampType Duration => GetMember<TimeStampType>("Duration");

        /// <summary>
        /// The remaining damage absorption of the buff (if any)
        /// This is not entirely accurate, it will only show you to the Dar of your spell when it was initially cast, or what it was when you last zoned (whichever is more recent)
        /// </summary>
        public IntType Dar => GetMember<IntType>("Dar");

        /// <summary>
        /// Total number of counters (disease, poison, curse, corruption) added by the buff
        /// </summary>
        public IntType TotalCounters => GetMember<IntType>("TotalCounters");

        /// <summary>
        /// Total number of counters disease added by the buff
        /// </summary>
        public IntType CountersDisease => GetMember<IntType>("CountersDisease");

        /// <summary>
        /// Total number of counters poison added by the buff
        /// </summary>
        public IntType CountersPoison => GetMember<IntType>("CountersPoison");

        /// <summary>
        /// Total number of counters curse added by the buff
        /// </summary>
        public IntType CountersCurse => GetMember<IntType>("CountersCurse");

        /// <summary>
        /// Total number of counters corruption added by the buff
        /// </summary>
        public IntType CountersCorruption => GetMember<IntType>("CountersCorruption");

        /// <summary>
        /// Number of hit counts remaining on the buff
        /// </summary>
        public IntType HitCount => GetMember<IntType>("HitCount");
    }
}