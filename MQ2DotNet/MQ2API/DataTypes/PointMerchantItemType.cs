// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PointMerchantItemType : MQ2DataType
    {
        internal PointMerchantItemType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Item ID
        /// </summary>
        public int ItemID => GetMember<IntType>("ItemID");

        /// <summary>
        /// Item cost
        /// </summary>
        public long Price => GetMember<Int64Type>("Price");

        /// <summary>
        /// Theme ID TODO: What is PointMerchantItemType.ThemeID? (ITEMINFO::LDTheme)
        /// </summary>
        public int ThemeID => GetMember<IntType>("ThemeID");

        /// <summary>
        /// Is the item stackable?
        /// </summary>
        public bool IsStackable => GetMember<BoolType>("IsStackable");

        /// <summary>
        /// Is the item lore?
        /// </summary>
        public bool IsLore => GetMember<BoolType>("IsLore");

        public int RaceMask => GetMember<IntType>("RaceMask");

        /// <summary>
        /// Classes that can use the item
        /// </summary>
        public Class ClassMask => GetMember<IntType>("ClassMask"); 

        /// <summary>
        /// Can I use it?
        /// </summary>
        public bool CanUse => GetMember<BoolType>("CanUse");
    }
}