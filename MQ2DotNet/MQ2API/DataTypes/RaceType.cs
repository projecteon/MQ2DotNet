namespace MQ2DotNet.MQ2API.DataTypes
{
    public class RaceType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
    }
}