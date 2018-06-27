namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AdvLootItemType
    public class AdvLootItemType : MQ2DataType
    {
        /// <summary>
        /// Memory address of the LOOTITEM struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Index of the item in either the shared or personal loot list
        /// </summary>
        public IntType xIndex => GetMember<IntType>("xIndex");

        /// <summary>
        /// Name of the item
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// ID of the item
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Maximum number of these items in one stack
        /// </summary>
        public IntType StackSize => GetMember<IntType>("StackSize");

        /// <summary>
        /// Spawn the item was dropped by
        /// </summary>
        public SpawnType Corpse => GetMember<SpawnType>("Corpse");

        /// <summary>
        /// State of the Autoroll checkbox for this item
        /// </summary>
        public BoolType AutoRoll => GetMember<BoolType>("AutoRoll");

        /// <summary>
        /// State of the Need checkbox for this item
        /// </summary>
        public BoolType Need => GetMember<BoolType>("Need");

        /// <summary>
        /// State of the Greed checkbox for this item
        /// </summary>
        public BoolType Greed => GetMember<BoolType>("Greed");

        /// <summary>
        /// State of the No checkbox for this item
        /// </summary>
        public BoolType No => GetMember<BoolType>("No");

        /// <summary>
        /// State of the AlwaysNeed checkbox for this item
        /// </summary>
        public BoolType AlwaysNeed => GetMember<BoolType>("AlwaysNeed");

        /// <summary>
        /// State of the AlwaysGreed checkbox for this item
        /// </summary>
        public BoolType AlwaysGreed => GetMember<BoolType>("AlwaysGreed");

        /// <summary>
        /// State of the Never checkbox for this item
        /// </summary>
        public BoolType Never => GetMember<BoolType>("Never");

        /// <summary>
        /// ID of the icon for this item
        /// </summary>
        public IntType IconID => GetMember<IntType>("IconID");

        /// <summary>
        /// True if the item is no drop
        /// </summary>
        public BoolType xNoDrop => GetMember<BoolType>("xNoDrop");
    }
}