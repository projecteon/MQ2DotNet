namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Implicit conversion to DateTime
    public class TimeType : MQ2DataType
    {
        public IntType Hour => GetMember<IntType>("Hour");
        public StringType Hour12 => GetMember<StringType>("Hour12");
        public IntType Minute => GetMember<IntType>("Minute");
        public IntType Second => GetMember<IntType>("Second");
        public IntType DayOfWeek => GetMember<IntType>("DayOfWeek");
        public IntType Day => GetMember<IntType>("Day");
        public IntType Month => GetMember<IntType>("Month");
        public IntType Year => GetMember<IntType>("Year");
        public StringType Time12 => GetMember<StringType>("Time12");
        public StringType Time24 => GetMember<StringType>("Time24");
        public StringType Date => GetMember<StringType>("Date");
        public BoolType Night => GetMember<BoolType>("Night");
        public IntType SecondsSinceMidnight => GetMember<IntType>("SecondsSinceMidnight");
    }
}