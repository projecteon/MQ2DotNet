// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PointMerchantItemType : MQ2DataType
    {
        /// <summary>
        /// Item name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Item ID
        /// </summary>
        public IntType ItemID => GetMember<IntType>("ItemID");

        /// <summary>
        /// Item cost
        /// </summary>
        public Int64Type Price => GetMember<Int64Type>("Price");

        /// <summary>
        /// Theme ID TODO: What is PointMerchantItemType.ThemeID? (ITEMINFO::LDTheme)
        /// </summary>
        public IntType ThemeID => GetMember<IntType>("ThemeID");

        /// <summary>
        /// Is the item stackable?
        /// </summary>
        public BoolType IsStackable => GetMember<BoolType>("IsStackable");

        /// <summary>
        /// Is the item lore?
        /// </summary>
        public BoolType IsLore => GetMember<BoolType>("IsLore");

        public IntType RaceMask => GetMember<IntType>("RaceMask");

        /// <summary>
        /// Classes that can use the item
        /// </summary>
        public Class ClassMask => GetMember<IntType>("ClassMask"); 

        /// <summary>
        /// Can I use it?
        /// </summary>
        public BoolType CanUse => GetMember<BoolType>("CanUse");
    }
}