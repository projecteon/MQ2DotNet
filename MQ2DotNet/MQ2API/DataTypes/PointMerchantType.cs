// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PointMerchantType : SpawnType
    {
        public PointMerchantType()
        {
            Item = new IndexedMember<PointMerchantItemType, string, PointMerchantItemType, int>(this, "Item");
        }

        /// <summary>
        /// Item by name or slot number (1 based)
        /// </summary>
        public IndexedMember<PointMerchantItemType, string, PointMerchantItemType, int> Item { get; }
    }
}