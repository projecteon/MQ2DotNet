using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the body type of a spawn
    /// </summary>
    [PublicAPI]
    [MQ2Type("body")]
    public class BodyType : MQ2DataType
    {
        internal BodyType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
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