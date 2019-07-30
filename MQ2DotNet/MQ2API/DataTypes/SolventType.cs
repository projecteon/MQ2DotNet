using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a solvent
    /// </summary>
    [PublicAPI]
    [MQ2Type("solventtype")]
    public class SolventType : MQ2DataType
    {
        internal SolventType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Item ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// <see cref="ItemType"/> for the solvent, if available
        /// </summary>
        public ItemType Item => GetMember<ItemType>("Item");

        /// <summary>
        /// How many we currently have in inventory
        /// </summary>
        public int? Count => GetMember<IntType>("Count");
    }
}