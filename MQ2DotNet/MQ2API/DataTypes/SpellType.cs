// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SpellType : MQ2DataType
    {
        public SpellType()
        {
            ReagentID = new IndexedMember<IntType, int>(this, "ReagentID");
            ReagentCount = new IndexedMember<IntType, int>(this, "ReagentCount");
            Max = new IndexedMember<IntType, int>(this, "Max");
            Calc = new IndexedMember<IntType, int>(this, "Calc");
            Attrib = new IndexedMember<IntType, int>(this, "Attrib");
            Base2 = new IndexedMember<IntType, int>(this, "Base");
            Base = new IndexedMember<IntType, int>(this, "Base");
            Restrictions = new IndexedMember<StringType, int>(this, "Restrictions");
            WillStack = new IndexedMember<BoolType, string>(this, "WillStack");
            StacksWith = new IndexedMember<BoolType, string>(this, "StacksWith");
            StacksPet = new IndexedMember<BoolType, int>(this, "StacksPet");
            Stacks = new IndexedMember<BoolType, int>(this, "Stacks");
            HasSPA = new IndexedMember<BoolType, int>(this, "HasSPA");
            Trigger = new IndexedMember<SpellType, int>(this, "Trigger");
        }

        /// <summary>
        /// Spell ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Spell Name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Level
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Mana cost (unadjusted)
        /// </summary>
        public IntType Mana => GetMember<IntType>("Mana");

        /// <summary>
        /// Resist adjustment
        /// </summary>
        public IntType ResistAdj => GetMember<IntType>("ResistAdj");

        /// <summary>
        /// Maximum range to target (use <see cref="AERange"/> for AE and group spells)
        /// </summary>
        public FloatType Range => GetMember<FloatType>("Range");

        /// <summary>
        /// AE range (group spells use this for their range)
        /// </summary>
        public FloatType AERange => GetMember<FloatType>("AERange");

        /// <summary>
        /// Push back amount
        /// </summary>
        public FloatType PushBack => GetMember<FloatType>("PushBack");

        /// <summary>
        /// Cast time (unadjusted)
        /// </summary>
        public TimeStampType CastTime => GetMember<TimeStampType>("CastTime");

        /// <summary>
        /// Time to recover after fizzle
        /// </summary>
	    public TimeStampType RecoveryTime => FizzleTime;

        /// <summary>
        /// Time to recover after fizzle
        /// </summary>
        public TimeStampType FizzleTime => GetMember<TimeStampType>("FizzleTime");

        /// <summary>
        /// Time to recast after successful cast
        /// </summary>
        public TimeStampType RecastTime => GetMember<TimeStampType>("RecastTime");

        /// <summary>
        /// One of Chromatic, Corruption, Cold, Disease, Fire, Magic, Poison, Unknown, Unresistable, Prismatic
        /// </summary>
        public StringType ResistType => GetMember<StringType>("ResistType");

        /// <summary>
        /// "Beneficial(Group)", "Beneficial", "Detrimental" or "Unknown"
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public StringType SpellType_ => GetMember<StringType>("SpellType");

        /// <summary>
        /// Target type e.g. Self, Animal, Targeted AE etc
        /// </summary>
        public StringType TargetType => GetMember<StringType>("TargetType");

        /// <summary>
        /// Casting school, one of Abjuration, Alteration, Conjuration, Divination, Evocation
        /// </summary>
        public StringType Skill => GetMember<StringType>("Skill");

        /// <summary>
        /// Adjusted cast time
        /// </summary>
        public TimeStampType MyCastTime => GetMember<TimeStampType>("MyCastTime");

        /// <summary>
        /// Duration of the spell (if any), MQ2 version
        /// </summary>
        public TicksType Duration => GetMember<TicksType>("Duration");

        /// <summary>
        /// Duration of the spell (if any), EQ version
        /// </summary>
        public TicksType EQSpellDuration => GetMember<TicksType>("EQSpellDuration");

        /// <summary>
        /// Message when you cast the spell
        /// </summary>
        public StringType CastByMe => GetMember<StringType>("CastByMe");

        /// <summary>
        /// Message when someone else casts the spell
        /// </summary>
        public StringType CastByOther => GetMember<StringType>("CastByOther");

        /// <summary>
        /// Message when the spell lands on you
        /// </summary>
        public StringType CastOnYou => GetMember<StringType>("CastOnYou");

        /// <summary>
        /// Message when the spawn lands on someone else
        /// </summary>
        public StringType CastOnAnother => GetMember<StringType>("CastOnAnother");

        /// <summary>
        /// Message when the spell wears off
        /// </summary>
        public StringType WearOff => GetMember<StringType>("WearOff");

        /// <summary>
        /// The resist counter. Will be one of "Disease", "Poison", "Curse" or "Corruption"
        /// </summary>
        public StringType CounterType => GetMember<StringType>("CounterType");

        /// <summary>
        /// The number of counters that the spell adds
        /// </summary>
        public IntType CounterNumber => GetMember<IntType>("CounterNumber");
        public BoolType NewStacks => GetMember<BoolType>("NewStacks");
        public BoolType NewStacksWith => GetMember<BoolType>("NewStacksWith");

        /// <summary>
        /// Does this spell stack with your current buffs (duration is in ticks)
        /// </summary>
        public IndexedMember<BoolType, int> Stacks { get; }

        public BoolType NewStacksTarget => GetMember<BoolType>("NewStacksTarget");

        /// <summary>
        /// Does this spell stack with your pet's current buffs (duration is in ticks)
        /// </summary>
        public IndexedMember<BoolType, int> StacksPet { get; }

        /// <summary>
        /// Does this spell stack with another spell?
        /// </summary>
        public IndexedMember<BoolType, string> StacksWith { get; }

        /// <summary>
        /// Does this spell stack with another spell?
        /// </summary>
        public IndexedMember<BoolType, string> WillStack { get; }

        /// <summary>
        /// Adjusted spell range, including focus effects, etc.
        /// </summary>
        public FloatType MyRange => GetMember<FloatType>("MyRange");

        /// <summary>
        /// Memory address of the SPELL struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Endurance cost of the spell
        /// </summary>
        public IntType EnduranceCost => GetMember<IntType>("EnduranceCost");

        /// <summary>
        /// Max level the spell can affect
        /// </summary>
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");

        /// <summary>
        /// Category of the spell e.g. Direct Damage, Heals
        /// First level of the menu when you right click a gem
        /// </summary>
        public StringType Category => GetMember<StringType>("Category");

        /// <summary>
        /// Subcategory of the spell e.g. Combat Innates, Damage Shield
        /// Second level of the menu when you right click a gem
        /// </summary>
        public StringType Subcategory => GetMember<StringType>("Subcategory");

        /// <summary>
        /// Text of the nth restriction (1 based) on the spell
        /// </summary>
        public IndexedMember<StringType, int> Restrictions { get; }

        /// <summary>
        /// Base value of the nth spell effect slot, 1 based
        /// e.g. for a nuke that says Slot 1: Decrease HP by 1000
        /// Base[1] = -1000
        /// </summary>
        public IndexedMember<IntType, int> Base { get; }

        /// <summary>
        /// Base2 value of the nth spell effect slot, 1 based
        /// </summary>
        public IndexedMember<IntType, int> Base2 { get; }

        /// <summary>
        /// Max value of the nth spell effect slot, 1 based
        /// </summary>
        public IndexedMember<IntType, int> Max { get; }

        /// <summary>
        /// Calc value of the nth spell effect slot, 1 based
        /// </summary>
        public IndexedMember<IntType, int> Calc { get; }

        /// <summary>
        /// Attrib value of the nth spell effect slot, 1 based
        /// </summary>
        public IndexedMember<IntType, int> Attrib { get; }
        
        /// <summary>
        /// TODO: What is SpellType.CalcIndex
        /// </summary>
        public IntType CalcIndex => GetMember<IntType>("CalcIndex");

        /// <summary>
        /// Number of spell effect slots this spell has
        /// </summary>
        public IntType NumEffects => GetMember<IntType>("NumEffects");

        /// <summary>
        /// TODO: What is SpellType.AutoCast
        /// </summary>
        public IntType AutoCast => GetMember<IntType>("AutoCast");

        /// <summary>
        /// TODO: What is SpellType.Extra
        /// </summary>
        public StringType Extra => GetMember<StringType>("Extra");

        /// <summary>
        /// Shared recast timer number for this spell
        /// </summary>
        public IntType RecastTimerID => GetMember<IntType>("RecastTimerID");

        /// <summary>
        /// SPA number of this spell
        /// </summary>
        public IntType SPA => GetMember<IntType>("SPA");

        /// <summary>
        /// Item ID of the nth required reagent (valid indexes are 1 - 4)
        /// </summary>
        public IndexedMember<IntType, int> ReagentID { get; }

        /// <summary>
        /// Quantity of the nth required reagent (valid indexes are 1 - 4)
        /// </summary>
        public IndexedMember<IntType, int> ReagentCount { get; }

        /// <summary>
        /// Required time of day to cast, 0 = any, 1 = day only, 2 = night only
        /// </summary>
        public IntType TimeOfDay => GetMember<IntType>("TimeOfDay");

        /// <summary>
        /// Which buff window the spell appears in, 0 = long, 1 = short
        /// </summary>
        public IntType DurationWindow => GetMember<IntType>("DurationWindow");

        /// <summary>
        /// Spell can be MGBed
        /// </summary>
        public BoolType CanMGB => GetMember<BoolType>("CanMGB");

        /// <summary>
        /// Is this spell a skill?
        /// </summary>
        public BoolType IsSkill => GetMember<BoolType>("IsSkill");

        /// <summary>
        /// TODO: From spellbook or can be clicked off?
        /// </summary>
        public BoolType Deletable => GetMember<BoolType>("Deletable");

        /// <summary>
        /// Icon ID in the spell book
        /// </summary>
        public IntType BookIcon => GetMember<IntType>("BookIcon");

        /// <summary>
        /// TODO: What is SpellType.Target?
        /// </summary>
        public StringType Target => GetMember<StringType>("Target");

        /// <summary>
        /// Spell effect description from the spell window
        /// </summary>
        public StringType Description => GetMember<StringType>("Description");

        /// <summary>
        /// TODO: What is SpellType.Caster?
        /// </summary>
        public StringType Caster => GetMember<StringType>("Caster");

        /// <summary>
        /// Returns either 1, 2 or 3 for spells and 4-30 for clickys and potions.
        /// </summary>
        public IntType Rank => GetMember<IntType>("Rank");

        /// <summary>
        /// Returns the spell/combat ability name for the rank the character has.
        /// </summary>
        public SpellType RankName => GetMember<SpellType>("RankName");

        /// <summary>
        /// TODO: What is SpellType.SpellGroup?
        /// </summary>
        public IntType SpellGroup => GetMember<IntType>("SpellGroup");

        /// <summary>
        /// TODO: What is SpellType.SubSpellGroup?
        /// </summary>
        public IntType SubSpellGroup => GetMember<IntType>("SubSpellGroup");

        /// <summary>
        /// Is spell beneficial?
        /// </summary>
        public BoolType Beneficial => GetMember<BoolType>("Beneficial");

        /// <summary>
        /// Is the spell an active AA?
        /// </summary>
        public BoolType IsActiveAA => GetMember<BoolType>("IsActiveAA");

        /// <summary>
        /// Appears to be max distance
        /// </summary>
        public IntType Location => GetMember<IntType>("Location");

        /// <summary>
        /// Is this spell a swarm spell?
        /// </summary>
        public BoolType IsSwarmSpell => GetMember<BoolType>("IsSwarmSpell");

        /// <summary>
        /// Duration of the spell (if any). Note - returns DurationCap member of SPELLINFO
        /// </summary>
        public IntType DurationValue1 => GetMember<IntType>("DurationValue1");

        /// <summary>
        /// Illusion cast by this spell is allowed when you are mounted
        /// </summary>
        public BoolType IllusionOkWhenMounted => GetMember<BoolType>("IllusionOkWhenMounted");

        /// <summary>
        /// Does this spell have a given SPA?
        /// </summary>
        public IndexedMember<BoolType, int> HasSPA { get; }

        /// <summary>
        /// TODO: What is SpellType.Trigger
        /// </summary>
        public IndexedMember<SpellType, int> Trigger { get; }
    }
}