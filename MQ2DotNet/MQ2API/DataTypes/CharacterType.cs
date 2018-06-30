using System;
using System.Reflection;
using System.Runtime.CompilerServices;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CharacterType : SpawnType
    {
        public CharacterType()
        {
            XTarget = new IndexedMember<XTargetType, int>(this, "XTarget");
            XTAggroCount = new IndexedMember<IntType, int>(this, "XTAggroCount");
            SpellReady = new IndexedMember<BoolType, int, BoolType, string>(this, "SpellReady");
            SPA = new IndexedMember<IntType, int>(this, "SPA");
            Song = new IndexedMember<BuffType, string, BuffType, int>(this, "Song");
            SkillCap = new IndexedMember<IntType, string, IntType, int>(this, "SkillCap");
            SkillBase = new IndexedMember<IntType, string, IntType, int>(this, "SkillBase");
            Skill = new IndexedMember<IntType, string, IntType, int>(this, "Skill");
            RaidAssistTarget = new IndexedMember<SpawnType, int>(this, "RaidAssistTarget");
            RaidMarkNPC = new IndexedMember<SpawnType, int>(this, "RaidMarkNPC");
            PetBuff = new IndexedMember<SpellType, int, IntType, string>(this, "PetBuff");
            MercList = new IndexedMember<IntType, string, StringType, int>(this, "MercList");
            LanguageSkill = new IndexedMember<IntType>(this, "LanguageSkill");
            ItemReady = new IndexedMember<BoolType>(this, "ItemReady");
            Inventory = new IndexedMember<ItemType, string, ItemType, int>(this, "Inventory");
            HaveExpansion = new IndexedMember<BoolType, int>(this, "HaveExpansion");
            GroupMarkNPC = new IndexedMember<SpawnType, int>(this, "GroupMarkNPC");
            GemTimer = new IndexedMember<TimeStampType, int, TimeStampType, string>(this, "GemTimer");
            Gem = new IndexedMember<SpellType, int, IntType, string>(this, "Gem");
            BoundLocation = new IndexedMember<WorldLocationType, int>(this, "BoundLocation");
            AutoSkill = new IndexedMember<SkillType, int>(this, "AutoSkill");
            AltCurrency = new IndexedMember<IntType, int, IntType, string>(this, "AltCurrency");
            Buff = new IndexedMember<BuffType, string, BuffType, int>(this, "Buff");
            Book = new IndexedMember<SpellType, int, IntType, string>(this, "Book");
            Aura = new IndexedMember<AuraType, string, AuraType, int>(this, "Aura");
            AltAbilityReady = new IndexedMember<BoolType, int, BoolType, string>(this, "AltAbilityReady");
            AltAbilityTimer = new IndexedMember<TimeStampType, int, TimeStampType, string>(this, "AltAbilityTimer");
            AltAbility = new IndexedMember<AltAbilityType, int, AltAbilityType, string>(this, "AltAbility");
            AbilityReady = new IndexedMember<BoolType, int, BoolType, string>(this, "AbilityReady");
            Ability = new IndexedMember<StringType, int, IntType, string>(this, "Ability");
        }

        /// <summary>
        /// Ability with this name or on this button # ready?
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> AbilityReady;

        /// <summary>
        /// Returns an alt ability by name or number
        /// </summary>
        public IndexedMember<AltAbilityType, int, AltAbilityType, string> AltAbility;

        /// <summary>
        /// Alt ability ready by name or number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> AltAbilityReady;

        /// <summary>
        /// Alt ability reuse time remaining by name or number
        /// </summary>
        public IndexedMember<TimeStampType, int, TimeStampType, string> AltAbilityTimer;

        /// <summary>
        /// Aura by name or slot #
        /// </summary>
        public IndexedMember<AuraType, string, AuraType, int> Aura;

        /// <summary>
        /// Spell in your spellbook by slot number, or slot in your spellbook by spell name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> Book;

        /// <summary>
        /// Buff by name or slot number
        /// </summary>
        public IndexedMember<BuffType, string, BuffType, int> Buff;

        /// <summary>
        /// Combat ability spell by number, or number by name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> CombatAbility;

        /// <summary>
        /// Combat ability ready by name or number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> CombatAbilityReady;
        
        /// <summary>
        /// Combat ability reuse time remaining by name or number
        /// </summary>
        public IndexedMember<TicksType, int, TicksType, string> CombatAbilityTimer;

        /// <summary>
        /// AA exp as a raw number out of 330 (330=100%)
        /// </summary>
        public IntType AAExp => GetMember<IntType>("AAExp");

        /// <summary>
        /// Unused AA points
        /// </summary>
        public IntType AAPoints => GetMember<IntType>("AAPoints");

        /// <summary>
        /// Number of points that have been assigned to an ability
        /// </summary>
        public IntType AAPointsAssigned => GetMember<IntType>("AAPointsAssigned");

        /// <summary>
        /// The number of points you have spent on AA abilities
        /// </summary>
        public IntType AAPointsSpent => GetMember<IntType>("AAPointsSpent");

        /// <summary>
        /// The total number of AA points you have
        /// </summary>
        public IntType AAPointsTotal => GetMember<IntType>("AAPointsTotal");

        /// <summary>
        /// The total number of AA Vitality you have
        /// </summary>
        public IntType AAVitality => GetMember<IntType>("AAVitality");

        /// <summary>
        /// The doability button number that the skill name is on, or the skill name assigned to a doability button
        /// </summary>
        public IndexedMember<StringType, int, IntType, string> Ability { get; }

        /// <summary>
        /// Accuracy bonus from gear and spells
        /// </summary>
        public IntType AccuracyBonus => GetMember<IntType>("AccuracyBonus");

        /// <summary>
        /// Returns a spell if melee discipline is active.
        /// </summary>
        public SpellType ActiveDisc => GetMember<SpellType>("ActiveDisc");

        /// <summary>
        /// If Tribute is active, how much it is costing you every 10 minutes. Returns NULL if tribute is inactive.
        /// </summary>
        public IntType ActiveFavorCost => GetMember<IntType>("ActiveFavorCost");

        /// <summary>
        /// Buff from the Aegolism line
        /// </summary>
        public BuffType Aego => GetMember<BuffType>("Aego");

        /// <summary>
        /// Spawn info for aggro lock player
        /// </summary>
        public SpawnType AggroLock => GetMember<SpawnType>("AggroLock");

        /// <summary>
        /// Agility
        /// </summary>
        public IntType AGI => GetMember<IntType>("AGI");

        /// <summary>
        /// Quantity of an alt currency by name or number
        /// </summary>
        public IndexedMember<IntType, int, IntType, string> AltCurrency;

        [Obsolete]
        public BoolType AltTimerReady => GetMember<BoolType>("AltTimerReady");

        /// <summary>
        /// Am I the group leader?
        /// </summary>
        public StringType AmIGroupLeader => GetMember<StringType>("AmIGroupLeader");

        /// <summary>
        /// Returns true/false if the assist is complete
        /// </summary>
        public BoolType AssistComplete => GetMember<BoolType>("AssistComplete");

        /// <summary>
        /// Attack bonus from gear and spells
        /// </summary>
        public IntType AttackBonus => GetMember<IntType>("AttackBonus");

        /// <summary>
        /// Your Attack Speed. No haste spells/items = AttackSpeed of 100. A 41% haste item will result in an AttackSpeed of 141. This variable does not take into account spell or song haste
        /// </summary>
        public IntType AttackSpeed => GetMember<IntType>("AttackSpeed");

        /// <summary>
        /// Is Autofire on?
        /// </summary>
        public BoolType AutoFire => GetMember<BoolType>("AutoFire");

        /// <summary>
        /// Autoskill by number
        /// </summary>
        public IndexedMember<SkillType, int> AutoSkill;

        /// <summary>
        /// Avoidance bonus from gear/spells
        /// </summary>
        public IntType AvoidanceBonus => GetMember<IntType>("AvoidanceBonus");

        /// <summary>
        /// Item in this bankslot #
        /// </summary>
        public ItemType Bank => GetMember<ItemType>("Bank");

        /// <summary>
        /// True if you're currently playing a bard song
        /// </summary>
        public BoolType BardSongPlaying => GetMember<BoolType>("BardSongPlaying");

        /// <summary>
        /// Base agility
        /// </summary>
        public IntType BaseAGI => GetMember<IntType>("BaseAGI");

        /// <summary>
        /// Base charisma
        /// </summary>
        public IntType BaseCHA => GetMember<IntType>("BaseCHA");

        /// <summary>
        /// Base dexterity
        /// </summary>
        public IntType BaseDEX => GetMember<IntType>("BaseDEX");

        /// <summary>
        /// Base intelligence
        /// </summary>
        public IntType BaseINT => GetMember<IntType>("BaseINT");

        /// <summary>
        /// Base stamina
        /// </summary>
        public IntType BaseSTA => GetMember<IntType>("BaseSTA");

        /// <summary>
        /// Base strength
        /// </summary>
        public IntType BaseSTR => GetMember<IntType>("BaseSTR");

        /// <summary>
        /// Base wisdom
        /// </summary>
        public IntType BaseWIS => GetMember<IntType>("BaseWIS");

        /// <summary>
        /// First beneficial buff on character
        /// </summary>
        public TargetBuffType Beneficial => GetMember<TargetBuffType>("Beneficial");

        /// <summary>
        /// Bind location, valid indexes are 0 - 4
        /// </summary>
        public IndexedMember<WorldLocationType, int> BoundLocation { get; }


        /// <summary>
        /// Buff from the Brells line
        /// </summary>
        public BuffType Brells => GetMember<BuffType>("Brells");

        /// <summary>
        /// Career favor/tribute
        /// </summary>
        public Int64Type CareerFavor => GetMember<Int64Type>("CareerFavor");

        /// <summary>
        /// Total cash on your character, expressed in coppers (eg. if you are carrying 100pp, Cash will return 100000)
        /// </summary>
        public IntType Cash => GetMember<IntType>("Cash");

        /// <summary>
        /// Total cash in your bank, expressed in coppers
        /// </summary>
        public IntType CashBank => GetMember<IntType>("CashBank");

        /// <summary>
        /// Charisma
        /// </summary>
        public IntType CHA => GetMember<IntType>("CHA");
        
        /// <summary>
        /// Debuff with a charm SPA
        /// </summary>
        public BuffType Charmed => GetMember<BuffType>("Charmed");

        /// <summary>
        /// Chronobines on your character
        /// </summary>
        public IntType Chronobines => GetMember<IntType>("Chronobines");

        /// <summary>
        /// Clairvoyance Bonus
        /// </summary>
        public IntType ClairvoyanceBonus => GetMember<IntType>("ClairvoyanceBonus");
        
        /// <summary>
        /// Buff from the Clarity line
        /// </summary>
        public BuffType Clarity => GetMember<BuffType>("Clarity");

        /// <summary>
        /// In combat?
        /// </summary>
        public BoolType Combat => GetMember<BoolType>("Combat");

        /// <summary>
        /// Combat Effects bonus from gear and spells
        /// </summary>
        public IntType CombatEffectsBonus => GetMember<IntType>("CombatEffectsBonus");

        /// <summary>
        /// Returns one of the following: COMBAT, DEBUFFED, COOLDOWN, ACTIVE, RESTING, UNKNOWN
        /// </summary>
        public StringType CombatState => GetMember<StringType>("CombatState");

        /// <summary>
        /// Commemorative Coins (alt currency)
        /// </summary>
        public IntType Commemoratives => GetMember<IntType>("Commemoratives");

        /// <summary>
        /// Copper on your character
        /// </summary>
        public IntType Copper => GetMember<IntType>("Copper");

        /// <summary>
        /// Copper in your bank
        /// </summary>
        public IntType CopperBank => GetMember<IntType>("CopperBank");

        /// <summary>
        /// The buff on you, if any, that is increasing your corruption counter
        /// </summary>
        public BuffType Corrupted => GetMember<BuffType>("Corrupted");

        /// <summary>
        /// Number of buffs you have, not including short duration buffs (songs)
        /// </summary>
        public IntType CountBuffs => GetMember<IntType>("CountBuffs");

        /// <summary>
        /// Total number of corruption counters
        /// </summary>
        public IntType CountersCorruption => GetMember<IntType>("CountersCorruption");

        /// <summary>
        /// Total number of curse counters
        /// </summary>
        public IntType CountersCurse => GetMember<IntType>("CountersCurse");

        /// <summary>
        /// Total number of disease counters
        /// </summary>
        public IntType CountersDisease => GetMember<IntType>("CountersDisease");

        /// <summary>
        /// Total number of poison counters
        /// </summary>
        public IntType CountersPoison => GetMember<IntType>("CountersPoison");

        /// <summary>
        /// Number of short duration buffs (songs) you have
        /// </summary>
        public IntType CountSongs => GetMember<IntType>("CountSongs");

        /// <summary>
        /// Debuff from the Cripple line
        /// </summary>
        public BuffType Crippled => GetMember<BuffType>("Crippled");

        /// <summary>
        /// Current endurance
        /// </summary>
        public new IntType CurrentEndurance => GetMember<IntType>("CurrentEndurance");

        /// <summary>
        /// Current favor/tribute
        /// </summary>
        public Int64Type CurrentFavor => GetMember<Int64Type>("CurrentFavor");
        
        /// <summary>
        /// Current hit points
        /// </summary>
        public new IntType CurrentHPs => GetMember<IntType>("CurrentHPs");

        /// <summary>
        /// Current mana
        /// </summary>
        public new IntType CurrentMana => GetMember<IntType>("CurrentMana");

        /// <summary>
        /// Current weight
        /// </summary>
        public IntType CurrentWeight => GetMember<IntType>("CurrentWeight");

        /// <summary>
        /// The buff on you, if any, that is increasing your cursed counter
        /// </summary>
        public BuffType Cursed => GetMember<BuffType>("Cursed");

        /// <summary>
        /// Copper on your cursor
        /// </summary>
        public IntType CursorCopper => GetMember<IntType>("CursorCopper");

        /// <summary>
        /// Gold on your cursor
        /// </summary>
        public IntType CursorGold => GetMember<IntType>("CursorGold");

        /// <summary>
        /// Krono on your cursor
        /// </summary>
        public IntType CursorKrono => GetMember<IntType>("CursorKrono");

        /// <summary>
        /// Platinum on your cursor
        /// </summary>
        public IntType CursorPlatinum => GetMember<IntType>("CursorPlatinum");

        /// <summary>
        /// Silver on your cursor
        /// </summary>
        public IntType CursorSilver => GetMember<IntType>("CursorSilver");

        /// <summary>
        /// Damage Shield bonus from gear and spells
        /// </summary>
        public IntType DamageShieldBonus => GetMember<IntType>("DamageShieldBonus");

        /// <summary>
        /// Damage Shield Mitigation bonus from gear and spells
        /// </summary>
        public IntType DamageShieldMitigationBonus => GetMember<IntType>("DamageShieldMitigationBonus");

        /// <summary>
        /// Damage absorption remaining (eg. from Rune-type spells)
        /// </summary>
        public IntType Dar => GetMember<IntType>("Dar");

        /// <summary>
        /// Dexterity
        /// </summary>
        public IntType DEX => GetMember<IntType>("DEX");

        /// <summary>
        /// The buff on you, if any, that is increasing your disease counter
        /// </summary>
        public BuffType Diseased => GetMember<BuffType>("Diseased");

        /// <summary>
        /// DoT Shield bonus from gear and spells
        /// </summary>
        public IntType DoTShieldBonus => GetMember<IntType>("DoTShieldBonus");

        /// <summary>
        /// Doubloons (alt currency)
        /// </summary>
        public IntType Doubloons => GetMember<IntType>("Doubloons");

        /// <summary>
        /// Ticks remaining before able to rest
        /// </summary>
        public TicksType Downtime => GetMember<TicksType>("Downtime");

        /// <summary>
        /// Drunkenness level (0 - 200)
        /// </summary>
        public IntType Drunk => GetMember<IntType>("Drunk");

        /// <summary>
        /// The buff on you, if any, that is increasing your damage shield
        /// </summary>
        public BuffType DSed => GetMember<BuffType>("DSed");

        /// <summary>
        /// Ebon Crystals (alt currency)
        /// </summary>
        public IntType EbonCrystals => GetMember<IntType>("EbonCrystals");

        /// <summary>
        /// Endurance bonus from gear and spells
        /// </summary>
        public IntType EnduranceBonus => GetMember<IntType>("EnduranceBonus");

        /// <summary>
        /// Endurance regen from the last tick
        /// </summary>
        public IntType EnduranceRegen => GetMember<IntType>("EnduranceRegen");

        /// <summary>
        /// Endurance regen bonus
        /// </summary>
        public IntType EnduranceRegenBonus => GetMember<IntType>("EnduranceRegenBonus");

        /// <summary>
        /// Energy Crystals (alt currency)
        /// </summary>
        public IntType EnergyCrystals => GetMember<IntType>("EnergyCrystals");

        /// <summary>
        /// Experience (out of 330)
        /// </summary>
        public Int64Type Exp => GetMember<Int64Type>("Exp");

        /// <summary>
        /// Bit mask of expansions owned
        /// </summary>
        public IntType ExpansionFlags => GetMember<IntType>("ExpansionFlags");

        /// <summary>
        /// Faycitum (alt currency)
        /// </summary>
        public IntType Faycites => GetMember<IntType>("Faycites");

        /// <summary>
        /// Fellowship character is in
        /// </summary>
        public FellowshipType Fellowship => GetMember<FellowshipType>("Fellowship");

        /// <summary>
        /// Fists of Bayle (alt currency)
        /// </summary>
        public IntType Fists => GetMember<IntType>("Fists");

        /// <summary>
        /// Buff from the Focus line
        /// </summary>
        public BuffType Focus => GetMember<BuffType>("Focus");

        /// <summary>
        /// Number of free buff slots remaining
        /// </summary>
        public IntType FreeBuffSlots => GetMember<IntType>("FreeBuffSlots");

        /// <summary>
        /// Number of free inventory slots remaining
        /// </summary>
        public IntType FreeInventory => GetMember<IntType>("FreeInventory");

        /// <summary>
        /// The gem number that a spell name is memorized in, or the spell in a gem number
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> Gem { get; }

        /// <summary>
        /// Recast time remaining on a spell gem by number or spell name
        /// </summary>
        public IndexedMember<TimeStampType, int, TimeStampType, string> GemTimer { get; }

        /// <summary>
        /// Gold on your character
        /// </summary>
        public IntType Gold => GetMember<IntType>("Gold");

        /// <summary>
        /// Gold in your bank
        /// </summary>
        public IntType GoldBank => GetMember<IntType>("GoldBank");

        /// <summary>
        /// Target of the group's main assist
        /// </summary>
        public SpawnType GroupAssistTarget => GetMember<SpawnType>("GroupAssistTarget");

        /// <summary>
        /// True if in a group with a player or a mercenary
        /// </summary>
        public BoolType Grouped => GetMember<BoolType>("Grouped");

        /// <summary>
        /// Not working
        /// </summary>
        [Obsolete]
        public StringType GroupList => GetMember<StringType>("GroupList");

        /// <summary>
        /// Current group marked NPC (1 - 3)
        /// </summary>
        public IndexedMember<SpawnType, int> GroupMarkNPC { get; }

        /// <summary>
        /// Number of characters in group, including yourself. Returns null if not in a group
        /// </summary>
        public IntType GroupSize => GetMember<IntType>("GroupSize");

        /// <summary>
        /// Buff with a growth SPA
        /// </summary>
        public BuffType Growth => GetMember<BuffType>("Growth");

        /// <summary>
        /// ID number of your guild
        /// </summary>
        public Int64Type GuildID => GetMember<Int64Type>("GuildID");

        /// <summary>
        /// Total points earned in Deepest Guk LDoN missions
        /// </summary>
        public IntType GukEarned => GetMember<IntType>("GukEarned");

        /// <summary>
        /// Total Combined Haste (worn and spell) as shown in Inventory Window stats
        /// </summary>
        public IntType Haste => GetMember<IntType>("Haste");

        /// <summary>
        /// Buff from the Haste line
        /// </summary>
        public BuffType Hasted => GetMember<BuffType>("Hasted");

        /// <summary>
        /// Returns TRUE/FALSE if you have that expansion #
        /// </summary>
        public IndexedMember<BoolType, int> HaveExpansion { get; }

        /// <summary>
        /// Total Heal Amount bonus from gear
        /// </summary>
        public IntType HealAmountBonus => GetMember<IntType>("HealAmountBonus");

        /// <summary>
        /// Total Heroic Agility bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases the chance to dodge an attack, grants a bonus to defense skill, and reduces falling damage
        /// </summary>
        public IntType HeroicAGIBonus => GetMember<IntType>("HeroicAGIBonus");

        /// <summary>
        /// Total Heroic Charisma bonus from gear
        /// Improves reaction rolls with some NPCs and increases the amount of faction you gain or lose when faction is adjusted
        /// </summary>
        public IntType HeroicCHABonus => GetMember<IntType>("HeroicCHABonus");

        /// <summary>
        /// Total Heroic Dexterity bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by ranged attacks, improves chance to successfully assassinate or headshot, and improves the chance to riposte, block, and parry incoming attacks
        /// </summary>
        public IntType HeroicDEXBonus => GetMember<IntType>("HeroicDEXBonus");

        /// <summary>
        /// Total Heroic Intelligence bonus from gear
        /// Increases mana pool, mana regen, and the maximum amount of mana regen an int-based caster can have
        /// It requires +25 heroic intel to gain a single point of +mana regeneration
        /// </summary>
        public IntType HeroicINTBonus => GetMember<IntType>("HeroicINTBonus");

        /// <summary>
        /// Total Heroic Stamina bonus from gear
        /// Increases hit point pool, hit point regen, and the maximum amount of hit point regen a character can have
        /// Also increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have.
        /// </summary>
        public IntType HeroicSTABonus => GetMember<IntType>("HeroicSTABonus");

        /// <summary>
        /// Total Heroic Strength bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by melee attacks and improves the bonus granted to armor class while using a shield
        /// (10 Heroic STR increases each Melee Hit by 1 point)
        /// </summary>
        public IntType HeroicSTRBonus => GetMember<IntType>("HeroicSTRBonus");

        /// <summary>
        /// Total Heroic Wisdom bonus from gear
        /// Increases mana pool, mana regen, and the maximum amount of mana regen a wis-based caster can have
        /// </summary>
        public IntType HeroicWISBonus => GetMember<IntType>("HeroicWISBonus");

        /// <summary>
        /// Hit point bonus from gear and spells
        /// </summary>
        public IntType HPBonus => GetMember<IntType>("HPBonus");

        /// <summary>
        /// Hit point regeneration from last tick
        /// </summary>
        public IntType HPRegen => GetMember<IntType>("HPRegen");

        /// <summary>
        /// HP regen bonus from gear and spells
        /// </summary>
        public IntType HPRegenBonus => GetMember<IntType>("HPRegenBonus");

        /// <summary>
        /// Hunger level
        /// </summary>
        public IntType Hunger => GetMember<IntType>("Hunger");

        /// <summary>
        /// Buff from the Hybrid HP line TODO What is this
        /// </summary>
        public BuffType HybridHP => GetMember<BuffType>("HybridHP");

        /// <summary>
        /// Are you in an instanced zone?
        /// </summary>
        public BoolType InInstance => GetMember<BoolType>("InInstance");

        /// <summary>
        /// Instance you are in
        /// </summary>
        public IntType Instance => GetMember<IntType>("Instance");

        /// <summary>
        /// Intelligence
        /// </summary>
        public IntType INT => GetMember<IntType>("INT");

        /// <summary>
        /// An item from your inventory by slot name or number
        /// </summary>
        public IndexedMember<ItemType, string, ItemType, int> Inventory { get; }

        /// <summary>
        /// Is an item ready to cast?
        /// </summary>
        public IndexedMember<BoolType> ItemReady { get; }

        /// <summary>
        /// Krono on your character
        /// </summary>
        public IntType Krono => GetMember<IntType>("Krono");

        /// <summary>
        /// Level of Delegate MA of the current group leader (not your own ability level)
        /// </summary>
        public IntType LADelegateMA => GetMember<IntType>("LADelegateMA");

        /// <summary>
        /// Level of Delegate Mark NPC of the current group leader (not your own ability level)
        /// </summary>
        public IntType LADelegateMarkNPC => GetMember<IntType>("LADelegateMarkNPC");

        /// <summary>
        /// Level of Find Path PC of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAFindPathPC => GetMember<IntType>("LAFindPathPC");

        /// <summary>
        /// Level of Health Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAHealthEnhancement => GetMember<IntType>("LAHealthEnhancement");

        /// <summary>
        /// Level of Health Regen of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAHealthRegen => GetMember<IntType>("LAHealthRegen");

        /// <summary>
        /// Level of HoTT of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAHoTT => GetMember<IntType>("LAHoTT");

        /// <summary>
        /// Level of Inspect Buffs of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAInspectBuffs => GetMember<IntType>("LAInspectBuffs");

        /// <summary>
        /// Level of Mana Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAManaEnhancement => GetMember<IntType>("LAManaEnhancement");

        /// <summary>
        /// Level of Mark NPC of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAMarkNPC => GetMember<IntType>("LAMarkNPC");

        /// <summary>
        /// Language number by name, or name by number
        /// </summary>
        public IndexedMember<IntType, string, StringType, int> Language { get; } = new IndexedMember<IntType, string, StringType, int>(this, "Language");

        /// <summary>
        /// Language skill by name or number
        /// </summary>
        public IndexedMember<IntType> LanguageSkill { get; }

        /// <summary>
        /// Level of NPC Health of the current group leader (not your own ability level)
        /// </summary>
        public IntType LANPCHealth => GetMember<IntType>("LANPCHealth");

        /// <summary>
        /// Level of Offense Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public IntType LAOffenseEnhancement => GetMember<IntType>("LAOffenseEnhancement");

        /// <summary>
        /// Size of your largest free inventory slot (4 = Giant)
        /// </summary>
        public IntType LargestFreeInventory => GetMember<IntType>("LargestFreeInventory");

        /// <summary>
        /// Level of Spell Awareness of the current group leader (not your own ability level)
        /// </summary>
        public IntType LASpellAwareness => GetMember<IntType>("LASpellAwareness");

        /// <summary>
        /// Total points earned across all LDoN missions
        /// </summary>
        public IntType LDoNPoints => GetMember<IntType>("LDoNPoints");

        /// <summary>
        /// Debuff from the Malo line
        /// </summary>
        public BuffType Maloed => GetMember<BuffType>("Maloed");

        /// <summary>
        /// Mana bonus from gear and spells
        /// </summary>
        public IntType ManaBonus => GetMember<IntType>("ManaBonus");

        /// <summary>
        /// Mana regeneration from last tick
        /// </summary>
        public IntType ManaRegen => GetMember<IntType>("ManaRegen");

        /// <summary>
        /// Mana regen bonus from gear and spells
        /// </summary>
        public IntType ManaRegenBonus => GetMember<IntType>("ManaRegenBonus");

        /// <summary>
        /// Maximum number of buffs you can have
        /// </summary>
        public IntType MaxBuffSlots => GetMember<IntType>("MaxBuffSlots");

        /// <summary>
        /// Max endurance
        /// </summary>
        public new IntType MaxEndurance => GetMember<IntType>("MaxEndurance");

        /// <summary>
        /// Max hit points
        /// </summary>
        public new IntType MaxHPs => GetMember<IntType>("MaxHPs");

        /// <summary>
        /// Max mana
        /// </summary>
        public new IntType MaxMana => GetMember<IntType>("MaxMana");

        /// <summary>
        /// Mercenary AA experience, out of 1000
        /// </summary>
        public Int64Type MercAAExp => GetMember<Int64Type>("MercAAExp");

        /// <summary>
        /// Number of mercenary AA points available to spend
        /// </summary>
        public IntType MercAAPoints => GetMember<IntType>("MercAAPoints");

        /// <summary>
        /// Number of mercenary AA points spent
        /// </summary>
        public IntType MercAAPointsSpent => GetMember<IntType>("MercAAPointsSpent");

        /// <summary>
        /// The state of your Mercenary, ACTIVE, SUSPENDED, or UNKNOWN (If it's dead). Returns NULL if you do not have a Mercenary.
        /// </summary>
        public MercenaryType Mercenary => GetMember<MercenaryType>("Mercenary");

        /// <summary>
        /// Current active mercenary stance as a string, default is NULL.
        /// </summary>
        public StringType MercenaryStance => GetMember<StringType>("MercenaryStance");

        /// <summary>
        /// Merc list description by name, or number by description
        /// </summary>
        public IndexedMember<IntType, string, StringType, int> MercList;

        /// <summary>
        /// Debuff from the Mez line
        /// </summary>
        public BuffType Mezzed => GetMember<BuffType>("Mezzed");

        /// <summary>
        /// Total points earned in Miragul's LDoN missions
        /// </summary>
        public IntType MirEarned => GetMember<IntType>("MirEarned");

        /// <summary>
        /// Total points earned in Mistmoore LDoN missions
        /// </summary>
        public IntType MMEarned => GetMember<IntType>("MMEarned");

        /// <summary>
        /// Moving? (including strafe)
        /// </summary>
        public new BoolType Moving => GetMember<BoolType>("Moving");

        /// <summary>
        /// First name
        /// </summary>
        public new StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Nobles (alt currency)
        /// </summary>
        public IntType Nobles => GetMember<IntType>("Nobles");

        /// <summary>
        /// Returns the amount of spell gems your toon has
        /// </summary>
        public IntType NumGems => GetMember<IntType>("NumGems");

        /// <summary>
        /// Orux (alt currency)
        /// </summary>
        public IntType Orux => GetMember<IntType>("Orux");

        /// <summary>
        /// Current AA experience as a percentage
        /// </summary>
        public FloatType PctAAExp => GetMember<FloatType>("PctAAExp");

        /// <summary>
        /// Current AA vitality as a percentage
        /// </summary>

        public FloatType PctAAVitality => GetMember<FloatType>("PctAAVitality");

        /// <summary>
        /// Your aggro percentage
        /// </summary>
        public IntType PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Current endurance as a percentage
        /// </summary>
        public new IntType PctEndurance => GetMember<IntType>("PctEndurance");

        /// <summary>
        /// Current experience as a percentage
        /// </summary>
        public FloatType PctExp => GetMember<FloatType>("PctExp");

        /// <summary>
        /// Percentage of your experience going to AA
        /// </summary>
        public IntType PctExpToAA => GetMember<IntType>("PctExpToAA");

        /// <summary>
        /// Current hit points as a percentage
        /// </summary>
        public new IntType PctHPs => GetMember<IntType>("PctHPs");

        /// <summary>
        /// Current mana as a percentage
        /// </summary>
        public new IntType PctMana => GetMember<IntType>("PctMana");

        /// <summary>
        /// Current mercenary AA experience as a oercentage
        /// </summary>
        public FloatType PctMercAAExp => GetMember<FloatType>("PctMercAAExp");

        /// <summary>
        /// Current vitality as a percentage
        /// </summary>
        public FloatType PctVitality => GetMember<FloatType>("PctVitality");

        /// <summary>
        /// A buff on your pet by slot number, or a slot number by buff name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> PetBuff { get; }

        /// <summary>
        /// Phosphenes (alt currency)
        /// </summary>
        public IntType Phosphenes => GetMember<IntType>("Phosphenes");

        /// <summary>
        /// Phosphites (alt currency)
        /// </summary>
        public IntType Phosphites => GetMember<IntType>("Phosphites");

        /// <summary>
        /// Pieces of Eight (alt currency)
        /// </summary>
        public IntType PiecesofEight => GetMember<IntType>("PiecesofEight");

        /// <summary>
        /// Platinum on your character
        /// </summary>
        public IntType Platinum => GetMember<IntType>("Platinum");

        /// <summary>
        /// Platinum in your bank
        /// </summary>
        public IntType PlatinumBank => GetMember<IntType>("PlatinumBank");

        /// <summary>
        /// Platinum in your shared bank
        /// </summary>
        public IntType PlatinumShared => GetMember<IntType>("PlatinumShared");

        /// <summary>
        /// The buff on you, if any, that is increasing your poison counter
        /// </summary>
        public BuffType Poisoned => GetMember<BuffType>("Poisoned");

        /// <summary>
        /// Buff from the Pred line
        /// </summary>
        public BuffType Pred => GetMember<BuffType>("Pred");

        /// <summary>
        /// Radiant Crystals (alt currency)
        /// </summary>
        public IntType RadiantCrystals => GetMember<IntType>("RadiantCrystals");

        /// <summary>
        /// Current raid assist target (1-3)
        /// </summary>
        public IndexedMember<SpawnType, int> RaidAssistTarget { get; }

        /// <summary>
        /// Current raid marked NPC (1-3)
        /// </summary>
        public IndexedMember<SpawnType, int> RaidMarkNPC { get; }

        /// <summary>
        /// Ranged attack ready?
        /// </summary>
        public BoolType RangedReady => GetMember<BoolType>("RangedReady");

        /// <summary>
        /// Buff from the Regen line
        /// </summary>
        public BuffType Regen => GetMember<BuffType>("Regen");

        /// <summary>
        /// Buff with a reverse damage shield SPA
        /// </summary>
        public BuffType RevDSed => GetMember<BuffType>("RevDSed");

        /// <summary>
        /// Buff with a root SPA
        /// </summary>
        public BuffType Rooted => GetMember<BuffType>("Rooted");

        /// <summary>
        /// Total points earned in Rujurkian LDoN missions
        /// </summary>
        public IntType RujEarned => GetMember<IntType>("RujEarned");

        /// <summary>
        /// Do I have auto-run turned on?
        /// </summary>
        public BoolType Running => GetMember<BoolType>("Running");

        /// <summary>
        /// Buff from the Spiritual Enlightenment line
        /// </summary>
        public BuffType SE => GetMember<BuffType>("SE");

        /// <summary>
        /// Spawn that has secondary aggro
        /// </summary>
        public SpawnType SecondaryAggroPlayer => GetMember<SpawnType>("SecondaryAggroPlayer");

        /// <summary>
        /// Secondary aggro as a percentage
        /// </summary>
        public IntType SecondaryPctAggro => GetMember<IntType>("SecondaryPctAggro");

        /// <summary>
        /// Shielding bonus from gear and spells
        /// </summary>
        public IntType ShieldingBonus => GetMember<IntType>("ShieldingBonus");
        
        /// <summary>
        /// Buff from the Shining line
        /// </summary>
        public BuffType Shining => GetMember<BuffType>("Shining");

        /// <summary>
        /// Am I Shrouded?
        /// </summary>
        public BoolType Shrouded => GetMember<BoolType>("Shrouded");

        /// <summary>
        /// Silver on your character
        /// </summary>
        public IntType Silver => GetMember<IntType>("Silver");

        /// <summary>
        /// Silver in your bank
        /// </summary>
        public IntType SilverBank => GetMember<IntType>("SilverBank");

        /// <summary>
        /// Skill level by name or number
        /// </summary>
        public IndexedMember<IntType, string, IntType, int> Skill { get; }

        /// <summary>
        /// Skill base level by name or number
        /// </summary>
        public IndexedMember<IntType, string, IntType, int> SkillBase { get; }

        /// <summary>
        /// Skill cap by name or number
        /// </summary>
        public IndexedMember<IntType, string, IntType, int> SkillCap { get; }

        /// <summary>
        /// Buff from the Skin line
        /// </summary>
        public BuffType Skin => GetMember<BuffType>("Skin");

        /// <summary>
        /// Debuff with a slow SPA
        /// </summary>
        public BuffType Slowed => GetMember<BuffType>("Slowed");

        /// <summary>
        /// Debuff with a snare SPA
        /// </summary>
        public BuffType Snared => GetMember<BuffType>("Snared");

        /// <summary>
        /// Song (short buff) by name or slot number
        /// </summary>
        public IndexedMember<BuffType, string, BuffType, int> Song {get; }

        /// <summary>
        /// Returns the total amount of an SPA your character has
        /// </summary>
        public IndexedMember<IntType, int> SPA { get; }

        /// <summary>
        /// The character's spawn
        /// </summary>
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");

        /// <summary>
        /// Spell Damage bonus
        /// </summary>
        public IntType SpellDamageBonus => GetMember<IntType>("SpellDamageBonus");

        /// <summary>
        /// Returns TRUE if you have a spell in cooldown and FALSE when not.
        /// </summary>
        public BoolType SpellInCooldown => GetMember<BoolType>("SpellInCooldown");

        /// <summary>
        /// Indiciates if a spell is ready, by spell name or gem number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> SpellReady { get; }

        /// <summary>
        /// Spell Shield bonus from gear and spells
        /// </summary>
        public IntType SpellShieldBonus => GetMember<IntType>("SpellShieldBonus");

        /// <summary>
        /// Stamina
        /// </summary>
        public IntType STA => GetMember<IntType>("STA");

        /// <summary>
        /// Strength
        /// </summary>
        public IntType STR => GetMember<IntType>("STR");

        /// <summary>
        /// Buff from the Strength line
        /// </summary>
        public BuffType Strength => GetMember<BuffType>("Strength");

        /// <summary>
        /// Strikethrough bonus from gear and spells
        /// </summary>
        public IntType StrikeThroughBonus => GetMember<IntType>("StrikeThroughBonus");

        /// <summary>
        /// Am I stunned?
        /// </summary>
        public new BoolType Stunned => GetMember<BoolType>("Stunned");

        /// <summary>
        /// Stun Resist bonus from gear and spells
        /// </summary>
        public IntType StunResistBonus => GetMember<IntType>("StunResistBonus");

        /// <summary>
        /// Subscription type GOLD, FREE, (Silver?)
        /// </summary>
        public StringType Subscription => GetMember<StringType>("Subscription");

        /// <summary>
        /// Buff from the Spiritual Vivacity line
        /// </summary>
        public BuffType SV => GetMember<BuffType>("SV");

        /// <summary>
        /// Your character's lowest resist
        /// </summary>
        public IntType svChromatic => GetMember<IntType>("svChromatic");

        /// <summary>
        /// Cold resist
        /// </summary>
        public IntType svCold => GetMember<IntType>("svCold");

        /// <summary>
        /// Corruption resist
        /// </summary>
        public IntType svCorruption => GetMember<IntType>("svCorruption");

        /// <summary>
        /// Disease resist
        /// </summary>
        public IntType svDisease => GetMember<IntType>("svDisease");

        /// <summary>
        /// Fire resist
        /// </summary>
        public IntType svFire => GetMember<IntType>("svFire");

        /// <summary>
        /// Magic resist
        /// </summary>
        public IntType svMagic => GetMember<IntType>("svMagic");

        /// <summary>
        /// Poison resist
        /// </summary>
        public IntType svPoison => GetMember<IntType>("svPoison");

        /// <summary>
        /// The average of your character's resists
        /// </summary>
        public IntType svPrismatic => GetMember<IntType>("svPrismatic");

        /// <summary>
        /// Buff from the Symbol line
        /// </summary>
        public BuffType Symbol => GetMember<BuffType>("Symbol");

        /// <summary>
        /// Total points earned in Takish LDoN missions
        /// </summary>
        public IntType TakEarned => GetMember<IntType>("TakEarned");

        /// <summary>
        /// Your target's target
        /// </summary>
        public new SpawnType TargetOfTarget => GetMember<SpawnType>("TargetOfTarget");

        /// <summary>
        /// Debuff from the Tash line
        /// </summary>
        public BuffType Tashed => GetMember<BuffType>("Tashed");

        /// <summary>
        /// Thirst level
        /// </summary>
        public IntType Thirst => GetMember<IntType>("Thirst");

        /// <summary>
        /// Total number of counters on you
        /// </summary>
        public IntType TotalCounters => GetMember<IntType>("TotalCounters");

        /// <summary>
        /// Personal tribute currently active?
        /// </summary>
        public BoolType TributeActive => GetMember<BoolType>("TributeActive");

        /// <summary>
        /// Personal tribute timer
        /// </summary>
        public TicksType TributeTimer => GetMember<TicksType>("TributeTimer");

        /// <summary>
        /// Using advanced looting?
        /// </summary>
        public BoolType UseAdvancedLooting => GetMember<BoolType>("UseAdvancedLooting");

        /// <summary>
        /// Current vitality
        /// </summary>
        public Int64Type Vitality => GetMember<Int64Type>("Vitality");

        /// <summary>
        /// Wisdom
        /// </summary>
        public IntType WIS => GetMember<IntType>("WIS");

        /// <summary>
        /// Number of mobs on your XTarget, excluding your current target, that have less than the supplied % of aggro on you
        /// </summary>
        public IndexedMember<IntType, int> XTAggroCount { get; }

        /// <summary>
        /// Returns a spawn from your XTarget by index (1 - 13)
        /// </summary>
        public IndexedMember<XTargetType, int> XTarget { get; }

        /// <summary>
        /// Number of spawns on your XTarget (note this is .NET only, equivalent in MQ2 XTarget without an index
        /// </summary>
        public IntType XTargetCount => GetMember<IntType>("XTarget");

        /// <summary>
        /// Number of slots available in your XTarget window
        /// </summary>
        public IntType XTargetSlots => GetMember<IntType>("XTargetSlots");

        /// <summary>
        /// Number of spawns in auto hater slots in your XTarget
        /// </summary>
        public IntType XTHaterCount => GetMember<IntType>("XTHaterCount");

        /// <summary>
        /// Zone you are bound in
        /// </summary>
        public ZoneType ZoneBound => GetMember<ZoneType>("ZoneBound");

        /// <summary>
        /// X location of your bind point
        /// </summary>
        public FloatType ZoneBoundX => GetMember<FloatType>("ZoneBoundX");

        /// <summary>
        /// Y location of your bind point
        /// </summary>
        public FloatType ZoneBoundY => GetMember<FloatType>("ZoneBoundY");

        /// <summary>
        /// Z location of your bind point
        /// </summary>
        public FloatType ZoneBoundZ => GetMember<FloatType>("ZoneBoundZ");

        /// <summary>
        /// Am I zoning?
        /// </summary>
        public BoolType Zoning => GetMember<BoolType>("Zoning");
    }
}