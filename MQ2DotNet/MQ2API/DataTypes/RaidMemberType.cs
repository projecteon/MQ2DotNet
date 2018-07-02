// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class RaidMemberType : MQ2DataType
    {
        internal RaidMemberType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Raid member's name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Current group number (or 0)
        /// </summary>
        public IntType Group => GetMember<IntType>("Group");

        /// <summary>
        /// Returns TRUE if the member is a group leader
        /// </summary>
        public BoolType GroupLeader => GetMember<BoolType>("GroupLeader");

        /// <summary>
        /// Returns TRUE if the member is the raid leader
        /// </summary>
        public BoolType RaidLeader => GetMember<BoolType>("RaidLeader");

        /// <summary>
        /// Allowed to loot with current loot rules and looters?
        /// </summary>
        public BoolType Looter => GetMember<BoolType>("Looter");

        /// <summary>
        /// Spawn object for this player if available (must be in zone)
        /// </summary>
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");

        /// <summary>
        /// Raid member's level (works without being in zone)
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Raid member's class (works without being in zone)
        /// </summary>
        public ClassType Class => GetMember<ClassType>("Class");
    }
}