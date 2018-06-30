namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CorpseType : SpawnType
    {
        public CorpseType()
        {
            Item = new IndexedMember<ItemType, int, ItemType, string>(this, "Item");
        }

        /// <summary>
        /// Corpse open?
        /// </summary>
        public BoolType Open => GetMember<BoolType>("Open");

        /// <summary>
        /// An item on the corpse by name or number
        /// </summary>
        public IndexedMember<ItemType, int, ItemType, string> Item;

        /// <summary>
        /// Number of items on the corpse
        /// </summary>
        public IntType Items => GetMember<IntType>("Items");
    }
}