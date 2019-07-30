using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a member of a dynamic zone
    /// </summary>
    [PublicAPI]
    [MQ2Type("dzmember")]
    public class DZMemberType : MQ2DataType
    {
        internal DZMemberType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// The name of the member
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// The status of the member - one of the following: Unknown, Online, Offline, In Dynamic Zone, Link Dead
        /// </summary>
        public string Status => GetMember<StringType>("Status");
    }
}