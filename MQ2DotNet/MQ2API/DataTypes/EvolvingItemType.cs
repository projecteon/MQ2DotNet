// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class EvolvingItemType : MQ2DataType
    {
        internal EvolvingItemType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Current percentage experience
        /// </summary>
        public FloatType ExpPct => GetMember<FloatType>("ExpPct");

        /// <summary>
        /// Is experience enabled?
        /// </summary>
        public BoolType ExpOn => GetMember<BoolType>("ExpOn");

        /// <summary>
        /// Current level of the item
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Maximum level of the item
        /// </summary>
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");
    }
}