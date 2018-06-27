namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for DZMemberType
    public class DZMemberType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public StringType Status => GetMember<StringType>("Status");
    }
}