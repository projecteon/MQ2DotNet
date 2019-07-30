using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a raid
    /// </summary>
    [PublicAPI]
    [MQ2Type("raid")]
    public class RaidType : MQ2DataType
    {
        internal RaidType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Member = new IndexedMember<RaidMemberType, string, RaidMemberType, int>(this, "Member");
        }

        /// <summary>
        /// Returns TRUE if the raid is locked
        /// </summary>
        public bool Locked => GetMember<BoolType>("Locked");

        /// <summary>
        /// Invited to raid?
        /// </summary>
        public bool Invited => GetMember<BoolType>("Invited");

        /// <summary>
        /// Raid member by name or number (1 based)
        /// </summary>
        public IndexedMember<RaidMemberType, string, RaidMemberType, int> Member { get; }

        /// <summary>
        /// Total number of raid members
        /// </summary>
        public int? Members => GetMember<IntType>("Members");

        /// <summary>
        /// Raid target (clicked in raid window)
        /// </summary>
        public RaidMemberType Target => GetMember<RaidMemberType>("Target");

        /// <summary>
        /// Raid leader
        /// </summary>
        public RaidMemberType Leader => GetMember<RaidMemberType>("Leader");

        /// <summary>
        /// Sum of all raid members' levels
        /// </summary>
        public int? TotalLevels => GetMember<IntType>("TotalLevels");

        /// <summary>
        /// Average level of raid members (more accurate than in the window)
        /// </summary>
        public float? AverageLevel => GetMember<FloatType>("AverageLevel");

        /// <summary>
        /// Loot type number (1 = Leader, 2 = Leader and GroupLeader, 3 = Leader and Specified
        /// </summary>
        public int? LootType => GetMember<IntType>("LootType");

        /// <summary>
        /// Number of specified looters
        /// </summary>
        public int? Looters => GetMember<IntType>("Looters");

        /// <summary>
        /// Specified looter name by number (1 - <see cref="Looters"/>)
        /// </summary>
        public string Looter => GetMember<StringType>("Looter");

        /// <summary>
        /// Raid main assist
        /// </summary>
        public RaidMemberType MainAssist => GetMember<RaidMemberType>("MainAssist");

        /// <summary>
        /// Raid master looter
        /// </summary>
        public RaidMemberType MasterLooter => GetMember<RaidMemberType>("MasterLooter");
    }
}