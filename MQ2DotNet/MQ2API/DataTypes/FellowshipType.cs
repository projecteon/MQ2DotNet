using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a fellowship
    /// </summary>
    [PublicAPI]
    [MQ2Type("fellowship")]
    public class FellowshipType : MQ2DataType
    {
        internal FellowshipType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Member = new IndexedMember<FellowshipMemberType, string, FellowshipMemberType, int>(this, "Member");
            Sharing = new IndexedMember<BoolType, int>(this, "Sharing");
        }

        /// <summary>
        /// Fellowship ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Fellowship leader's name
        /// </summary>
        public string Leader => GetMember<StringType>("Leader");

        /// <summary>
        /// Fellowship Message of the Day
        /// </summary>
        public string MotD => GetMember<StringType>("MotD");

        /// <summary>
        /// Number of members in the fellowship
        /// </summary>
        public int? Members => GetMember<IntType>("Members");

        /// <summary>
        /// Returns TRUE if a fellowship exists.
        /// </summary>
        public bool Exists => GetMember<BoolType>("Exists");

        /// <summary>
        /// Member data by name or #
        /// </summary>
        public IndexedMember<FellowshipMemberType, string, FellowshipMemberType, int> Member { get; }

        /// <summary>
        /// Time left on current campfire
        /// </summary>
        public TicksType CampfireDuration => GetMember<TicksType>("CampfireDuration");

        /// <summary>
        /// Campfire Y location
        /// </summary>
        public float? CampfireY => GetMember<FloatType>("CampfireY");

        /// <summary>
        /// Campfire X location
        /// </summary>
        public float? CampfireX => GetMember<FloatType>("CampfireX");

        /// <summary>
        /// Campfire Z location
        /// </summary>
        public float? CampfireZ => GetMember<FloatType>("CampfireZ");

        /// <summary>
        /// Zone information for the zone that contains your campfire
        /// </summary>
        public ZoneType CampfireZone => GetMember<ZoneType>("CampfireZone");

        /// <summary>
        /// TRUE if campfire is up, FALSE if not
        /// </summary>
        public bool Campfire => GetMember<BoolType>("Campfire");

        /// <summary>
        /// Returns TRUE if exp sharing is enabled for the Nth member.
        /// Sharing[ N ]
        /// </summary>
        public IndexedMember<BoolType, int> Sharing { get; }
    }
}