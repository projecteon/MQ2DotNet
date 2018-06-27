namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for BuffType
    public class BuffType : SpellType
    {
        public new IntType Address => GetMember<IntType>("Address");
        public new IntType ID => GetMember<IntType>("ID");
        public new IntType Level => GetMember<IntType>("Level");
        public SpellType Spell => GetMember<SpellType>("Spell");
        public FloatType Mod => GetMember<FloatType>("Mod");
        public new TimeStampType Duration => GetMember<TimeStampType>("Duration");
        public IntType Dar => GetMember<IntType>("Dar");
        public IntType TotalCounters => GetMember<IntType>("TotalCounters");
        public IntType CountersDisease => GetMember<IntType>("CountersDisease");
        public IntType CountersPoison => GetMember<IntType>("CountersPoison");
        public IntType CountersCurse => GetMember<IntType>("CountersCurse");
        public IntType CountersCorruption => GetMember<IntType>("CountersCorruption");
        public IntType HitCount => GetMember<IntType>("HitCount");
    }
}