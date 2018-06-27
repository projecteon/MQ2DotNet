namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for DeityType
    public class DeityType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
        public StringType Team => GetMember<StringType>("Team");
    }
}