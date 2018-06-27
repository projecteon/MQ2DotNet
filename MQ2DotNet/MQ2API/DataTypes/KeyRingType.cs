namespace MQ2DotNet.MQ2API.DataTypes
{
    public class KeyRingType : MQ2DataType
    {
        public IntType xIndex => GetMember<IntType>("xIndex");
        public StringType Name => GetMember<StringType>("Name");
    }
}