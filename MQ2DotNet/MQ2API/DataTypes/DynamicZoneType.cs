namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for DynamicZoneType
    public class DynamicZoneType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType Members => GetMember<IntType>("Members");
        public IntType MaxMembers => GetMember<IntType>("MaxMembers");
        public DZMemberType xMember => GetMember<DZMemberType>("xMember");
        public DZMemberType Leader => GetMember<DZMemberType>("Leader");
        public BoolType InRaid => GetMember<BoolType>("InRaid");
    }
}