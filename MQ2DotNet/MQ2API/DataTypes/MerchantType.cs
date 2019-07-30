using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a merchant
    /// </summary>
    [PublicAPI]
    [MQ2Type("merchant")]
    public class MerchantType : SpawnType
    {
        internal MerchantType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Item = new IndexedMember<ItemType, int, ItemType, string>(this, "Item");
        }

        /// <summary>
        /// Returns TRUE if merchant is open
        /// </summary>
        public bool Open => GetMember<BoolType>("Open");

        /// <summary>
        /// An item in the merchant's inventory, by name or slot number (1 based)
        /// Name is a partial match unless the string begins with = e.g. "=Water Flask"
        /// </summary>
        public IndexedMember<ItemType, int, ItemType, string> Item { get; }

        /// <summary>
        /// Number of items on the merchant
        /// </summary>
        public int? Items => GetMember<IntType>("Items");

        /// <summary>
        /// The number used to calculate the buy and sell value for an item (this is what is changed by charisma and faction). This value is capped at 1.05
        /// Markup*Item Value = Amount you buy item for
        /// Item Value*(1/Markup) = Amount you sell item for
        /// </summary>
        public float? Markup => GetMember<FloatType>("Markup");

        /// <summary>
        /// Returns TRUE if the merchant's inventory is full
        /// </summary>
        public bool Full => GetMember<BoolType>("Full");

        /// <summary>
        /// Is the items list populated yet?
        /// </summary>
        public bool ItemsReceived => GetMember<BoolType>("ItemsReceived");

        /// <summary>
        /// Currently selected item
        /// </summary>
        public ItemType SelectedItem => GetMember<ItemType>("SelectedItem");

        /// <summary>
        /// Select an item in the merchants inventory by name. Prepend with '=' for an exact match, otherwise partial is used
        /// </summary>
        /// <param name="itemName"></param>
        public void SelectItem(string itemName) => GetMember<MQ2DataType>("SelectItem", itemName);

        /// <summary>
        /// Buy the specified quantity of the currently selected item
        /// </summary>
        /// <param name="quantity"></param>
        public void Buy(int quantity) => GetMember<MQ2DataType>("Buy", quantity.ToString());

        /// <summary>
        /// Sell the specified quantity of the currently selected item
        /// </summary>
        /// <param name="quantity"></param>
        public void Sell(int quantity) => GetMember<MQ2DataType>("SellBuy", quantity.ToString());

        /// <summary>
        /// Open the merchant window for the current target if it is a merchant, otherwise the closest merchant
        /// </summary>
        public void OpenWindow() => GetMember<MQ2DataType>("OpenWindow");

        /// <summary>
        /// Close the merchant window if it is open
        /// </summary>
        public void CloseWindow() => GetMember<MQ2DataType>("CloseWindow");
    }
}