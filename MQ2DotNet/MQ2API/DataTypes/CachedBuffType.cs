// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CachedBuffType : MQ2DataType
    {
        internal CachedBuffType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Memory address of the SPELLBUFF struct
        /// </summary>
        public string CasterName => GetMember<StringType>("CasterName");
        
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