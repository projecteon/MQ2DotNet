namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for BodyType
    public class BodyType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
    }
}