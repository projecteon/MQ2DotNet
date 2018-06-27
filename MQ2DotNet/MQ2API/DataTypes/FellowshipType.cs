namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for FellowshipType
    public class FellowshipType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public StringType Leader => GetMember<StringType>("Leader");
        public StringType MotD => GetMember<StringType>("MotD");
        public IntType Members => GetMember<IntType>("Members");
        public FellowshipMemberType xMember => GetMember<FellowshipMemberType>("xMember");
        public TicksType CampfireDuration => GetMember<TicksType>("CampfireDuration");
        public FloatType CampfireY => GetMember<FloatType>("CampfireY");
        public FloatType CampfireX => GetMember<FloatType>("CampfireX");
        public FloatType CampfireZ => GetMember<FloatType>("CampfireZ");
        public ZoneType CampfireZone => GetMember<ZoneType>("CampfireZone");
        public BoolType Campfire => GetMember<BoolType>("Campfire");
    }
}