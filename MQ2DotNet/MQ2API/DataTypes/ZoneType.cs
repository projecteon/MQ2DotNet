using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a zone
    /// </summary>
    [PublicAPI]
    [MQ2Type("zone")]
    public class ZoneType : MQ2DataType
    {
        internal ZoneType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the ZONELIST struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Long name of the zone e.g. "The Plane of Knowledge"
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Short name of the zone e.g. "PoKnowledge"
        /// </summary>
        public string ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// Zone ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Zone flags, see ZONELIST::ZoneFlags in eqdata.h
        /// </summary>
        public int? ZoneFlags => GetMember<IntType>("ZoneFlags");
    }
}