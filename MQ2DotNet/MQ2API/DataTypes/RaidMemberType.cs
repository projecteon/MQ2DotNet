namespace MQ2DotNet.MQ2API.DataTypes
{
    public class RaidMemberType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType Group => GetMember<IntType>("Group");
        public BoolType GroupLeader => GetMember<BoolType>("GroupLeader");
        public BoolType RaidLeader => GetMember<BoolType>("RaidLeader");
        public BoolType Looter => GetMember<BoolType>("Looter");
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");
        public IntType Level => GetMember<IntType>("Level");
        public ClassType Class => GetMember<ClassType>("Class");
    }
}