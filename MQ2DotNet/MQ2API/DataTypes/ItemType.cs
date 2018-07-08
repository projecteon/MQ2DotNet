using System;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ItemType : MQ2DataType
    {
        internal ItemType(MQ2TypeVar typeVar) : base(typeVar)
        {
            WornSlot = new IndexedMember<BoolType, string, InvSlotType, int>(this, "WornSlot");
            Race = new IndexedMember<RaceType, int, RaceType, string>(this, "Race");
            Deity = new IndexedMember<DeityType, int, DeityType, string>(this, "Deity");
            Class = new IndexedMember<ClassType, int, ClassType, string>(this, "Class");
            AugSlot = new IndexedMember<AugType, int>(this, "AugSlot");
        }

        /// <summary>
        /// AC value on item
        /// </summary>
        public IntType AC => GetMember<IntType>("AC");

        /// <summary>
        /// Accuracy value on item
        /// </summary>
        public IntType Accuracy => GetMember<IntType>("Accuracy");

        /// <summary>
        /// Address of the ITEMINFO struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// AGI value on item
        /// </summary>
        public IntType AGI => GetMember<IntType>("AGI");
        /// <summary>
        /// Attack value on item
        /// </summary>
        public IntType Attack => GetMember<IntType>("Attack");
        /// <summary>
        /// Attuneable?
        /// </summary>
        public BoolType Attuneable => GetMember<BoolType>("Attuneable");

        /// <summary>
        /// Augment Restrictions
        /// </summary>
        public IntType AugRestrictions => GetMember<IntType>("AugRestrictions");

        /// <summary>
        /// Number of augs on this item
        /// </summary>
        public IntType Augs => GetMember<IntType>("Augs");

        /// <summary>
        /// Augment slots on the item (0 - 5)
        /// </summary>
        public IndexedMember<AugType, int> AugSlot { get; }

        /// <summary>
        /// Type of the 1st aug slot
        /// </summary>
        public IntType AugSlot1 => GetMember<IntType>("AugSlot1");

        /// <summary>
        /// Type of the 2nd aug slot
        /// </summary>
        public IntType AugSlot2 => GetMember<IntType>("AugSlot2");

        /// <summary>
        /// Type of the 3rd aug slot
        /// </summary>
        public IntType AugSlot3 => GetMember<IntType>("AugSlot3");

        /// <summary>
        /// Type of the 4th aug slot
        /// </summary>
        public IntType AugSlot4 => GetMember<IntType>("AugSlot4");

        /// <summary>
        /// Type of the 5th aug slot
        /// </summary>
        public IntType AugSlot5 => GetMember<IntType>("AugSlot5");

        /// <summary>
        /// Type of the 6th aug slot
        /// </summary>
        public IntType AugSlot6 => GetMember<IntType>("AugSlot6");

        /// <summary>
        /// Type of slot the item fits in, if it is an augment
        /// </summary>
        public IntType AugType => GetMember<IntType>("AugType");

        /// <summary>
        /// Avoidance value on the item
        /// </summary>
        public IntType Avoidance => GetMember<IntType>("Avoidance");

        /// <summary>
        /// The cost to buy this item from the active merchant
        /// </summary>
        public Int64Type BuyPrice => GetMember<Int64Type>("BuyPrice");

        /// <summary>
        /// Usable by character
        /// </summary>
        public BoolType CanUse => GetMember<BoolType>("CanUse");

        /// <summary>
        /// Cast time on clicky ItemSpell
        /// </summary>
        public TimeStampType CastTime => GetMember<TimeStampType>("CastTime");

        /// <summary>
        /// CHA value on item
        /// </summary>
        public IntType CHA => GetMember<IntType>("CHA");

        /// <summary>
        /// Charges on the item TODO: Total or remaining charges?
        /// </summary>
        public IntType Charges => GetMember<IntType>("Charges");

        /// <summary>
        /// Clairvoyance value on item
        /// </summary>
        public IntType Clairvoyance => GetMember<IntType>("Clairvoyance");

        /// <summary>
        /// Class that can use the item, by number (1 - Classes), or by class name or 3 letter code
        /// </summary>
        public IndexedMember<ClassType, int, ClassType, string> Class { get; }

        /// <summary>
        /// Number of classes that can use this item
        /// </summary>
        public IntType Classes => GetMember<IntType>("Classes");

        /// <summary>
        /// Clicky spell on the item
        /// </summary>
        public ItemSpellType Clicky => GetMember<ItemSpellType>("Clicky");

        /// <summary>
        /// Item is collectible?
        /// </summary>
        public BoolType Collectible => GetMember<BoolType>("Collectible");

        /// <summary>
        /// CombatEffects value on the item
        /// </summary>
        public IntType CombatEffects => GetMember<IntType>("CombatEffects");

        /// <summary>
        /// Memory address of the CONTENTS struct
        /// </summary>
        public IntType ContAddress => GetMember<IntType>("ContAddress");

        /// <summary>
        /// If the item is a container, the number of slots it has
        /// </summary>
        public IntType Container => GetMember<IntType>("Container");

        /// <summary>
        /// Size of items that can be placed in the container (4 = Giant)
        /// </summary>
        public IntType ContentSize => GetMember<IntType>("ContentSize");

        /// <summary>
        /// Damage value on the weapon
        /// </summary>
        public IntType Damage => GetMember<IntType>("Damage");

        /// <summary>
        /// Damage shield mitigation value on the item
        /// </summary>
        public IntType DamageShieldMitigation => GetMember<IntType>("DamageShieldMitigation");

        /// <summary>
        /// Damage shield value on the item
        /// </summary>
        public IntType DamShield => GetMember<IntType>("DamShield");

        /// <summary>
        /// Number of deities that can use the item. Returns 0 if there are no restrictions
        /// </summary>
        public IntType Deities => GetMember<IntType>("Deities");

        /// <summary>
        /// Deity that can use the item, by number (1 - Deities), or by name. Returns null if there are no restrictions
        /// </summary>
        public IndexedMember<DeityType, int, DeityType, string> Deity { get; }

        /// <summary>
        /// DEX value on item
        /// </summary>
        public IntType DEX => GetMember<IntType>("DEX");

        /// <summary>
        /// "None", "Magic", "Fire", "Cold", "Poison", "Disease"
        /// </summary>
        public StringType DMGBonusType => GetMember<StringType>("DMGBonusType");

        /// <summary>
        /// DoT Shielding value on the item
        /// </summary>
        public IntType DoTShielding => GetMember<IntType>("DoTShielding");

        /// <summary>
        /// Spell effect type (see below for spell effect types)
        /// Click Inventory - item has a right-click spell and can be cast from inventory
        /// Click Unknown - item has an unknown right-click effect restriction
        /// Click Worn - item has a right-click spell and must be equipped to click it
        /// Combat - weapon has a proc
        /// Spell Scroll - Scribeable spell scroll
        /// Worn - item has a focus effect
        /// </summary>
        public StringType EffectType => GetMember<StringType>("EffectType");

        /// <summary>
        /// Endurance value on the item
        /// </summary>
        public IntType Endurance => GetMember<IntType>("Endurance");

        /// <summary>
        /// Endurance regen value on the item
        /// </summary>
        public IntType EnduranceRegen => GetMember<IntType>("EnduranceRegen");

        /// <summary>
        /// Details about the evolving item, if it is one
        /// </summary>
        public EvolvingItemType Evolving => GetMember<EvolvingItemType>("Evolving");

        /// <summary>
        /// Is the item expendable?
        /// </summary>
        public BoolType Expendable => GetMember<BoolType>("Expendable");

        /// <summary>
        /// Familiar spell cast by the item
        /// </summary>
        public ItemSpellType Familiar => GetMember<ItemSpellType>("Familiar");

        /// <summary>
        /// If the item is a container, the 1 based index of the first free slot in it
        /// </summary>
        public IntType FirstFreeSlot => GetMember<IntType>("FirstFreeSlot");

        /// <summary>
        /// Focus effect on the item
        /// </summary>
        public ItemSpellType Focus => GetMember<ItemSpellType>("Focus");

        /// <summary>
        /// Second focus effect on the item
        /// </summary>
        public ItemSpellType Focus2 => GetMember<ItemSpellType>("Focus2");

        /// <summary>
        /// The number of items needed to fill all the stacks of the item you have
        /// If you have 3 stacks (1, 10, 20 in those stacks), you have room for 60 total and you have 31 on you, so FreeStack would return 29
        /// </summary>
        public IntType FreeStack => GetMember<IntType>("FreeStack");

        /// <summary>
        /// Haste value on item
        /// </summary>
        public IntType Haste => GetMember<IntType>("Haste");

        /// <summary>
        /// Heal amount value on the item
        /// </summary>
        public IntType HealAmount => GetMember<IntType>("HealAmount");

        /// <summary>
        /// Heirloom item?
        /// </summary>
        public BoolType Heirloom => GetMember<BoolType>("Heirloom");

        /// <summary>
        /// Heroic AGI value on the item
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases the chance to dodge an attack, grants a bonus to defense skill, and reduces falling damage
        /// </summary>
        public IntType HeroicAGI => GetMember<IntType>("HeroicAGI");

        /// <summary>
        /// Heroic CHA value on the item
        /// Improves reaction rolls with some NPCs and increases the amount of faction you gain or lose when faction is adjusted
        /// </summary>
        public IntType HeroicCHA => GetMember<IntType>("HeroicCHA");

        /// <summary>
        /// Heroic DEX value on the item
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by ranged attacks, improves chance to successfully assassinate or headshot, and improves the chance to riposte, block, and parry incoming attacks
        /// </summary>
        public IntType HeroicDEX => GetMember<IntType>("HeroicDEX");

        /// <summary>
        /// Heroic INT value on the item
        /// Increases mana pool, mana regen, and the maximum amount of mana regen an int-based caster can have
        /// It requires +25 heroic intel to gain a single point of +mana regeneration
        /// </summary>
        public IntType HeroicINT => GetMember<IntType>("HeroicINT");

        /// <summary>
        /// Heroic STA value on the item
        /// Increases hit point pool, hit point regen, and the maximum amount of hit point regen a character can have
        /// Also increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have.
        /// </summary>
        public IntType HeroicSTA => GetMember<IntType>("HeroicSTA");

        /// <summary>
        /// Heroic STR value on the item
        /// Increases endurance pool, endurance regen, and the maximum amount of endurance regen a character can have
        /// Also increases damage done by melee attacks and improves the bonus granted to armor class while using a shield
        /// (10 Heroic STR increases each Melee Hit by 1 point)
        /// </summary>
        public IntType HeroicSTR => GetMember<IntType>("HeroicSTR");

        [Obsolete]
        public IntType HeroicSvCold => GetMember<IntType>("HeroicSvCold");

        [Obsolete]
        public IntType HeroicSvCorruption => GetMember<IntType>("HeroicSvCorruption");

        [Obsolete]
        public IntType HeroicSvDisease => GetMember<IntType>("HeroicSvDisease");

        [Obsolete]
        public IntType HeroicSvFire => GetMember<IntType>("HeroicSvFire");

        [Obsolete]
        public IntType HeroicSvMagic => GetMember<IntType>("HeroicSvMagic");

        [Obsolete]
        public IntType HeroicSvPoison => GetMember<IntType>("HeroicSvPoison");

        /// <summary>
        /// Heroic WIS value on the item
        /// Increases mana pool, mana regen, and the maximum amount of mana regen a wis-based caster can have
        /// </summary>
        public IntType HeroicWIS => GetMember<IntType>("HeroicWIS");

        /// <summary>
        /// HP value on item
        /// </summary>
        public IntType HP => GetMember<IntType>("HP");

        /// <summary>
        /// HP Regen value on item
        /// </summary>
        public IntType HPRegen => GetMember<IntType>("HPRegen");

        /// <summary>
        /// ID of the icon used for the item
        /// </summary>
        public IntType Icon => GetMember<IntType>("Icon");

        /// <summary>
        /// ID of the item
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Illusion spell on the item
        /// </summary>
        public ItemSpellType Illusion => GetMember<ItemSpellType>("Illusion");

        /// <summary>
        /// Instrument Modifier Value
        /// </summary>
        public FloatType InstrumentMod => GetMember<FloatType>("InstrumentMod");

        /// <summary>
        /// INT value on item
        /// </summary>
        public IntType INT => GetMember<IntType>("INT");

        /// <summary>
        /// Inventory slot the item is in (not the slot it can be equipped in)
        /// </summary>
        public InvSlotType InvSlot => GetMember<InvSlotType>("InvSlot");

        /// <summary>
        /// If the item is a container, the item in the nth slot (0 based)
        /// </summary>
        public ItemType Item => GetMember<ItemType>("Item");

        /// <summary>
        /// Weapon delay
        /// </summary>
        public IntType ItemDelay => GetMember<IntType>("ItemDelay");

        /// <summary>
        /// just prints the actual hexlink for an item (not clickable)
        /// </summary>
        public StringType ItemLink => GetMember<StringType>("ItemLink");

        /// <summary>
        /// If the item is a container, the number of items in it
        /// </summary>
        public IntType Items => GetMember<IntType>("Items");

        /// <summary>
        /// Item slot number the item is currently in
        /// </summary>
        public IntType ItemSlot => GetMember<IntType>("ItemSlot");

        /// <summary>
        /// If the item is in a container, the index (0 based) of the slot within the container
        /// </summary>
        public IntType ItemSlot2 => GetMember<IntType>("ItemSlot2");

        /// <summary>
        /// "All", "Deepest Guk", "Miragul's", "Mistmoore", "Rujarkian", "Takish", "Unknown"
        /// </summary>
        public StringType LDoNTheme => GetMember<StringType>("LDoNTheme");

        /// <summary>
        /// Lore?
        /// </summary>
        public BoolType Lore => GetMember<BoolType>("Lore");

        /// <summary>
        /// Magic?
        /// </summary>
        public BoolType Magic => GetMember<BoolType>("Magic");

        /// <summary>
        /// Mana value on item
        /// </summary>
        public IntType Mana => GetMember<IntType>("Mana");

        /// <summary>
        /// ManaRegen value on item
        /// </summary>
        public IntType ManaRegen => GetMember<IntType>("ManaRegen");

        /// <summary>
        /// Max power on a power source
        /// </summary>
        public IntType MaxPower => GetMember<IntType>("MaxPower");

        /// <summary>
        /// Quantity of item active merchant has
        /// </summary>
        public IntType MerchQuantity => GetMember<IntType>("MerchQuantity");

        /// <summary>
        /// Mount spell on the item
        /// </summary>
        public ItemSpellType Mount => GetMember<ItemSpellType>("Mount");

        /// <summary>
        /// Name of the item
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// No destroy?
        /// </summary>
        public BoolType NoDestroy => GetMember<BoolType>("NoDestroy");

        /// <summary>
        /// No drop?
        /// </summary>
        public BoolType NoDrop => NoTrade;

        /// <summary>
        /// No rent?
        /// </summary>
        public BoolType NoRent => GetMember<BoolType>("NoRent");

        /// <summary>
        /// No trade? Same as <see cref="NoDrop"/>
        /// </summary>
        public BoolType NoTrade => GetMember<BoolType>("NoTrade");

        /// <summary>
        /// Item is a container and is open
        /// </summary>
        public BoolType Open => GetMember<BoolType>("Open");

        /// <summary>
        /// Ornamentation icon
        /// </summary>
        public IntType OrnamentationIcon => GetMember<IntType>("OrnamentationIcon");

        /// <summary>
        /// Percentage power remaining on a power source
        /// </summary>
        public FloatType PctPower => GetMember<FloatType>("PctPower");

        /// <summary>
        /// Power remaining on a power source
        /// </summary>
        public IntType Power => GetMember<IntType>("Power");

        /// <summary>
        /// Prestige? (Usable only by gold accounts)
        /// </summary>
        public BoolType Prestige => GetMember<BoolType>("Prestige");

        /// <summary>
        /// Proc on the weapon
        /// </summary>
        public ItemSpellType Proc => GetMember<ItemSpellType>("Proc");

        /// <summary>
        /// Purity value on the item
        /// </summary>
        public IntType Purity => GetMember<IntType>("Purity");

        /// <summary>
        /// Quest item?
        /// </summary>
        public BoolType Quest => GetMember<BoolType>("Quest");

        /// <summary>
        /// Race that can use the item, by number (1 - Races), or by name (full name e.g. Froglok, not FRG)
        /// </summary>
        public IndexedMember<RaceType, int, RaceType, string> Race { get; }

        /// <summary>
        /// Number of races that can use the item. 16 if usable by all races
        /// </summary>
        public IntType Races => GetMember<IntType>("Races");

        /// <summary>
        /// Range of a ranged weapon
        /// </summary>
        public IntType Range => GetMember<IntType>("Range");

        /// <summary>
        /// Required level to wear the item. Items with no required level will return 0
        /// </summary>
        public IntType RequiredLevel => GetMember<IntType>("RequiredLevel");

        /// <summary>
        /// Spell taught by the item if it is a scroll
        /// </summary>
        public ItemSpellType Scroll => GetMember<ItemSpellType>("Scroll");

        /// <summary>
        /// Price to sell this item at this merchant if one is open
        /// </summary>
        public IntType SellPrice => GetMember<IntType>("SellPrice");

        /// <summary>
        /// Shielding value on the item
        /// </summary>
        public IntType Shielding => GetMember<IntType>("Shielding");

        /// <summary>
        /// Item size (1 = Small, 2 = Medium, 3 = Large, 4 = Giant)
        /// </summary>
        public IntType Size => GetMember<IntType>("Size");

        /// <summary>
        /// If item is a container, the size of items it can hold (1 = Small, 2 = Medium, 3 = Large, 4 = Giant)
        /// </summary>
        public IntType SizeCapacity => GetMember<IntType>("SizeCapacity");

        /// <summary>
        /// Maximum absolute value of the skill mod e.g. 36 for a Master Tailor Trophy
        /// </summary>
        public IntType SkillModMax => GetMember<IntType>("SkillModMax");

        /// <summary>
        /// Skill modifier value as a percentage e.g. 12 for a Master Tailor Trophy
        /// </summary>
        public IntType SkillModValue => GetMember<IntType>("SkillModValue");

        /// <summary>
        /// If the item is a container, the number of slots in it taken up by a given item name
        /// </summary>
        public IntType SlotsUsedByItem => GetMember<IntType>("SlotsUsedByItem");

        /// <summary>
        /// Spell effect
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");

        /// <summary>
        /// Spell damage value on the item
        /// </summary>
        public IntType SpellDamage => GetMember<IntType>("SpellDamage");

        /// <summary>
        /// Spell shield value on the item
        /// </summary>
        public IntType SpellShield => GetMember<IntType>("SpellShield");

        /// <summary>
        /// STA value on the item
        /// </summary>
        public IntType STA => GetMember<IntType>("STA");

        /// <summary>
        /// Number of items in the stack
        /// </summary>
        public IntType Stack => GetMember<IntType>("Stack");

        /// <summary>
        /// Stackable?
        /// </summary>
        public BoolType Stackable => GetMember<BoolType>("Stackable");

        /// <summary>
        /// The total number of the stackable item in your inventory
        /// </summary>
        public IntType StackCount => GetMember<IntType>("StackCount");

        /// <summary>
        /// Number of stacks of the item in your inventory
        /// </summary>
        public IntType Stacks => GetMember<IntType>("Stacks");

        /// <summary>
        /// Maximum number if items that can be in the stack
        /// </summary>
        public IntType StackSize => GetMember<IntType>("StackSize");

        /// <summary>
        /// STR value on item
        /// </summary>
        public IntType STR => GetMember<IntType>("STR");

        /// <summary>
        /// Strikethrough value on item
        /// </summary>
        public IntType StrikeThrough => GetMember<IntType>("StrikeThrough");

        /// <summary>
        /// Stun resist value on item
        /// </summary>
        public IntType StunResist => GetMember<IntType>("StunResist");

        /// <summary>
        /// Cold resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svCold => GetMember<IntType>("svCold");

        /// <summary>
        /// Corruption resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svCorruption => GetMember<IntType>("svCorruption");

        /// <summary>
        /// Disease resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svDisease => GetMember<IntType>("svDisease");

        /// <summary>
        /// Fire resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svFire => GetMember<IntType>("svFire");

        /// <summary>
        /// Magic resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svMagic => GetMember<IntType>("svMagic");

        /// <summary>
        /// Poison resistance value on item
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType svPoison => GetMember<IntType>("svPoison");

        /// <summary>
        /// Time remaining on recast timer
        /// </summary>
        public TicksType Timer => GetMember<TicksType>("Timer");

        /// <summary>
        /// Number of seconds remaining on recast timer
        /// </summary>
        public IntType TimerReady => GetMember<IntType>("TimerReady");

        /// <summary>
        /// Used in tradeskills?
        /// </summary>
        public BoolType Tradeskills => GetMember<BoolType>("Tradeskills");

        /// <summary>
        /// Tribute value of item
        /// </summary>
        public IntType Tribute => GetMember<IntType>("Tribute");

        /// <summary>
        /// Type of the item e.g. Armor, 2H Slashing (corresponds to type in bazaar search)
        /// </summary>
        public StringType Type => GetMember<StringType>("Type");

        /// <summary>
        /// Value in coppers
        /// </summary>
        public IntType Value => GetMember<IntType>("Value");

        /// <summary>
        /// Item weight
        /// </summary>
        public IntType Weight => GetMember<IntType>("Weight");

        /// <summary>
        /// WIS value on item
        /// </summary>
        public IntType WIS => GetMember<IntType>("WIS");

        /// <summary>
        /// Spell effect when item is worn
        /// </summary>
        public ItemSpellType Worn => GetMember<ItemSpellType>("Worn");

        /// <summary>
        /// Can item be worn in invslot with name, or the nth invslot (1 based) that the item can be worn in
        /// </summary>
        public IndexedMember<BoolType, string, InvSlotType, int> WornSlot { get; }

        /// <summary>
        /// Number of slots this item can be worn in (fingers/ears count as 2)
        /// </summary>
        public IntType WornSlots => GetMember<IntType>("WornSlots");
    }
}