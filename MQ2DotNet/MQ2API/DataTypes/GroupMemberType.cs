// ReSharper disable UnusedMember.Global
namespace MQ2DotNet.MQ2API.DataTypes
{
    public class GroupMemberType : SpawnType
    {
        /// <summary>
        /// Memory address of the GROUPMEMBER struct
        /// </summary>
        public new IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// The name of the group member. This works even if they are not in the same zone as you
        /// </summary>
        public new StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// TRUE if the member is the group's leader, FALSE otherwise
        /// </summary>
        public BoolType Leader => GetMember<BoolType>("Leader");

        /// <summary>
        /// Accesses the group member's spawn directly
        /// </summary>
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");

        /// <summary>
        /// The member's level
        /// </summary>
        public new IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// TRUE if the member is designated as the group's Main Tank, FALSE otherwise
        /// </summary>
        public BoolType MainTank => GetMember<BoolType>("MainTank");

        /// <summary>
        /// TRUE if the member is designated as the group's Main Assist, FALSE otherwise
        /// </summary>
        public BoolType MainAssist => GetMember<BoolType>("MainAssist");

        /// <summary>
        /// TRUE if the member is designated as the Mark NPC role
        /// </summary>
        public BoolType MarkNpc => GetMember<BoolType>("MarkNpc");

        /// <summary>
        /// TRUE if the member is designated as the Master Looter role
        /// </summary>
        public BoolType MasterLooter => GetMember<BoolType>("MasterLooter");

        /// <summary>
        /// TRUE if the member is designated as the Puller role
        /// </summary>
        public BoolType Puller => GetMember<BoolType>("Puller");

        /// <summary>
        /// TRUE if the member is a mercenary, FALSE otherwise
        /// </summary>
        public BoolType Mercenary => GetMember<BoolType>("Mercenary");

        /// <summary>
        /// Member's aggro percentage as shown in the group window
        /// </summary>
        public IntType PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Index (0 based) of the member in the group
        /// </summary>
        public IntType xIndex => GetMember<IntType>("xIndex");

        /// <summary>
        /// TRUE if the member is offline and FALSE if online
        /// </summary>
        public BoolType Offline => GetMember<BoolType>("Offline");

        /// <summary>
        /// TRUE if the member is online and in same zone and FALSE if online and not in same zone as you
        /// </summary>
        public BoolType Present => GetMember<BoolType>("Present");

        /// <summary>
        /// TRUE if the member is online but in another zone and FALSE if online and in same zone as you
        /// </summary>
        public BoolType OtherZone => GetMember<BoolType>("OtherZone");
    }
}