namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for RaidType
    public class RaidType : MQ2DataType
    {
        public BoolType Locked => GetMember<BoolType>("Locked");
        public BoolType Invited => GetMember<BoolType>("Invited");
        public RaidMemberType xMember => GetMember<RaidMemberType>("xMember");
        public IntType Members => GetMember<IntType>("Members");
        public RaidMemberType Target => GetMember<RaidMemberType>("Target");
        public RaidMemberType Leader => GetMember<RaidMemberType>("Leader");
        public IntType TotalLevels => GetMember<IntType>("TotalLevels");
        public FloatType AverageLevel => GetMember<FloatType>("AverageLevel");
        public IntType LootType => GetMember<IntType>("LootType");
        public IntType Looters => GetMember<IntType>("Looters");
        public StringType Looter => GetMember<StringType>("Looter");
        public RaidMemberType MainAssist => GetMember<RaidMemberType>("MainAssist");
        public RaidMemberType MasterLooter => GetMember<RaidMemberType>("MasterLooter");
    }
}