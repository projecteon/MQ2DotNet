namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for GroundType
    public class GroundType : MQ2DataType
    {
        public IntType Address => GetMember<IntType>("Address");
        public IntType ID => GetMember<IntType>("ID");
        public IntType SubID => GetMember<IntType>("SubID");
        public IntType ZoneID => GetMember<IntType>("ZoneID");
        public FloatType X => GetMember<FloatType>("X");
        public FloatType Y => GetMember<FloatType>("Y");
        public FloatType Z => GetMember<FloatType>("Z");
        public StringType Name => GetMember<StringType>("Name");
        public StringType DisplayName => GetMember<StringType>("DisplayName");
        public HeadingType Heading => GetMember<HeadingType>("Heading");
        public FloatType Distance => GetMember<FloatType>("Distance");
        public FloatType Distance3D => GetMember<FloatType>("Distance3D");
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");
        public BoolType xLineOfSight => GetMember<BoolType>("xLineOfSight");
    }
}