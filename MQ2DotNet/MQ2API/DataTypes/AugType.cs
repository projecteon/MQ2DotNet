using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an augmentation slot on an item
    /// </summary>
    [PublicAPI]
    [MQ2Type("augtype")]
    public class AugType : MQ2DataType
    {
        internal AugType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Slot number of the augment on the item
        /// </summary>
        public int? Slot => GetMember<IntType>("Slot");

        /// <summary>
        /// Type of the augmentation
        /// </summary>
        public int? Type => GetMember<IntType>("Type");

        /// <summary>
        /// TODO: What does AugType.Visible mean?
        /// </summary>
        public bool Visible => GetMember<BoolType>("Visible");

        /// <summary>
        /// TODO: What does AugType.Infusable mean?
        /// </summary>
        public bool Infusable => GetMember<BoolType>("Infusable");

        /// <summary>
        /// True if the slot is empty
        /// </summary>
        public bool Empty => GetMember<BoolType>("Empty");

        /// <summary>
        /// Name of the augmentation in the slot
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Item in the augmentation slot
        /// </summary>
        public ItemType Item => GetMember<ItemType>("Item");

        /// <summary>
        /// Solvent required to remove the augmentation
        /// </summary>
        public SolventType Solvent => GetMember<SolventType>("Solvent");
    }
}