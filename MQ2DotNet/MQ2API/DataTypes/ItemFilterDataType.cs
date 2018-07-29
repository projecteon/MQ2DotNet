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
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Auto roll enabled?
        /// </summary>
        public bool AutoRoll => GetMember<BoolType>("AutoRoll");

        /// <summary>
        /// Always need?
        /// </summary>
        public bool Need => GetMember<BoolType>("Need");

        /// <summary>
        /// Always greed?
        /// </summary>
        public bool Greed => GetMember<BoolType>("Greed");

        /// <summary>
        /// Never?
        /// </summary>
        public bool Never => GetMember<BoolType>("Never");

        /// <summary>
        /// Item's icon ID
        /// </summary>
        public int? IconID => GetMember<IntType>("IconID");

        /// <summary>
        /// Bitmask of settings, 1 = AutoRoll, 2 = Need, 4 = Greed, 8 = Never
        /// </summary>
        public int? Types => GetMember<IntType>("Types");
    }
}