namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for PointMerchantType
    public class PointMerchantType : SpawnType
    {
        public PointMerchantType()
        {
            Item = new IndexedMember<PointMerchantItemType>(this, "Item");
        }

        public IndexedMember<PointMerchantItemType> Item { get; }
    }
}