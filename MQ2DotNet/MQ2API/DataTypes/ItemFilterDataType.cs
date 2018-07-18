// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ItemFilterDataType : MQ2DataType
    {
        internal ItemFilterDataType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// ID of the item
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Auto roll enabled?
        /// </summary>
        public BoolType AutoRoll => GetMember<BoolType>("AutoRoll");

        /// <summary>
        /// Always need?
        /// </summary>
        public BoolType Need => GetMember<BoolType>("Need");

        /// <summary>
        /// Always greed?
        /// </summary>
        public BoolType Greed => GetMember<BoolType>("Greed");

        /// <summary>
        /// Never?
        /// </summary>
        public BoolType Never => GetMember<BoolType>("Never");

        /// <summary>
        /// Item's icon ID
        /// </summary>
        public IntType IconID => GetMember<IntType>("IconID");

        /// <summary>
        /// Bitmask of settings, 1 = AutoRoll, 2 = Need, 4 = Greed, 8 = Never
        /// </summary>
        public IntType Types => GetMember<IntType>("Types");
    }
}