namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Implicit conversion to TimeSpan or DateTime (figure out which)
    public class TimeStampType : MQ2DataType
    {
        public Int64Type Hours => GetMember<Int64Type>("Hours");
        public Int64Type Minutes => GetMember<Int64Type>("Minutes");
        public Int64Type Seconds => GetMember<Int64Type>("Seconds");
        public StringType TimeHMS => GetMember<StringType>("TimeHMS");
        public StringType Time => GetMember<StringType>("Time");
        public Int64Type TotalMinutes => GetMember<Int64Type>("TotalMinutes");
        public Int64Type TotalSeconds => GetMember<Int64Type>("TotalSeconds");
        public Int64Type Raw => GetMember<Int64Type>("Raw");
        public FloatType Float => GetMember<FloatType>("Float");
        public Int64Type Ticks => GetMember<Int64Type>("Ticks");
    }
}