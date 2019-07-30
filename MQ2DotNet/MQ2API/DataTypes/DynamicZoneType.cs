using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a dynamic zone
    /// </summary>
    [PublicAPI]
    [MQ2Type("dynamiczone")]
    public class DynamicZoneType : MQ2DataType
    {
        internal DynamicZoneType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Member = new IndexedMember<DZMemberType, int, DZMemberType, string>(this, "Member");
        }

        /// <summary>
        /// The full name of the dynamic zone
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Current number of characters in the dynamic zone
        /// </summary>
        public int? Members => GetMember<IntType>("Members");

        /// <summary>
        /// Maximum number of characters that can enter this dynamic zone
        /// </summary>
        public int? MaxMembers => GetMember<IntType>("MaxMembers");

        /// <summary>
        /// Member of the dynamic zone by name or number
        /// </summary>
        public IndexedMember<DZMemberType, int, DZMemberType, string> Member { get; }

        /// <summary>
        /// The leader of the dynamic zone
        /// </summary>
        public DZMemberType Leader => GetMember<DZMemberType>("Leader");
        
        /// <summary>
        /// TODO: Document DynamicZoneType.InRaid
        /// </summary>
        public bool InRaid => GetMember<BoolType>("InRaid");
    }
}