namespace MQ2DotNet.MQ2API.DataTypes
{
    public class BandolierItemType : MQ2DataType
    {
        internal BandolierItemType(MQ2TypeVar typeVar) : base(typeVar)
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