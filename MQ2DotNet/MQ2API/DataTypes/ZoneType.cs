// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ZoneType : MQ2DataType
    {
        internal ZoneType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Memory address of the ZONELIST struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Long name of the zone e.g. "The Plane of Knowledge"
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Short name of the zone e.g. "PoKnowledge"
        /// </summary>
        public StringType ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// Zone ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Zone flags, see ZONELIST::ZoneFlags in eqdata.h
        /// </summary>
        public IntType ZoneFlags => GetMember<IntType>("ZoneFlags");
    }
}