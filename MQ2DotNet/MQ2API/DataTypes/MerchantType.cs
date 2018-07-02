// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MerchantType : SpawnType
    {
        internal MerchantType(MQ2TypeVar typeVar) : base(typeVar)
        {
            Item = new IndexedMember<ItemType, int, ItemType, string>(this, "Item");
        }

        /// <summary>
        /// Returns TRUE if merchant is open
        /// </summary>
        public BoolType Open => GetMember<BoolType>("Open");

        /// <summary>
        /// An item in the merchant's inventory, by name or slot number (1 based)
        /// Name is a partial match unless the string begins with = e.g. "=Water Flask"
        /// </summary>
        public IndexedMember<ItemType, int, ItemType, string> Item { get; }

        /// <summary>
        /// Number of items on the merchant
        /// </summary>
        public IntType Items => GetMember<IntType>("Items");

        /// <summary>
        /// The number used to calculate the buy and sell value for an item (this is what is changed by charisma and faction). This value is capped at 1.05
        /// Markup*Item Value = Amount you buy item for
        /// Item Value*(1/Markup) = Amount you sell item for
        /// </summary>
        public FloatType Markup => GetMember<FloatType>("Markup");

        /// <summary>
        /// Returns TRUE if the merchant's inventory is full
        /// </summary>
        public BoolType Full => GetMember<BoolType>("Full");
    }
}