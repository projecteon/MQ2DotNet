// ReSharper disable UnusedMember.Global
namespace MQ2DotNet.MQ2API.DataTypes
{
    ///TODO: Document ItemSpellType. Most names are self-explantory but several could use example values e.g. EffectType
    public class ItemSpellType : MQ2DataType
    {
        internal ItemSpellType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public int SpellID => GetMember<IntType>("SpellID");
        public int RequiredLevel => GetMember<IntType>("RequiredLevel");
        public int EffectType => GetMember<IntType>("EffectType");
        public int EffectiveCasterLevel => GetMember<IntType>("EffectiveCasterLevel");
        public int MaxCharges => GetMember<IntType>("MaxCharges");
        public int CastTime => GetMember<IntType>("CastTime");
        public int TimerID => GetMember<IntType>("TimerID");
        public int RecastType => GetMember<IntType>("RecastType");
        public int ProcRate => GetMember<IntType>("ProcRate");
        public string OtherName => GetMember<StringType>("OtherName");
        public int OtherID => GetMember<IntType>("OtherID");
        public SpellType Spell => GetMember<SpellType>("Spell");
    }
}