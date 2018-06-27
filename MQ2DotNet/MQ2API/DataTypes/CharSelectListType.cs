namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for CharSelectListType
    public class CharSelectListType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType Level => GetMember<IntType>("Level");
        public IntType ZoneID => GetMember<IntType>("ZoneID");
        public IntType Count => GetMember<IntType>("Count");
    }
}