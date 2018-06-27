namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for FellowshipMemberType
    public class FellowshipMemberType : MQ2DataType
    {
        public ZoneType Zone => GetMember<ZoneType>("Zone");
        public IntType Level => GetMember<IntType>("Level");
        public ClassType Class => GetMember<ClassType>("Class");
        public TicksType LastOn => GetMember<TicksType>("LastOn");
        public StringType Name => GetMember<StringType>("Name");
    }
}