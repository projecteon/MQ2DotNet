// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class DeityType : MQ2DataType
    {
        internal DeityType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// ID of the deity
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Name of the deity e.g. Innoruuk
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Team, one of "good", "evil", "neutral", "none"
        /// </summary>
        public StringType Team => GetMember<StringType>("Team");
    }
}