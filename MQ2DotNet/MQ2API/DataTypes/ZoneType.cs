namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ZoneType : MQ2DataType
    {
        public IntType Address => GetMember<IntType>("Address");
        public StringType Name => GetMember<StringType>("Name");
        public StringType ShortName => GetMember<StringType>("ShortName");
        public IntType ID => GetMember<IntType>("ID");
        public IntType ZoneFlags => GetMember<IntType>("ZoneFlags");
    }
}