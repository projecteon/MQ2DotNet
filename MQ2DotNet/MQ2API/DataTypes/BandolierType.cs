using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a bandolier item set
    /// </summary>
    [PublicAPI]
    [MQ2Type("bandolier")]
    public class BandolierType : MQ2DataType
    {
        internal BandolierType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Item = new IndexedMember<BandolierItemType, int>(this, "Item");
        }

        /// <summary>
        /// Is the set active, i.e. worn?
        /// </summary>
        public bool? Active => GetMember<BoolType>("Active");

        /// <summary>
        /// 1 based index of the set in the window
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Item in the set by index (1 - 4)
        /// </summary>
        public IndexedMember<BandolierItemType, int> Item { get; }

        /// <summary>
        /// Name of the set
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Activate (equip) the set
        /// </summary>
        public void Activate() => GetMember<MQ2DataType>("Activate");
    }
}