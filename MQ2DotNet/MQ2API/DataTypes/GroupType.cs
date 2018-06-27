namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for GroupType
    public class GroupType : MQ2DataType
    {
        public IntType Address => GetMember<IntType>("Address");
        public GroupMemberType xMember => GetMember<GroupMemberType>("xMember");
        public IntType Members => GetMember<IntType>("Members");
        public GroupMemberType Leader => GetMember<GroupMemberType>("Leader");
        public IntType GroupSize => GetMember<IntType>("GroupSize");
        public GroupMemberType MainTank => GetMember<GroupMemberType>("MainTank");
        public GroupMemberType MainAssist => GetMember<GroupMemberType>("MainAssist");
        public GroupMemberType Puller => GetMember<GroupMemberType>("Puller");
        public GroupMemberType MarkNpc => GetMember<GroupMemberType>("MarkNpc");
        public GroupMemberType MasterLooter => GetMember<GroupMemberType>("MasterLooter");
        public BoolType AnyoneMissing => GetMember<BoolType>("AnyoneMissing");
        public IntType Present => GetMember<IntType>("Present");
        public IntType MercenaryCount => GetMember<IntType>("MercenaryCount");
        public IntType TankMercCount => GetMember<IntType>("TankMercCount");
        public IntType HealerMercCount => GetMember<IntType>("HealerMercCount");
        public IntType MeleeMercCount => GetMember<IntType>("MeleeMercCount");
        public IntType CasterMercCount => GetMember<IntType>("CasterMercCount");
        public IntType AvgHPs => GetMember<IntType>("AvgHPs");
        public IntType Injured => GetMember<IntType>("Injured");
        public SpawnType XCleric => GetMember<SpawnType>("XCleric");
        public GroupMemberType MouseOver => GetMember<GroupMemberType>("MouseOver");
    }
}