using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an item in a bandolier set
    /// </summary>
    [PublicAPI]
    [MQ2Type("bandolieritem")]
    public class BandolierItemType : MQ2DataType
    {
        internal BandolierItemType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// 0 based index of the item in the set
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Icon ID of the item
        /// </summary>
        public int? IconID => GetMember<IntType>("IconID");

        /// <summary>
        /// Item ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name => GetMember<StringType>("Name");
    }
}