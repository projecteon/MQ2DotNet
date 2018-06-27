namespace MQ2DotNet.MQ2API.DataTypes
{
    public class HeadingType : MQ2DataType
    {
        public IntType Clock => GetMember<IntType>("Clock");
        public FloatType Degrees => GetMember<FloatType>("Degrees");
        public FloatType DegreesCCW => GetMember<FloatType>("DegreesCCW");
        public StringType ShortName => GetMember<StringType>("ShortName");
        public StringType Name => GetMember<StringType>("Name");
    }
}