namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SwitchType : MQ2DataType
    {
        public IntType Address => GetMember<IntType>("Address");
        public IntType ID => GetMember<IntType>("ID");
        public FloatType X => GetMember<FloatType>("X");
        public FloatType Y => GetMember<FloatType>("Y");
        public FloatType Z => GetMember<FloatType>("Z");
        public FloatType DefaultX => GetMember<FloatType>("DefaultX");
        public FloatType DefaultY => GetMember<FloatType>("DefaultY");
        public FloatType DefaultZ => GetMember<FloatType>("DefaultZ");
        public HeadingType Heading => GetMember<HeadingType>("Heading");
        public HeadingType DefaultHeading => GetMember<HeadingType>("DefaultHeading");
        public BoolType Open => GetMember<BoolType>("Open");
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");
        public StringType Name => GetMember<StringType>("Name");
        public FloatType Distance => GetMember<FloatType>("Distance");
        public FloatType Distance3D => GetMember<FloatType>("Distance3D");
        public BoolType xLineOfSight => GetMember<BoolType>("xLineOfSight");
    }
}