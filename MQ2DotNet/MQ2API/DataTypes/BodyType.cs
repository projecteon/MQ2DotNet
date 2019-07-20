using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the body type of a spawn
    /// </summary>
    [PublicAPI]
    public class BodyType : MQ2DataType
    {
        internal BodyType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// ID of the body type, internal use only?
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Description e.g. Humanoid
        /// </summary>
        public string Name => GetMember<StringType>("Name");
    }
}