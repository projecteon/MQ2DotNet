// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class AdvLootType : MQ2DataType
    {
        public AdvLootType()
        {
            PList = new IndexedMember<AdvLootItemType>(this, "PList");
            SList = new IndexedMember<AdvLootItemType>(this, "SList");
        }

        /// <summary>
        /// Number of items in the personal loot list
        /// </summary>
        public IntType PCount => GetMember<IntType>("PCount");

        /// <summary>
        /// Returns an item from the personal loot list
        /// </summary>
        public IndexedMember<AdvLootItemType> PList { get; }

        /// <summary>
        /// Number of items in the shared loot list
        /// </summary>
        public IntType SCount => GetMember<IntType>("SCount");

        /// <summary>
        /// Returns an item from shared loot list
        /// </summary>
        public IndexedMember<AdvLootItemType> SList { get; }

        /// <summary>
        /// Number of items in the personal loot list with either Need, Always Need, Greed, or Always Greed checked
        /// </summary>
        public IntType PWantCount => GetMember<IntType>("PWantCount");

        /// <summary>
        /// Number of items in the shared loot list with either Need, Always Need, Greed, or Always Greed checked
        /// </summary>
        public IntType SWantCount => GetMember<IntType>("SWantCount");

        /// <summary>
        /// True if any item is currently being looted? TODO: Confirm this
        /// </summary>
        public BoolType LootInProgress => GetMember<BoolType>("LootInProgress");

        /// <summary>
        /// Returns a filter from the advanced loot filters TODO: By what? Number in list or item ID?
        /// </summary>
        public ItemFilterDataType Filter => GetMember<ItemFilterDataType>("Filter");
    }
}