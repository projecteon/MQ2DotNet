namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SkillType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType ID => GetMember<IntType>("ID");
        public IntType ReuseTime => GetMember<IntType>("ReuseTime");
        public IntType MinLevel => GetMember<IntType>("MinLevel");
        public IntType SkillCap => GetMember<IntType>("SkillCap");
        public IntType AltTimer => GetMember<IntType>("AltTimer");
        public BoolType Activated => GetMember<BoolType>("Activated");
        public BoolType Auto => GetMember<BoolType>("Auto");
    }
}