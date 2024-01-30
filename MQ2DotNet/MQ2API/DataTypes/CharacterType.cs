﻿using System;
using JetBrains.Annotations;
using static MQ2DotNet.MQ2API.MQ2DataType;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the local player character
    /// </summary>
    [PublicAPI]
    [MQ2Type("character")]
    public class CharacterType : SpawnType // Inheritance won't work, use Spawn
    {
        internal CharacterType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Language = new IndexedStringMember<int, IntType, string>(this, "Language");
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
            MercList = new IndexedStringMember<int, IntType, string>(this, "MercList");
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
            Book = new IndexedMember<SpellType, int, IntType, string>(this, "Book");
            Spell = new IndexedMember<SpellType, int, IntType, string>(this, "Spell");
            Aura = new IndexedMember<AuraType, string, AuraType, int>(this, "Aura");
            AltAbilityReady = new IndexedMember<BoolType, int, BoolType, string>(this, "AltAbilityReady");
            AltAbilityTimer = new IndexedMember<TimeStampType, int, TimeStampType, string>(this, "AltAbilityTimer");
            AltAbility = new IndexedMember<AltAbilityType, int, AltAbilityType, string>(this, "AltAbility");
            AbilityReady = new IndexedMember<BoolType, int, BoolType, string>(this, "AbilityReady");
            AbilityTimer = new IndexedMember<TimeStampType, int, TimeStampType, string>(this, "AbilityTimer");
            Ability = new IndexedStringMember<int, IntType, string>(this, "Ability");
            Bandolier = new IndexedMember<BandolierType, string, BandolierType, int>(this, "Bandolier");
            Bank = new IndexedMember<ItemType, int>(this, "Bank");
            SharedBank = new IndexedMember<ItemType, int>(this, "SharedBank");
            FreeInventorySlotSize = new IndexedMember<IntType, int>(this, "FreeInventory");
            PersonaLevel = new IndexedMember<IntType>(this, "PersonaLevel");
            MercListInfo = new IndexedStringMember<int, IntType, string>(this, "MercListInfo");
        }

        /// <summary>
        /// Ability with this name or on this button # ready?
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> AbilityReady {  get; }

        /// <summary>
        /// Ability with this name or on this button # ready?
        /// </summary>
        public IndexedMember<TimeStampType, int, TimeStampType, string> AbilityTimer { get; }

        /// <summary>
        /// Returns an alt ability by name or number
        /// </summary>
        public IndexedMember<AltAbilityType, int, AltAbilityType, string> AltAbility { get; }

        /// <summary>
        /// Alt ability ready by name or number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> AltAbilityReady { get; }

        /// <summary>
        /// Alt ability reuse time remaining by name or number
        /// </summary>
        public IndexedMember<TimeStampType, int, TimeStampType, string> AltAbilityTimer { get; }

        /// <summary>
        /// Aura by name or slot #
        /// </summary>
        public IndexedMember<AuraType, string, AuraType, int> Aura { get; }

        /// <summary>
        /// Spell in your spellbook by slot number, or slot in your spellbook by spell name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> Book { get; }

        /// <summary>
        /// Spell in your spellbook by slot number, or slot in your spellbook by spell name
        /// </summary>
        [Obsolete("Use Book instead")]
        public IndexedMember<SpellType, int, IntType, string> Spell { get; }

        /// <summary>
        /// Combat ability spell by number, or number by name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> CombatAbility { get; }

        /// <summary>
        /// Combat ability ready by name or number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> CombatAbilityReady { get; }
        
        /// <summary>
        /// Combat ability reuse time remaining by name or number
        /// </summary>
        public IndexedMember<TicksType, int, TicksType, string> CombatAbilityTimer { get; }

        /// <summary>
        /// AA exp as a raw number out of 330 (330=100%)
        /// </summary>
        public int? AAExp => GetMember<IntType>("AAExp");

        /// <summary>
        /// Unused AA points
        /// </summary>
        public int? AAPoints => GetMember<IntType>("AAPoints");

        /// <summary>
        /// Number of points that have been assigned to an ability
        /// </summary>
        public int? AAPointsAssigned => GetMember<IntType>("AAPointsAssigned");

        /// <summary>
        /// The number of points you have spent on AA abilities
        /// </summary>
        public int? AAPointsSpent => GetMember<IntType>("AAPointsSpent");

        /// <summary>
        /// The total number of AA points you have
        /// </summary>
        public int? AAPointsTotal => GetMember<IntType>("AAPointsTotal");

        /// <summary>
        /// The total number of AA Vitality you have
        /// </summary>
        public long? AAVitality => GetMember<Int64Type>("AAVitality");

        /// <summary>
        /// ?
        /// </summary>
        public long? AAVitalityCap => GetMember<Int64Type>("AAVitalityCap");

        /// <summary>
        /// The doability button number that the skill name is on, or the skill name assigned to a doability button
        /// </summary>
        public IndexedStringMember<int, IntType, string> Ability { get; }

        /// <summary>
        /// Accuracy bonus from gear and spells
        /// </summary>
        public int? AccuracyBonus => GetMember<IntType>("AccuracyBonus");

        /// <summary>
        /// Returns a spell if melee discipline is active.
        /// </summary>
        public SpellType ActiveDisc => GetMember<SpellType>("ActiveDisc");

        /// <summary>
        /// If Tribute is active, how much it is costing you every 10 minutes. Returns NULL if tribute is inactive.
        /// </summary>
        public int? ActiveFavorCost => GetMember<IntType>("ActiveFavorCost");

        /// <summary>
        /// ?
        /// </summary>
        public int? AdoptiveCoin => GetMember<IntType>("AdoptiveCoin");

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
        public int? AGI => GetMember<IntType>("AGI");

        /// <summary>
        /// AirSupply
        /// </summary>
        public int? AirSupply => GetMember<IntType>("AirSupply");

        /// <summary>
        /// Quantity of an alt currency by name or number
        /// </summary>
        public IndexedMember<IntType, int, IntType, string> AltCurrency {  get; }

        /// <summary>
        /// Don't use this
        /// </summary>
        [Obsolete("This is broken and always returns true")]
        public bool AltTimerReady => GetMember<BoolType>("AltTimerReady");

        /// <summary>
        /// Am I the group leader?
        /// </summary>
        public string AmIGroupLeader => GetMember<StringType>("AmIGroupLeader");

        /// <summary>
        /// AncientDraconicCoin
        /// </summary>
        public IntType AncientDraconicCoin => GetMember<IntType>("AncientDraconicCoin");

        /// <summary>
        /// AncientSebilisianCoins
        /// </summary>
        public IntType AncientSebilisianCoins => GetMember<IntType>("AncientSebilisianCoins");

        /// <summary>
        /// Returns true/false if the assist is complete
        /// </summary>
        public bool AssistComplete => GetMember<BoolType>("AssistComplete");

        /// <summary>
        /// Attack bonus from gear and spells
        /// </summary>
        public int? AttackBonus => GetMember<IntType>("AttackBonus");

        /// <summary>
        /// Your Attack Speed. No haste spells/items = AttackSpeed of 100. A 41% haste item will result in an AttackSpeed of 141. This variable does not take into account spell or song haste
        /// </summary>
        public int? AttackSpeed => GetMember<IntType>("AttackSpeed");

        /// <summary>
        /// Current Endurance points. Use <see cref="CurrentEndurance"/>
        /// </summary>
        [Obsolete]
        public int? Endurance => CurrentEndurance;

        /// <summary>
        /// Is Autofire on?
        /// </summary>
        public bool AutoFire => GetMember<BoolType>("AutoFire");

        /// <summary>
        /// Autoskill by number
        /// </summary>
        public IndexedMember<SkillType, int> AutoSkill {  get; }

        /// <summary>
        /// Avoidance bonus from gear/spells
        /// </summary>
        public int? AvoidanceBonus => GetMember<IntType>("AvoidanceBonus");

        /// <summary>
        /// Item in this bankslot #
        /// </summary>
        public IndexedMember<ItemType, int> Bank { get; }

        /// <summary>
        /// Item in this sharedbankslot #
        /// </summary>
        public IndexedMember<ItemType, int> SharedBank { get; }

        /// <summary>
        /// True if you're currently playing a bard song
        /// </summary>
        public bool BardSongPlaying => GetMember<BoolType>("BardSongPlaying");

        /// <summary>
        /// Base agility
        /// </summary>
        public int? BaseAGI => GetMember<IntType>("BaseAGI");

        /// <summary>
        /// Base charisma
        /// </summary>
        public int? BaseCHA => GetMember<IntType>("BaseCHA");

        /// <summary>
        /// Base dexterity
        /// </summary>
        public int? BaseDEX => GetMember<IntType>("BaseDEX");

        /// <summary>
        /// Base intelligence
        /// </summary>
        public int? BaseINT => GetMember<IntType>("BaseINT");

        /// <summary>
        /// Base stamina
        /// </summary>
        public int? BaseSTA => GetMember<IntType>("BaseSTA");

        /// <summary>
        /// Base strength
        /// </summary>
        public int? BaseSTR => GetMember<IntType>("BaseSTR");

        /// <summary>
        /// Base wisdom
        /// </summary>
        public int? BaseWIS => GetMember<IntType>("BaseWIS");

        /// <summary>
        /// First beneficial buff on character
        /// </summary>
        public BuffType Beneficial => GetMember<BuffType>("Beneficial");

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
        public long? CareerFavor => GetMember<Int64Type>("CareerFavor");

        /// <summary>
        /// Total cash on your character, expressed in coppers (eg. if you are carrying 100pp, Cash will return 100000)
        /// </summary>
        public long? Cash => GetMember<Int64Type>("Cash");

        /// <summary>
        /// Total cash in your bank, expressed in coppers
        /// </summary>
        public long? CashBank => GetMember<Int64Type>("CashBank");

        /// <summary>
        /// Charisma
        /// </summary>
        public int? CHA => GetMember<IntType>("CHA");
        
        /// <summary>
        /// Debuff with a charm SPA
        /// </summary>
        public BuffType Charmed => GetMember<BuffType>("Charmed");

        /// <summary>
        /// Chronobines on your character
        /// </summary>
        public int? Chronobines => GetMember<IntType>("Chronobines");

        /// <summary>
        /// Clairvoyance Bonus
        /// </summary>
        public int? ClairvoyanceBonus => GetMember<IntType>("ClairvoyanceBonus");
        
        /// <summary>
        /// Buff from the Clarity line
        /// </summary>
        public BuffType Clarity => GetMember<BuffType>("Clarity");

        /// <summary>
        /// Is auto attack turned on?
        /// </summary>
        public bool Combat => GetMember<BoolType>("Combat");

        /// <summary>
        /// Combat Effects bonus from gear and spells
        /// </summary>
        public int? CombatEffectsBonus => GetMember<IntType>("CombatEffectsBonus");

        /// <summary>
        /// Returns one of the following: COMBAT, DEBUFFED, COOLDOWN, ACTIVE, RESTING, UNKNOWN
        /// </summary>
        public string CombatState => GetMember<StringType>("CombatState");

        /// <summary>
        /// Commemorative Coins (alt currency)
        /// </summary>
        public int? Commemoratives => GetMember<IntType>("Commemoratives");

        /// <summary>
        /// Copper on your character
        /// </summary>
        public int? Copper => GetMember<IntType>("Copper");

        /// <summary>
        /// Copper in your bank
        /// </summary>
        public int? CopperBank => GetMember<IntType>("CopperBank");

        /// <summary>
        /// The buff on you, if any, that is increasing your corruption counter
        /// </summary>
        public BuffType Corrupted => GetMember<BuffType>("Corrupted");

        /// <summary>
        /// Number of buffs you have, not including short duration buffs (songs)
        /// </summary>
        public int? CountBuffs => GetMember<IntType>("CountBuffs");

        /// <summary>
        /// Total number of corruption counters
        /// </summary>
        public long? CountersCorruption => GetMember<Int64Type>("CountersCorruption");

        /// <summary>
        /// Total number of curse counters
        /// </summary>
        public long? CountersCurse => GetMember<Int64Type>("CountersCurse");

        /// <summary>
        /// Total number of disease counters
        /// </summary>
        public long? CountersDisease => GetMember<Int64Type>("CountersDisease");

        /// <summary>
        /// Total number of poison counters
        /// </summary>
        public long? CountersPoison => GetMember<Int64Type>("CountersPoison");

        /// <summary>
        /// Number of short duration buffs (songs) you have
        /// </summary>
        public int? CountSongs => GetMember<IntType>("CountSongs");

        /// <summary>
        /// Debuff from the Cripple line
        /// </summary>
        public BuffType Crippled => GetMember<BuffType>("Crippled");

        /// <summary>
        /// Current favor/tribute
        /// </summary>
        public long? CurrentFavor => GetMember<Int64Type>("CurrentFavor");

        /// <summary>
        /// Current weight
        /// </summary>
        public int? CurrentWeight => GetMember<IntType>("CurrentWeight");

        /// <summary>
        /// The buff on you, if any, that is increasing your cursed counter
        /// </summary>
        public BuffType Cursed => GetMember<BuffType>("Cursed");

        /// <summary>
        /// Copper on your cursor
        /// </summary>
        public int? CursorCopper => GetMember<IntType>("CursorCopper");

        /// <summary>
        /// Gold on your cursor
        /// </summary>
        public int? CursorGold => GetMember<IntType>("CursorGold");

        /// <summary>
        /// Krono on your cursor
        /// </summary>
        public int? CursorKrono => GetMember<IntType>("CursorKrono");

        /// <summary>
        /// Platinum on your cursor
        /// </summary>
        public int? CursorPlatinum => GetMember<IntType>("CursorPlatinum");

        /// <summary>
        /// Silver on your cursor
        /// </summary>
        public int? CursorSilver => GetMember<IntType>("CursorSilver");

        /// <summary>
        /// Damage Shield bonus from gear and spells
        /// </summary>
        public int? DamageShieldBonus => GetMember<IntType>("DamageShieldBonus");

        /// <summary>
        /// Damage Shield Mitigation bonus from gear and spells
        /// </summary>
        public int? DamageShieldMitigationBonus => GetMember<IntType>("DamageShieldMitigationBonus");

        /// <summary>
        /// Damage absorption remaining (eg. from Rune-type spells)
        /// </summary>
        public long? Dar => GetMember<Int64Type>("Dar");

        /// <summary>
        /// Dexterity
        /// </summary>
        public int? DEX => GetMember<IntType>("DEX");

        /// <summary>
        /// The buff on you, if any, that is increasing your disease counter
        /// </summary>
        public BuffType Diseased => GetMember<BuffType>("Diseased");

        /// <summary>
        /// DoT Shield bonus from gear and spells
        /// </summary>
        public int? DoTShieldBonus => GetMember<IntType>("DoTShieldBonus");

        /// <summary>
        /// Doubloons (alt currency)
        /// </summary>
        public int? Doubloons => GetMember<IntType>("Doubloons");

        /// <summary>
        /// Ticks remaining before able to rest
        /// </summary>
        public TicksType Downtime => GetMember<TicksType>("Downtime");

        /// <summary>
        /// Drunkenness level (0 - 200)
        /// </summary>
        public int? Drunk => GetMember<IntType>("Drunk");

        /// <summary>
        /// The buff on you, if any, that is increasing your damage shield
        /// </summary>
        public BuffType DSed => GetMember<BuffType>("DSed");

        /// <summary>
        /// Ebon Crystals (alt currency)
        /// </summary>
        public int? EbonCrystals => GetMember<IntType>("EbonCrystals");

        /// <summary>
        /// Endurance bonus from gear and spells
        /// </summary>
        public int? EnduranceBonus => GetMember<IntType>("EnduranceBonus");

        /// <summary>
        /// Endurance regen from the last tick
        /// </summary>
        public int? EnduranceRegen => GetMember<IntType>("EnduranceRegen");

        /// <summary>
        /// Endurance regen bonus
        /// </summary>
        public int? EnduranceRegenBonus => GetMember<IntType>("EnduranceRegenBonus");

        /// <summary>
        /// Energy Crystals (alt currency)
        /// </summary>
        public int? EnergyCrystals => GetMember<IntType>("EnergyCrystals");

        /// <summary>
        /// Experience (out of 330)
        /// </summary>
        public long? Exp => GetMember<Int64Type>("Exp");

        /// <summary>
        /// Bit mask of expansions owned
        /// </summary>
        public int? ExpansionFlags => GetMember<IntType>("ExpansionFlags");

        /// <summary>
        /// Faycitum (alt currency)
        /// </summary>
        public int? Faycites => GetMember<IntType>("Faycites");

        /// <summary>
        /// Fellowship character is in
        /// </summary>
        public FellowshipType Fellowship => GetMember<FellowshipType>("Fellowship");

        /// <summary>
        /// Fists of Bayle (alt currency)
        /// </summary>
        public int? Fists => GetMember<IntType>("Fists");

        /// <summary>
        /// Buff from the Focus line
        /// </summary>
        public BuffType Focus => GetMember<BuffType>("Focus");

        /// <summary>
        /// Number of free buff slots remaining
        /// </summary>
        public int? FreeBuffSlots => GetMember<IntType>("FreeBuffSlots");

        /// <summary>
        /// Number of free inventory slots remaining
        /// </summary>
        public int? FreeInventory => GetMember<IntType>("FreeInventory");

        /// <summary>
        /// Number of free inventory spaces of at least # size (giant=4)
        /// </summary>
        public IndexedMember<IntType, int> FreeInventorySlotSize { get; }

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
        public int? Gold => GetMember<IntType>("Gold");

        /// <summary>
        /// Gold in your bank
        /// </summary>
        public int? GoldBank => GetMember<IntType>("GoldBank");

        /// <summary>
        /// Target of the group's main assist
        /// </summary>
        public SpawnType GroupAssistTarget => GetMember<SpawnType>("GroupAssistTarget");

        /// <summary>
        /// True if in a group with a player or a mercenary
        /// </summary>
        public bool Grouped => GetMember<BoolType>("Grouped");

        /// <summary>
        /// Not working
        /// </summary>
        [Obsolete]
        public string GroupList => GetMember<StringType>("GroupList");

        /// <summary>
        /// Current group marked NPC (1 - 3)
        /// </summary>
        public IndexedMember<SpawnType, int> GroupMarkNPC { get; }

        /// <summary>
        /// Number of characters in group, including yourself. Returns null if not in a group
        /// </summary>
        public int? GroupSize => GetMember<IntType>("GroupSize");

        /// <summary>
        /// Buff with a growth SPA
        /// </summary>
        public BuffType Growth => GetMember<BuffType>("Growth");

        /// <summary>
        /// ID number of your guild
        /// </summary>
        public long? GuildID => GetMember<Int64Type>("GuildID");

        /// <summary>
        /// Total points earned in Deepest Guk LDoN missions
        /// </summary>
        public int? GukEarned => GetMember<IntType>("GukEarned");

        /// <summary>
        /// Total Combined Haste (worn and spell) as shown in Inventory Window stats
        /// </summary>
        public int? Haste => GetMember<IntType>("Haste");

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
        public int? HealAmountBonus => GetMember<IntType>("HealAmountBonus");

        /// <summary>
        /// Total Heroic Agility bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases the chance to dodge an attack, grants a bonus to defense skill, and reduces falling damage
        /// </summary>
        public int? HeroicAGIBonus => GetMember<IntType>("HeroicAGIBonus");

        /// <summary>
        /// Total Heroic Charisma bonus from gear
        /// Improves reaction rolls with some NPCs and increases the amount of faction you gain or lose when faction is adjusted
        /// </summary>
        public int? HeroicCHABonus => GetMember<IntType>("HeroicCHABonus");

        /// <summary>
        /// Total Heroic Dexterity bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by ranged attacks, improves chance to successfully assassinate or headshot, and improves the chance to riposte, block, and parry incoming attacks
        /// </summary>
        public int? HeroicDEXBonus => GetMember<IntType>("HeroicDEXBonus");

        /// <summary>
        /// Total Heroic Intelligence bonus from gear
        /// Increases mana pool, mana regen, and the maximum amount of mana regen an int-based caster can have
        /// It requires +25 heroic intel to gain a single point of +mana regeneration
        /// </summary>
        public int? HeroicINTBonus => GetMember<IntType>("HeroicINTBonus");

        /// <summary>
        /// Total Heroic Stamina bonus from gear
        /// Increases hit point pool, hit point regen, and the maximum amount of hit point regen a character can have
        /// Also increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have.
        /// </summary>
        public int? HeroicSTABonus => GetMember<IntType>("HeroicSTABonus");

        /// <summary>
        /// Total Heroic Strength bonus from gear
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by melee attacks and improves the bonus granted to armor class while using a shield
        /// (10 Heroic STR increases each Melee Hit by 1 point)
        /// </summary>
        public int? HeroicSTRBonus => GetMember<IntType>("HeroicSTRBonus");

        /// <summary>
        /// Total Heroic Wisdom bonus from gear
        /// Increases mana pool, mana regen, and the maximum amount of mana regen a wis-based caster can have
        /// </summary>
        public int? HeroicWISBonus => GetMember<IntType>("HeroicWISBonus");

        /// <summary>
        /// Hit point bonus from gear and spells
        /// </summary>
        public int? HPBonus => GetMember<IntType>("HPBonus");

        /// <summary>
        /// Hit point regeneration from last tick
        /// </summary>
        public int? HPRegen => GetMember<IntType>("HPRegen");

        /// <summary>
        /// HP regen bonus from gear and spells
        /// </summary>
        public int? HPRegenBonus => GetMember<IntType>("HPRegenBonus");

        /// <summary>
        /// Hunger level
        /// </summary>
        public int? Hunger => GetMember<IntType>("Hunger");

        /// <summary>
        /// Buff from the Hybrid HP line TODO What is this
        /// </summary>
        public BuffType HybridHP => GetMember<BuffType>("HybridHP");

        /// <summary>
        /// Are you in an instanced zone?
        /// </summary>
        public bool InInstance => GetMember<BoolType>("InInstance");

        /// <summary>
        /// Instance you are in
        /// </summary>
        public int? Instance => GetMember<IntType>("Instance");

        /// <summary>
        /// Intelligence
        /// </summary>
        public int? INT => GetMember<IntType>("INT");

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
        public int? Krono => GetMember<IntType>("Krono");

        /// <summary>
        /// Level of Delegate MA of the current group leader (not your own ability level)
        /// </summary>
        public int? LADelegateMA => GetMember<IntType>("LADelegateMA");

        /// <summary>
        /// Level of Delegate Mark NPC of the current group leader (not your own ability level)
        /// </summary>
        public int? LADelegateMarkNPC => GetMember<IntType>("LADelegateMarkNPC");

        /// <summary>
        /// Level of Find Path PC of the current group leader (not your own ability level)
        /// </summary>
        public int? LAFindPathPC => GetMember<IntType>("LAFindPathPC");

        /// <summary>
        /// Level of Health Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public int? LAHealthEnhancement => GetMember<IntType>("LAHealthEnhancement");

        /// <summary>
        /// Level of Health Regen of the current group leader (not your own ability level)
        /// </summary>
        public int? LAHealthRegen => GetMember<IntType>("LAHealthRegen");

        /// <summary>
        /// Level of HoTT of the current group leader (not your own ability level)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? LAHoTT => GetMember<IntType>("LAHoTT");

        /// <summary>
        /// Level of Inspect Buffs of the current group leader (not your own ability level)
        /// </summary>
        public int? LAInspectBuffs => GetMember<IntType>("LAInspectBuffs");

        /// <summary>
        /// Level of Mana Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public int? LAManaEnhancement => GetMember<IntType>("LAManaEnhancement");

        /// <summary>
        /// Level of Mark NPC of the current group leader (not your own ability level)
        /// </summary>
        public int? LAMarkNPC => GetMember<IntType>("LAMarkNPC");

        /// <summary>
        /// Language name by number, or number by name
        /// </summary>
        public IndexedStringMember<int, IntType, string> Language { get; }

        /// <summary>
        /// Language skill by name or number
        /// </summary>
        public IndexedMember<IntType> LanguageSkill { get; }

        /// <summary>
        /// Level of NPC Health of the current group leader (not your own ability level)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? LANPCHealth => GetMember<IntType>("LANPCHealth");

        /// <summary>
        /// Level of Offense Enhancement of the current group leader (not your own ability level)
        /// </summary>
        public int? LAOffenseEnhancement => GetMember<IntType>("LAOffenseEnhancement");

        /// <summary>
        /// Size of your largest free inventory slot (4 = Giant)
        /// </summary>
        public int? LargestFreeInventory => GetMember<IntType>("LargestFreeInventory");

        /// <summary>
        /// Level of Spell Awareness of the current group leader (not your own ability level)
        /// </summary>
        public int? LASpellAwareness => GetMember<IntType>("LASpellAwareness");

        /// <summary>
        /// Total points earned across all LDoN missions
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? LDoNPoints => GetMember<IntType>("LDoNPoints");

        /// <summary>
        /// Debuff from the Malo line
        /// </summary>
        public BuffType Maloed => GetMember<BuffType>("Maloed");

        /// <summary>
        /// Mana bonus from gear and spells
        /// </summary>
        public int? ManaBonus => GetMember<IntType>("ManaBonus");

        /// <summary>
        /// Mana regeneration from last tick
        /// </summary>
        public int? ManaRegen => GetMember<IntType>("ManaRegen");

        /// <summary>
        /// Mana regen bonus from gear and spells
        /// </summary>
        public int? ManaRegenBonus => GetMember<IntType>("ManaRegenBonus");

        /// <summary>
        /// Maximum number of buffs you can have
        /// </summary>
        public int? MaxBuffSlots => GetMember<IntType>("MaxBuffSlots");

        /// <summary>
        /// Mercenary AA experience, out of 1000
        /// </summary>
        public long? MercAAExp => GetMember<Int64Type>("MercAAExp");

        /// <summary>
        /// Number of mercenary AA points available to spend
        /// </summary>
        public int? MercAAPoints => GetMember<IntType>("MercAAPoints");

        /// <summary>
        /// Number of mercenary AA points spent
        /// </summary>
        public int? MercAAPointsSpent => GetMember<IntType>("MercAAPointsSpent");

        /// <summary>
        /// The state of your Mercenary, ACTIVE, SUSPENDED, or UNKNOWN (If it's dead). Returns NULL if you do not have a Mercenary.
        /// </summary>
        public MercenaryType Mercenary => GetMember<MercenaryType>("Mercenary");

        /// <summary>
        /// Current active mercenary stance as a string, default is NULL.
        /// </summary>
        public string MercenaryStance => GetMember<StringType>("MercenaryStance");

        /// <summary>
        /// Merc list description by name, or number by description
        /// </summary>
        public IndexedStringMember<int, IntType, string> MercList;

        /// <summary>
        /// Debuff from the Mez line
        /// </summary>
        public BuffType Mezzed => GetMember<BuffType>("Mezzed");

        /// <summary>
        /// Total points earned in Miragul's LDoN missions
        /// </summary>
        public int? MirEarned => GetMember<IntType>("MirEarned");

        /// <summary>
        /// Total points earned in Mistmoore LDoN missions
        /// </summary>
        public int? MMEarned => GetMember<IntType>("MMEarned");

        /// <summary>
        /// Nobles (alt currency)
        /// </summary>
        public int? Nobles => GetMember<IntType>("Nobles");

        /// <summary>
        /// Returns the amount of spell gems your toon has
        /// </summary>
        public int? NumGems => GetMember<IntType>("NumGems");

        /// <summary>
        /// Orux (alt currency)
        /// </summary>
        public int? Orux => GetMember<IntType>("Orux");

        /// <summary>
        /// Current AA experience as a percentage
        /// </summary>
        public float? PctAAExp => GetMember<FloatType>("PctAAExp");

        /// <summary>
        /// Current AA vitality as a percentage
        /// </summary>

        public float? PctAAVitality => GetMember<FloatType>("PctAAVitality");

        /// <summary>
        /// Your aggro percentage
        /// </summary>
        public int? PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Current experience as a percentage
        /// </summary>
        public float? PctExp => GetMember<FloatType>("PctExp");

        /// <summary>
        /// Percentage of your experience going to AA
        /// </summary>
        public int? PctExpToAA => GetMember<IntType>("PctExpToAA");

        /// <summary>
        /// Current mercenary AA experience as a oercentage
        /// </summary>
        public float? PctMercAAExp => GetMember<FloatType>("PctMercAAExp");

        /// <summary>
        /// Current vitality as a percentage
        /// </summary>
        public float? PctVitality => GetMember<FloatType>("PctVitality");

        /// <summary>
        /// A buff on your pet by slot number, or a slot number by buff name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> PetBuff { get; }

        /// <summary>
        /// Phosphenes (alt currency)
        /// </summary>
        public int? Phosphenes => GetMember<IntType>("Phosphenes");

        /// <summary>
        /// Phosphites (alt currency)
        /// </summary>
        public int? Phosphites => GetMember<IntType>("Phosphites");

        /// <summary>
        /// Pieces of Eight (alt currency)
        /// </summary>
        public int? PiecesofEight => GetMember<IntType>("PiecesofEight");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? SilverTokens => GetMember<IntType>("SilverTokens");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? GoldTokens => GetMember<IntType>("GoldTokens");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? McKenzie => GetMember<IntType>("McKenzie");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? Bayle => GetMember<IntType>("Bayle");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? Reclamation => GetMember<IntType>("Reclamation");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? Brellium => GetMember<IntType>("Brellium");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? Motes => GetMember<IntType>("Motes");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? RebellionChits => GetMember<IntType>("RebellionChits");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? DiamondCoins => GetMember<IntType>("DiamondCoins");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? BronzeFiats => GetMember<IntType>("BronzeFiats");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? Voucher => GetMember<IntType>("Voucher");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? VeliumShards => GetMember<IntType>("VeliumShards");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? CrystallizedFear => GetMember<IntType>("CrystallizedFear");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? ShadowStones => GetMember<IntType>("ShadowStones");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? DreadStones => GetMember<IntType>("DreadStones");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? MarksOfValor => GetMember<IntType>("MarksOfValor");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? MedalsOfHeroism => GetMember<IntType>("MedalsOfHeroism");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? RemnantOfTranquility => GetMember<IntType>("RemnantOfTranquility");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? BifurcatedCoin => GetMember<IntType>("BifurcatedCoin");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? SathirsTradeGems => GetMember<IntType>("SathirsTradeGems");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? BathezidTradeGems => GetMember<IntType>("BathezidTradeGems");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? FetterredIfritCoins => GetMember<IntType>("FetterredIfritCoins");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? EntwinedDjinnCoins => GetMember<IntType>("EntwinedDjinnCoins");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? CrystallizedLuck => GetMember<IntType>("CrystallizedLuck");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? FroststoneDucat => GetMember<IntType>("FroststoneDucat");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? WarlordsSymbol => GetMember<IntType>("WarlordsSymbol");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? OverseerTetradrachm => GetMember<IntType>("OverseerTetradrachm");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? WarforgedEmblem => GetMember<IntType>("WarforgedEmblem");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? RestlessMark => GetMember<IntType>("RestlessMark");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? ScarletMarks => GetMember<IntType>("ScarletMarks");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? MedalsOfConflict => GetMember<IntType>("MedalsOfConflict");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? ShadedSpecie => GetMember<IntType>("ShadedSpecie");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? SpiritualMedallions => GetMember<IntType>("SpiritualMedallions");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? LaurionInnVoucher => GetMember<IntType>("LaurionInnVoucher");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? ShalowainsPrivateReserve => GetMember<IntType>("ShalowainsPrivateReserve");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? LoyaltyTokens => GetMember<IntType>("LoyaltyTokens");

        /// <summary>
        /// Platinum on your character
        /// </summary>
        public int? Platinum => GetMember<IntType>("Platinum");

        /// <summary>
        /// Platinum in your bank
        /// </summary>
        public int? PlatinumBank => GetMember<IntType>("PlatinumBank");

        /// <summary>
        /// Platinum in your shared bank
        /// </summary>
        public int? PlatinumShared => GetMember<IntType>("PlatinumShared");

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
        public int? RadiantCrystals => GetMember<IntType>("RadiantCrystals");

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
        public bool RangedReady => GetMember<BoolType>("RangedReady");

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
        public int? RujEarned => GetMember<IntType>("RujEarned");

        /// <summary>
        /// Do I have auto-run turned on?
        /// </summary>
        public bool Running => GetMember<BoolType>("Running");

        /// <summary>
        /// Buff from the Spiritual Enlightenment line
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BuffType SE => GetMember<BuffType>("SE");

        /// <summary>
        /// Spawn that has secondary aggro
        /// </summary>
        public SpawnType SecondaryAggroPlayer => GetMember<SpawnType>("SecondaryAggroPlayer");

        /// <summary>
        /// Secondary aggro as a percentage
        /// </summary>
        public int? SecondaryPctAggro => GetMember<IntType>("SecondaryPctAggro");

        /// <summary>
        /// Shielding bonus from gear and spells
        /// </summary>
        public int? ShieldingBonus => GetMember<IntType>("ShieldingBonus");
        
        /// <summary>
        /// Buff from the Shining line
        /// </summary>
        public BuffType Shining => GetMember<BuffType>("Shining");

        /// <summary>
        /// Am I Shrouded?
        /// </summary>
        public bool Shrouded => GetMember<BoolType>("Shrouded");

        /// <summary>
        /// Silver on your character
        /// </summary>
        public int? Silver => GetMember<IntType>("Silver");

        /// <summary>
        /// Silver in your bank
        /// </summary>
        public int? SilverBank => GetMember<IntType>("SilverBank");

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
        public int? SpellDamageBonus => GetMember<IntType>("SpellDamageBonus");

        /// <summary>
        /// Returns TRUE if you have a spell in cooldown and FALSE when not.
        /// </summary>
        public bool SpellInCooldown => GetMember<BoolType>("SpellInCooldown");

        /// <summary>
        /// Indiciates if a spell is ready, by spell name or gem number
        /// </summary>
        public IndexedMember<BoolType, int, BoolType, string> SpellReady { get; }

        /// <summary>
        /// Spell Shield bonus from gear and spells
        /// </summary>
        public int? SpellShieldBonus => GetMember<IntType>("SpellShieldBonus");

        /// <summary>
        /// Stamina
        /// </summary>
        public int? STA => GetMember<IntType>("STA");

        /// <summary>
        /// Strength
        /// </summary>
        public int? STR => GetMember<IntType>("STR");

        /// <summary>
        /// Buff from the Strength line
        /// </summary>
        public BuffType Strength => GetMember<BuffType>("Strength");

        /// <summary>
        /// Strikethrough bonus from gear and spells
        /// </summary>
        public int? StrikeThroughBonus => GetMember<IntType>("StrikeThroughBonus");

        /// <summary>
        /// Stun Resist bonus from gear and spells
        /// </summary>
        public int? StunResistBonus => GetMember<IntType>("StunResistBonus");

        /// <summary>
        /// Subscription type GOLD, FREE, (Silver?)
        /// </summary>
        public string Subscription => GetMember<StringType>("Subscription");

        /// <summary>
        /// Buff from the Spiritual Vivacity line
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BuffType SV => GetMember<BuffType>("SV");

        /// <summary>
        /// Your character's lowest resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svChromatic => GetMember<IntType>("svChromatic");

        /// <summary>
        /// Cold resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svCold => GetMember<IntType>("svCold");

        /// <summary>
        /// Corruption resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svCorruption => GetMember<IntType>("svCorruption");

        /// <summary>
        /// Disease resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svDisease => GetMember<IntType>("svDisease");

        /// <summary>
        /// Fire resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svFire => GetMember<IntType>("svFire");

        /// <summary>
        /// Magic resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svMagic => GetMember<IntType>("svMagic");

        /// <summary>
        /// Poison resist
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svPoison => GetMember<IntType>("svPoison");

        /// <summary>
        /// The average of your character's resists
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? svPrismatic => GetMember<IntType>("svPrismatic");

        /// <summary>
        /// Buff from the Symbol line
        /// </summary>
        public BuffType Symbol => GetMember<BuffType>("Symbol");

        /// <summary>
        /// Total points earned in Takish LDoN missions
        /// </summary>
        public int? TakEarned => GetMember<IntType>("TakEarned");

        /// <summary>
        /// Debuff from the Tash line
        /// </summary>
        public BuffType Tashed => GetMember<BuffType>("Tashed");

        /// <summary>
        /// Thirst level
        /// </summary>
        public int? Thirst => GetMember<IntType>("Thirst");

        /// <summary>
        /// Total number of counters on you
        /// </summary>
        public long? TotalCounters => GetMember<Int64Type>("TotalCounters");

        /// <summary>
        /// Personal tribute currently active?
        /// </summary>
        public bool TributeActive => GetMember<BoolType>("TributeActive");

        /// <summary>
        /// Personal tribute timer
        /// </summary>
        public TicksType TributeTimer => GetMember<TicksType>("TributeTimer");

        /// <summary>
        /// Using advanced looting?
        /// </summary>
        public bool UseAdvancedLooting => GetMember<BoolType>("UseAdvancedLooting");

        /// <summary>
        /// Current vitality
        /// </summary>
        public long? Vitality => GetMember<Int64Type>("Vitality");

        /// <summary>
        /// Wisdom
        /// </summary>
        public int? WIS => GetMember<IntType>("WIS");

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
        public int? XTargetCount => GetMember<IntType>("XTarget");

        /// <summary>
        /// Number of slots available in your XTarget window
        /// </summary>
        public int? XTargetSlots => GetMember<IntType>("XTargetSlots");

        /// <summary>
        /// Number of spawns in auto hater slots in your XTarget
        /// </summary>
        public int? XTHaterCount => GetMember<IntType>("XTHaterCount");

        /// <summary>
        /// Zone you are bound in
        /// </summary>
        public ZoneType ZoneBound => GetMember<ZoneType>("ZoneBound");

        /// <summary>
        /// X location of your bind point
        /// </summary>
        public float? ZoneBoundX => GetMember<FloatType>("ZoneBoundX");

        /// <summary>
        /// Y location of your bind point
        /// </summary>
        public float? ZoneBoundY => GetMember<FloatType>("ZoneBoundY");

        /// <summary>
        /// Z location of your bind point
        /// </summary>
        public float? ZoneBoundZ => GetMember<FloatType>("ZoneBoundZ");

        /// <summary>
        /// Am I zoning?
        /// </summary>
        public bool Zoning => GetMember<BoolType>("Zoning");

        /// <summary>
        /// Bandolier set by slot number (1 - 20) or name
        /// </summary>
        public IndexedMember<BandolierType, string, BandolierType, int> Bandolier { get; }

        /// <summary>
        /// Luck
        /// </summary>
        public int? LCK => GetMember<IntType>("LCK");

        /// <summary>
        /// Blocked buff by index, valid index are 1 - 40
        /// </summary>
        public IndexedMember<SpellType, int> BlockedBuff { get; }

        /// <summary>
        /// Blocked pet buff by index, valid index are 1 - 40
        /// </summary>
        public IndexedMember<SpellType, int> BlockedPetBuff { get; }

        /// <summary>
        /// Fear debuff if the target has one
        /// </summary>
        public BuffType Feared => GetMember<BuffType>("Feared");

        /// <summary>
        /// Silence debuff if the target has one
        /// </summary>
        public BuffType Silenced => GetMember<BuffType>("Silenced");

        /// <summary>
        /// Invulnerability buff if the target has one
        /// </summary>
        public BuffType Invulnerable => GetMember<BuffType>("Invulnerable");

        /// <summary>
        /// DoT debuff if the target has one
        /// </summary>
        public BuffType Dotted => GetMember<BuffType>("Dotted");

        /// <summary>
        /// Can you use a mount here?
        /// </summary>
        public BoolType CanMount => GetMember<BoolType>("CanMount");

        /// <summary>
        /// Given the class shortname as a param, returns level of that class persona. e.g. ${Me.PersonaLevel[DRU]} returns the level of your Druid persona. If you do not have a Persona of the given class, the member will return 0.
        /// </summary>
        public IndexedMember<IntType> PersonaLevel { get; }

        /// <summary>
        /// The index is base 1.
        /// </summary>
        public IndexedStringMember<int, IntType, string> MercListInfo { get; }

        /// <summary>
        /// TODO: new field
        /// </summary>
        public long? VitalityCap => GetMember<Int64Type>("VitalityCap");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public TimeSpan? LastZoned => GetMember<TimeStampType>("LastZoned");

        /// <summary>
        /// The player origin zone.
        /// </summary>
        public ZoneType Origin => GetMember<ZoneType>("Origin");

        /// <summary>
        /// TODO: new field
        /// </summary>
        public int? SubscriptionDays => GetMember<IntType>("SubscriptionDays");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? ParcelStatus => GetMember<IntType>("ParcelStatus");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public TimeSpan? CastTimeLeft => GetMember<TimeStampType>("CastTimeLeft");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? SpellRankCap => GetMember<IntType>("SpellRankCap");

        /// <summary>
        /// Maximum level, inclusive
        /// </summary>
        public int? MaxLevel => GetMember<IntType>("MaxLevel");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? MaxAirSupply => GetMember<IntType>("MaxAirSupply");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? PctAirSupply => GetMember<IntType>("PctAirSupply");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? NumBagSlots => GetMember<IntType>("NumBagSlots");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public string Inviter => GetMember<StringType>("Inviter");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public bool Invited => GetMember<BoolType>("Invited");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? IsBerserk => GetMember<IntType>("IsBerserk");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public float? GroupLeaderExp => GetMember<FloatType>("GroupLeaderExp");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? GroupLeaderPoints => GetMember<IntType>("GroupLeaderPoints");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public float? PctGroupLeaderExp => GetMember<FloatType>("PctGroupLeaderExp");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public float? RaidLeaderExp => GetMember<FloatType>("RaidLeaderExp");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public int? RaidLeaderPoints => GetMember<IntType>("RaidLeaderPoints");

        /// <summary>
        /// TODO: new member
        /// </summary>
        public float? PctRaidLeaderExp => GetMember<FloatType>("PctRaidLeaderExp");

        /// <summary>
        /// Equivalent of the command /stand on
        /// </summary>
        public void Stand() => GetMember<MQ2DataType>("Stand");

        /// <summary>
        /// Equivalent of the command /sit on
        /// </summary>
        public void Sit() => GetMember<MQ2DataType>("Sit");

        /// <summary>
        /// Equivalent of the command /dismount
        /// </summary>
        public void Dismount() => GetMember<MQ2DataType>("Dismount");

        /// <summary>
        /// Equivalent of the command /stopcast
        /// </summary>
        public void StopCast() => GetMember<MQ2DataType>("StopCast");
    }
}