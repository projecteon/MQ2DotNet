namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MerchantType : SpawnType
    {
        public MerchantType()
        {
            Item = new IndexedMember<ItemType>(this, "Item");
        }

        public BoolType Open => GetMember<BoolType>("Open");
        public IndexedMember<ItemType> Item { get; }
        public IntType Items => GetMember<IntType>("Items");
        public FloatType Markup => GetMember<FloatType>("Markup");
        public BoolType Full => GetMember<BoolType>("Full");
    }
}