using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a cached buff (i.e. a buff that's been "remembered" after you've targeted another spawn
    /// </summary>
    [PublicAPI]
    [MQ2Type("cachedbuff")]
    public class CachedBuffType : MQ2DataType
    {
        internal CachedBuffType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the SPELLBUFF struct
        /// </summary>
        public string CasterName => GetMember<StringType>("CasterName");
        
        /// <summary>
        /// TODO: What is this?
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
        /// The time remaining before the buff fades (not total duration)
        /// </summary>
        public TimeStampType Duration => GetMember<TimeStampType>("Duration");
    }
}