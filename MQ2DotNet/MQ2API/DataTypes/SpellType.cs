namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for SpellType
    public class SpellType : MQ2DataType
    {
        public SpellType()
        {
            HasSPA = new IndexedMember<BoolType, int>(this, "HasSPA");
            Trigger = new IndexedMember<SpellType, int>(this, "Trigger");
        }

        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
        public IntType Level => GetMember<IntType>("Level");
        public IntType Mana => GetMember<IntType>("Mana");
        public IntType ResistAdj => GetMember<IntType>("ResistAdj");
        public FloatType Range => GetMember<FloatType>("Range");
        public FloatType AERange => GetMember<FloatType>("AERange");
        public FloatType PushBack => GetMember<FloatType>("PushBack");
        public TimeStampType CastTime => GetMember<TimeStampType>("CastTime");
	    public TimeStampType RecoveryTime => FizzleTime;
        public TimeStampType FizzleTime => GetMember<TimeStampType>("FizzleTime");
        public TimeStampType RecastTime => GetMember<TimeStampType>("RecastTime");
        public StringType ResistType => GetMember<StringType>("ResistType");
        public StringType SpellType_ => GetMember<StringType>("SpellType");
        public StringType TargetType => GetMember<StringType>("TargetType");
        public StringType Skill => GetMember<StringType>("Skill");
        public TimeStampType MyCastTime => GetMember<TimeStampType>("MyCastTime");
        public TicksType Duration => GetMember<TicksType>("Duration");
        public TicksType EQSpellDuration => GetMember<TicksType>("EQSpellDuration");
        public StringType CastByMe => GetMember<StringType>("CastByMe");
        public StringType CastByOther => GetMember<StringType>("CastByOther");
        public StringType CastOnYou => GetMember<StringType>("CastOnYou");
        public StringType CastOnAnother => GetMember<StringType>("CastOnAnother");
        public StringType WearOff => GetMember<StringType>("WearOff");
        public StringType CounterType => GetMember<StringType>("CounterType");
        public IntType CounterNumber => GetMember<IntType>("CounterNumber");
        public BoolType NewStacks => GetMember<BoolType>("NewStacks");
        public BoolType NewStacksWith => GetMember<BoolType>("NewStacksWith");
        public BoolType Stacks => GetMember<BoolType>("Stacks");
        public BoolType NewStacksTarget => GetMember<BoolType>("NewStacksTarget");
        public BoolType StacksPet => GetMember<BoolType>("StacksPet");
        public BoolType StacksWith => GetMember<BoolType>("StacksWith");
        public BoolType WillStack => GetMember<BoolType>("WillStack");
        public FloatType MyRange => GetMember<FloatType>("MyRange");
        public IntType Address => GetMember<IntType>("Address");
        public IntType EnduranceCost => GetMember<IntType>("EnduranceCost");
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");
        public StringType Category => GetMember<StringType>("Category");
        public StringType Subcategory => GetMember<StringType>("Subcategory");
        public StringType Restrictions => GetMember<StringType>("Restrictions");
        public IntType Base => GetMember<IntType>("Base");
        public IntType Base2 => GetMember<IntType>("Base2");
        public IntType Max => GetMember<IntType>("Max");
        public IntType Calc => GetMember<IntType>("Calc");
        public IntType Attrib => GetMember<IntType>("Attrib");
        public IntType CalcIndex => GetMember<IntType>("CalcIndex");
        public IntType NumEffects => GetMember<IntType>("NumEffects");
        public IntType AutoCast => GetMember<IntType>("AutoCast");
        public StringType Extra => GetMember<StringType>("Extra");
        public IntType RecastTimerID => GetMember<IntType>("RecastTimerID");
        public IntType SPA => GetMember<IntType>("SPA");
        public IntType ReagentID => GetMember<IntType>("ReagentID");
        public IntType ReagentCount => GetMember<IntType>("ReagentCount");
        public IntType TimeOfDay => GetMember<IntType>("TimeOfDay");
        public IntType DurationWindow => GetMember<IntType>("DurationWindow");
        public BoolType CanMGB => GetMember<BoolType>("CanMGB");
        public BoolType IsSkill => GetMember<BoolType>("IsSkill");
        public BoolType Deletable => GetMember<BoolType>("Deletable");
        public IntType BookIcon => GetMember<IntType>("BookIcon");
        public StringType Target => GetMember<StringType>("Target");
        public StringType Description => GetMember<StringType>("Description");
        public StringType Caster => GetMember<StringType>("Caster");
        public IntType Rank => GetMember<IntType>("Rank");
        public SpellType RankName => GetMember<SpellType>("RankName");
        public IntType SpellGroup => GetMember<IntType>("SpellGroup");
        public IntType SubSpellGroup => GetMember<IntType>("SubSpellGroup");
        public BoolType Beneficial => GetMember<BoolType>("Beneficial");
        public BoolType xIsActiveAA => GetMember<BoolType>("xIsActiveAA");
        public IntType Location => GetMember<IntType>("Location");
        public BoolType IsSwarmSpell => GetMember<BoolType>("IsSwarmSpell");
        public IntType DurationValue1 => GetMember<IntType>("DurationValue1");
        public BoolType IllusionOkWhenMounted => GetMember<BoolType>("IllusionOkWhenMounted");
        public IndexedMember<BoolType, int> HasSPA { get; }
        public IndexedMember<SpellType, int> Trigger { get; }
    }
}