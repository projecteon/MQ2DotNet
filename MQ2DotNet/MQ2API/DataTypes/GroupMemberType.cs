namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for GroupMemberType
    public class GroupMemberType : SpawnType
    {
        public new IntType Address => GetMember<IntType>("Address");
        public new StringType Name => GetMember<StringType>("Name");
        public BoolType Leader => GetMember<BoolType>("Leader");
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");
        public new IntType Level => GetMember<IntType>("Level");
        public BoolType MainTank => GetMember<BoolType>("MainTank");
        public BoolType MainAssist => GetMember<BoolType>("MainAssist");
        public BoolType MarkNpc => GetMember<BoolType>("MarkNpc");
        public BoolType MasterLooter => GetMember<BoolType>("MasterLooter");
        public BoolType Puller => GetMember<BoolType>("Puller");
        public BoolType Mercenary => GetMember<BoolType>("Mercenary");
        public IntType PctAggro => GetMember<IntType>("PctAggro");
        public IntType xIndex => GetMember<IntType>("xIndex");
        public BoolType Offline => GetMember<BoolType>("Offline");
        public BoolType Present => GetMember<BoolType>("Present");
        public BoolType OtherZone => GetMember<BoolType>("OtherZone");
    }
}