// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class FellowshipType : MQ2DataType
    {
        internal FellowshipType(MQ2TypeVar typeVar) : base(typeVar)
        {
            xMember = new IndexedMember<FellowshipMemberType, string, FellowshipMemberType, int>(this, "xMember");
        }

        /// <summary>
        /// Fellowship ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

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
        public IntType Members => GetMember<IntType>("Members");

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
        public FloatType CampfireY => GetMember<FloatType>("CampfireY");

        /// <summary>
        /// Campfire X location
        /// </summary>
        public FloatType CampfireX => GetMember<FloatType>("CampfireX");

        /// <summary>
        /// Campfire Z location
        /// </summary>
        public FloatType CampfireZ => GetMember<FloatType>("CampfireZ");

        /// <summary>
        /// Zone information for the zone that contains your campfire
        /// </summary>
        public ZoneType CampfireZone => GetMember<ZoneType>("CampfireZone");

        /// <summary>
        /// TRUE if campfire is up, FALSE if not
        /// </summary>
        public BoolType Campfire => GetMember<BoolType>("Campfire");
    }
}