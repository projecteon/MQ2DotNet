namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Implicit conversion to TimeSpan
    public class TicksType : MQ2DataType
    {
        public IntType Hours => GetMember<IntType>("Hours");
        public IntType Minutes => GetMember<IntType>("Minutes");
        public IntType Seconds => GetMember<IntType>("Seconds");
        public StringType TimeHMS => GetMember<StringType>("TimeHMS");
        public StringType Time => GetMember<StringType>("Time");
        public IntType TotalMinutes => GetMember<IntType>("TotalMinutes");
        public IntType TotalSeconds => GetMember<IntType>("TotalSeconds");
        public IntType Ticks => GetMember<IntType>("Ticks");
    }
}