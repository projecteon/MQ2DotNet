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
            xMember = new IndexedMember<FellowshipMemberType, string, FellowshipMemberType, int>(this, "xMember");
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
        /// Member data by name or #
        /// </summary>
        public IndexedMember<FellowshipMemberType, string, FellowshipMemberType, int> xMember { get; }

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
    }
}