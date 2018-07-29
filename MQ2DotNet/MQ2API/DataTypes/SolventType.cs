// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SolventType : MQ2DataType
    {
        internal SolventType(MQ2TypeVar typeVar) : base(typeVar)
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