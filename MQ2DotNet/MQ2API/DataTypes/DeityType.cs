using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a deity
    /// </summary>
    [PublicAPI]
    [MQ2Type("Deity")]
    public class DeityType : MQ2DataType
    {
        internal DeityType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// ID of the deity
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Name of the deity e.g. Innoruuk
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Team, one of "good", "evil", "neutral", "none"
        /// </summary>
        public string Team => GetMember<StringType>("Team");
    }
}