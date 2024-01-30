using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an item on the KeyRing
    /// </summary>
    [PublicAPI]
    [MQ2Type("keyringitem")]
    public class KeyRingItemType : MQ2DataType
    {
        internal KeyRingItemType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Index of the item in the list (1 based)
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Name of the item
        /// </summary>
        public ItemType Item => GetMember<ItemType>("Item");
    }
}