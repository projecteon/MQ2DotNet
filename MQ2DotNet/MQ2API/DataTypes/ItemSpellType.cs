namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ItemSpellType : MQ2DataType
    {
        public IntType SpellID => GetMember<IntType>("SpellID");
        public IntType RequiredLevel => GetMember<IntType>("RequiredLevel");
        public IntType EffectType => GetMember<IntType>("EffectType");
        public IntType EffectiveCasterLevel => GetMember<IntType>("EffectiveCasterLevel");
        public IntType MaxCharges => GetMember<IntType>("MaxCharges");
        public IntType CastTime => GetMember<IntType>("CastTime");
        public IntType TimerID => GetMember<IntType>("TimerID");
        public IntType RecastType => GetMember<IntType>("RecastType");
        public IntType ProcRate => GetMember<IntType>("ProcRate");
        public StringType OtherName => GetMember<StringType>("OtherName");
        public IntType OtherID => GetMember<IntType>("OtherID");
        public SpellType Spell => GetMember<SpellType>("Spell");
    }
}