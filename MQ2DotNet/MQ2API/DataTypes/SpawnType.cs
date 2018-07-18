using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SpawnType : MQ2DataType
    {
        internal SpawnType(MQ2TypeVar typeVar) : base(typeVar)
        {
            SpawnStatus = new IndexedMember<IntType, int>(this, "SpawnStatus");
            SeeInvis = new IndexedMember<IntType, int>(this, "SeeInvis");
            NearestSpawn = new IndexedMember<SpawnType, int, SpawnType, string>(this, "NearestSpawn");
            HeadingToLoc = new IndexedMember<HeadingType>(this, "HeadingToLoc");
            Equipment = new IndexedMember<IntType, int, IntType, string>(this, "Equipment");
            DragNames = new IndexedStringMember<int>(this, "DragNames");
            CombatSkillTicks = new IndexedMember<IntType, int>(this, "CombatSkillTicks");
        }

        public SpawnType(IntPtr pSpawn) : base("spawn",
            new MQ2VarPtr()
            {
                Ptr = pSpawn
            })
        {
            SpawnStatus = new IndexedMember<IntType, int>(this, "SpawnStatus");
            SeeInvis = new IndexedMember<IntType, int>(this, "SeeInvis");
            NearestSpawn = new IndexedMember<SpawnType, int, SpawnType, string>(this, "NearestSpawn");
            HeadingToLoc = new IndexedMember<HeadingType>(this, "HeadingToLoc");
            Equipment = new IndexedMember<IntType, int, IntType, string>(this, "Equipment");
            DragNames = new IndexedStringMember<int>(this, "DragNames");
            CombatSkillTicks = new IndexedMember<IntType, int>(this, "CombatSkillTicks");
        }

        /// <summary>
        /// Dunno wtf this is or why I would care about it
        /// </summary>
        public IntType AARank => GetMember<IntType>("AARank");

        /// <summary>
        /// ActorDef name for this spawn
        /// </summary>
        public string ActorDef => GetMember<StringType>("ActorDef");

        /// <summary>
        /// Memory address of the SPAWNINFO struct for this spawn
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// AFK flag set?
        /// </summary>
        public BoolType AFK => GetMember<BoolType>("AFK");
        
        /// <summary>
        /// returns TRUE or FALSE if a mob is aggressive or not
        /// </summary>
        public BoolType Aggressive => GetMember<BoolType>("Aggressive");

        /// <summary>
        /// Current animation ID, see https://www.macroquest2.com/wiki/index.php/Animations
        /// </summary>
        public IntType Animation => GetMember<IntType>("Animation");

        /// <summary>
        /// Anon flag set
        /// </summary>
        public BoolType Anonymous => GetMember<BoolType>("Anonymous");

        /// <summary>
        /// Current Raid or Group assist target?
        /// </summary>
        public BoolType Assist => GetMember<BoolType>("Assist");

        /// <summary>
        /// TODO: SpawnType.AssistName is always blank?
        /// </summary>
        public string AssistName => GetMember<StringType>("AssistName");

        /// <summary>
        /// TODO: What is SpawnType.bAlwaysShowAura
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bAlwaysShowAura => GetMember<BoolType>("bAlwaysShowAura");

        /// <summary>
        /// TODO: What is SpawnType.bBetaBuffed
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bBetaBuffed => GetMember<BoolType>("bBetaBuffed");

        /// <summary>
        /// Returns stupid numbers
        /// </summary>
        [Obsolete]
        public FloatType BearingToTarget => GetMember<FloatType>("BearingToTarget");

        /// <summary>
        /// Binding wounds?
        /// </summary>
        public BoolType Binding => GetMember<BoolType>("Binding");

        /// <summary>
        /// Blind?
        /// </summary>
        public IntType Blind => GetMember<IntType>("Blind");

        /// <summary>
        /// Body type
        /// </summary>
        public BodyType Body => GetMember<BodyType>("Body");

        /// <summary>
        /// Seems broken and useless even if it wasn't
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bShowHelm => GetMember<BoolType>("bShowHelm");

        /// <summary>
        /// True for stationary spawns maybe? Returns FALSE for me when I'm standing still
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bStationary => GetMember<BoolType>("bStationary");

        /// <summary>
        /// Is the spawn a temp pet?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTempPet => GetMember<BoolType>("bTempPet");

        /// <summary>
        /// Is a buyer? (ie. Buyer in the bazaar)
        /// </summary>
        public BoolType Buyer => GetMember<BoolType>("Buyer");

        /// <summary>
        /// No idea
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bWaitingForPort => GetMember<BoolType>("bWaitingForPort");

        /// <summary>
        /// TRUE/FALSE on if a splash spell can land...NOTE! This check is ONLY for line of sight to the targetindicator (red/green circle)
        /// </summary>
        public BoolType CanSplashLand => GetMember<BoolType>("CanSplashLand");

        /// <summary>
        /// Spell, if currently casting (only accurate on yourself, not NPCs or other group members)
        /// </summary>
        public SpellType Casting => GetMember<SpellType>("Casting");

        /// <summary>
        /// Ceiling height at the spawn's current location
        /// </summary>
        public FloatType CeilingHeightAtCurrLocation => GetMember<FloatType>("CeilingHeightAtCurrLocation");

        /// <summary>
        /// Class
        /// </summary>
        public ClassType Class => GetMember<ClassType>("Class");

        /// <summary>
        /// The "cleaned up" name
        /// </summary>
        public string CleanName => GetMember<StringType>("CleanName");

        /// <summary>
        /// Collision counter
        /// </summary>
        public IntType CollisionCounter => GetMember<IntType>("CollisionCounter");

        /// <summary>
        /// Valid indexes are 0 and 1. TODO: What is SpawnType.CombatSkillTicks
        /// </summary>
        public IndexedMember<IntType, int> CombatSkillTicks { get; }

        /// <summary>
        /// Spawn ID of this spawn's contractor
        /// </summary>
        public IntType ContractorID => GetMember<IntType>("ContractorID");

        /// <summary>
        /// Returns weird numbers
        /// </summary>
        [Obsolete]
        public IntType CorpseDragCount => GetMember<IntType>("CorpseDragCount");

        /// <summary>
        /// Current Endurance points (only updates when target/group)
        /// </summary>
        public IntType CurrentEndurance => GetMember<IntType>("CurrentEndurance");

        /// <summary>
        /// Current hit points
        /// </summary>
        public Int64Type CurrentHPs => GetMember<Int64Type>("CurrentHPs");

        /// <summary>
        /// Current Mana points (only updates when target/group)
        /// </summary>
        public IntType CurrentMana => GetMember<IntType>("CurrentMana");

        /// <summary>
        /// Shortcut for -Z (makes Downward positive)
        /// </summary>
        public FloatType D => GetMember<FloatType>("D");

        /// <summary>
        /// Dead?
        /// </summary>
        public BoolType Dead => GetMember<BoolType>("Dead");

        /// <summary>
        /// Deity
        /// </summary>
        public DeityType Deity => GetMember<DeityType>("Deity");

        /// <summary>
        /// Name displayed in game (same as EQ's %T)
        /// </summary>
        public string DisplayName => GetMember<StringType>("DisplayName");

        /// <summary>
        /// 2D distance to the spawn in the XY plane
        /// </summary>
        public FloatType Distance => GetMember<FloatType>("Distance");

        /// <summary>
        /// 3D distance to the spawn in the XYZ plane
        /// </summary>
        public FloatType Distance3D => GetMember<FloatType>("Distance3D");

        /// <summary>
        /// 2D distance to the spawn in the XY plane, taking into account the spawn's movement but not the player's
        /// </summary>
        public FloatType DistancePredict => GetMember<FloatType>("DistancePredict");

        /// <summary>
        /// 1D distance to the spawn in the X plane
        /// </summary>
        public FloatType DistanceX => GetMember<FloatType>("DistanceX");

        /// <summary>
        /// 1D distance to the spawn in the Y plane
        /// </summary>
        public FloatType DistanceY => GetMember<FloatType>("DistanceY");

        /// <summary>
        /// 1D distance to the spawn in the Z plane
        /// </summary>
        public FloatType DistanceZ => GetMember<FloatType>("DistanceZ");

        /// <summary>
        /// Player this corpse is being dragged by
        /// </summary>
        public string DraggingPlayer => GetMember<StringType>("DraggingPlayer");

        /// <summary>
        /// Players whose corpse this spawn is dragging. Valid indexes are 0 and 1
        /// </summary>
        public IndexedStringMember<int> DragNames { get; }

        /// <summary>
        /// Ducking?
        /// </summary>
        public BoolType Ducking => GetMember<BoolType>("Ducking");

        /// <summary>
        /// Shortcut for -X (makes Eastward positive)
        /// </summary>
        public FloatType E => GetMember<FloatType>("E");

        /// <summary>
        /// Location using EQ format
        /// </summary>
        public string EQLoc => GetMember<StringType>("EQLoc");
        /// <summary>
        /// ID of the equipment used by the spawn
        /// returns a inttype, it takes numbers 0-8 or names: head chest arms wrists hands legs feet primary offhand
        /// </summary>
        public IndexedMember<IntType, int, IntType, string> Equipment { get; }

        /// <summary>
        /// TODO: What is SpawnType.FD?
        /// </summary>
        public IntType FD => GetMember<IntType>("FD");

        /// <summary>
        /// Feet wet/swimming?
        /// </summary>
        public BoolType FeetWet => GetMember<BoolType>("FeetWet");

        /// <summary>
        /// Feigning?
        /// </summary>
        public BoolType Feigning => GetMember<BoolType>("Feigning");

        /// <summary>
        /// Is your target moving away from you?
        /// </summary>
        public BoolType Fleeing => GetMember<BoolType>("Fleeing");

        /// <summary>
        /// Floor z value at the spawn's location
        /// </summary>
        public FloatType FloorZ => GetMember<FloatType>("FloorZ");

        /// <summary>
        /// The spawn a player is following using /follow on - also returns your pet's target via ${Me.Pet.Following}
        /// </summary>
        public SpawnType Following => GetMember<SpawnType>("Following");

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender => GetMember<StringType>("Gender");

        /// <summary>
        /// GM or Guide?
        /// </summary>
        public BoolType GM => GetMember<BoolType>("GM");

        /// <summary>
        /// GM rank
        /// </summary>
        public IntType GMRank => GetMember<IntType>("GMRank");

        /// <summary>
        /// Name of the spawn's guild
        /// </summary>
        public string Guild => GetMember<StringType>("Guild");

        /// <summary>
        /// Guild status (Leader, Officer, Member)
        /// </summary>
        public string GuildStatus => GetMember<StringType>("GuildStatus");

        /// <summary>
        /// Direction the spawn is facing
        /// </summary>
        public HeadingType Heading => GetMember<HeadingType>("Heading");

        /// <summary>
        /// Heading player must travel in to reach this spawn
        /// </summary>
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");

        /// <summary>
        /// Heading to the coordinates y,x from the spawn
        /// </summary>
        public IndexedMember<HeadingType> HeadingToLoc { get; }

        /// <summary>
        /// Height
        /// </summary>
        public FloatType Height => GetMember<FloatType>("Height");

        /// <summary>
        /// Represents what the pc/npc is holding
        /// </summary>
        public BoolType Holding => GetMember<BoolType>("Holding");

        /// <summary>
        /// Holding animation
        /// </summary>
        public IntType HoldingAnimation => GetMember<IntType>("HoldingAnimation");

        /// <summary>
        /// Hovering?
        /// </summary>
        public BoolType Hovering => GetMember<BoolType>("Hovering");

        /// <summary>
        /// Spawn's ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// In a PvP area?
        /// </summary>
        public IntType InPvPArea => GetMember<IntType>("InPvPArea");

        /// <summary>
        /// Invis?
        /// </summary>
        public BoolType Invis => GetMember<BoolType>("Invis");

        /// <summary>
        /// Spawn has been invited to a group
        /// </summary>
        public BoolType Invited => GetMember<BoolType>("Invited");

        /// <summary>
        /// Who invited the spawn to a group?
        /// </summary>
        public string Inviter => GetMember<StringType>("Inviter");

        /// <summary>
        /// Spawn is berserk?
        /// </summary>
        public IntType IsBerserk => GetMember<IntType>("IsBerserk");

        /// <summary>
        /// Spawn is a passenger?
        /// </summary>
        public IntType IsPassenger => GetMember<IntType>("IsPassenger");

        /// <summary>
        /// If it's a summoned being (pet for example). Unsure if useful for druid nukes.
        /// </summary>
        public BoolType IsSummoned => GetMember<BoolType>("IsSummoned");

        /// <summary>
        /// TODO: What is SpawnType.LastCastNum
        /// </summary>
        public IntType LastCastNum => GetMember<IntType>("LastCastNum");

        /// <summary>
        /// TODO: What is SpawnType.LastCastTime
        /// </summary>
        public IntType LastCastTime => GetMember<IntType>("LastCastTime");

        /// <summary>
        /// Level of the spawn
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Spawn is levitating?
        /// </summary>
        public BoolType Levitating => GetMember<BoolType>("Levitating");

        /// <summary>
        /// LFG flag set?
        /// </summary>
        public BoolType LFG => GetMember<BoolType>("LFG");

        /// <summary>
        /// Name of the light class this spawn has
        /// </summary>
        public string Light => GetMember<StringType>("Light");

        /// <summary>
        /// Linkdead?
        /// </summary>
        public BoolType Linkdead => GetMember<BoolType>("Linkdead");

        /// <summary>
        /// Loc of the spawn (Y, X)
        /// </summary>
        public string Loc => GetMember<StringType>("Loc");

        /// <summary>
        /// Loc of the spawn (Y, X)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string LocYX => GetMember<StringType>("LocYX");

        /// <summary>
        /// Loc of the spawn (Y, X, Z)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string LocYXZ => GetMember<StringType>("LocYXZ");

        /// <summary>
        /// Looking this angle
        /// </summary>
        public FloatType Look => GetMember<FloatType>("Look");

        /// <summary>
        /// Current Raid or Group marked npc mark number (raid first)
        /// </summary>
        public IntType Mark => GetMember<IntType>("Mark");

        /// <summary>
        /// Master, if it is charmed or a pet
        /// </summary>
        public SpawnType Master => GetMember<SpawnType>("Master");

        /// <summary>
        /// Maximum Endurance points (only updates when target/group)
        /// </summary>
        public IntType MaxEndurance => GetMember<IntType>("MaxEndurance");

        /// <summary>
        /// Maximum hit points
        /// </summary>
        public Int64Type MaxHPs => GetMember<Int64Type>("MaxHPs");

        /// <summary>
        /// Maximum Mana points (only updates when target/group)
        /// </summary>
        public IntType MaxMana => GetMember<IntType>("MaxMana");

        /// <summary>
        /// The max distance from this spawn for it to hit you
        /// </summary>
        public FloatType MaxRange => GetMember<FloatType>("MaxRange");

        /// <summary>
        /// The Max distance from this spawn for you to hit it
        /// </summary>
        public FloatType MaxRangeTo => GetMember<FloatType>("MaxRangeTo");

        /// <summary>
        /// Spawn ID of this spawn's contractor
        /// </summary>
        public IntType MercID => GetMember<IntType>("MercID");

        /// <summary>
        /// This spawn's mount 
        /// </summary>
        public SpawnType Mount => GetMember<SpawnType>("Mount");

        /// <summary>
        /// Moving?
        /// </summary>
        public BoolType Moving => GetMember<BoolType>("Moving");

        /// <summary>
        /// Location using MQ format (Y, X, Z)
        /// </summary>
        public string MQLoc => GetMember<StringType>("MQLoc");

        /// <summary>
        /// Internal name of the spawn e.g. a_rat01
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Is this a "named" spawn (ie. does it's name not start with an "a" or an "an", plus a bunch of other checks. See IsNamed() in MQ2Utilities.cpp)
        /// </summary>
        public BoolType Named => GetMember<BoolType>("Named");

        /// <summary>
        /// Nth closest spawn to this spawn, or the nth closest matching a search string e.g. "2,npc" for the second closest NPC
        /// </summary>
        public IndexedMember<SpawnType, int, SpawnType, string> NearestSpawn { get; }
        
        /// <summary>
        /// Next spawn in the linked list
        /// </summary>
        public SpawnType Next => GetMember<SpawnType>("Next");

        /// <summary>
        /// Owner, if mercenary
        /// </summary>
        public SpawnType Owner => GetMember<SpawnType>("Owner");

        /// <summary>
        /// Endurance as a percentage
        /// </summary>
        public IntType PctEndurance => GetMember<IntType>("PctEndurance");

        /// <summary>
        /// HP as a percentage
        /// </summary>
        public Int64Type PctHPs => GetMember<Int64Type>("PctHPs");

        /// <summary>
        /// Mana as a percentage
        /// </summary>
        public IntType PctMana => GetMember<IntType>("PctMana");

        /// <summary>
        /// Spawn's pet
        /// </summary>
        public PetType Pet => GetMember<PetType>("Pet");

        /// <summary>
        /// returns a mask as an inttype which has the following meaning:
        /// 0=Idle 1=Open 2=WeaponSheathed 4=Aggressive 8=ForcedAggressive 0x10=InstrumentEquipped 0x20=Stunned 0x40=PrimaryWeaponEquipped 0x80=SecondaryWeaponEquipped
        /// </summary>
        public IntType PlayerState => GetMember<IntType>("PlayerState");

        /// <summary>
        /// Next spawn in EQ's favourite data structure
        /// </summary>
        public SpawnType Prev => GetMember<SpawnType>("Prev");

        /// <summary>
        /// Item ID of anything that may be in the Primary slot
        /// </summary>
        public IntType Primary => GetMember<IntType>("Primary");

        /// <summary>
        /// TODO: What is SpawnType.pTouchingSwitch
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IntType pTouchingSwitch => GetMember<IntType>("pTouchingSwitch");

        /// <summary>
        /// Spawn's race
        /// </summary>
        public RaceType Race => GetMember<RaceType>("Race");

        /// <summary>
        /// Roleplaying flag set?
        /// </summary>
        public BoolType Roleplaying => GetMember<BoolType>("Roleplaying");

        /// <summary>
        /// Shortcut for -Y (makes Southward positive)
        /// </summary>
        public FloatType S => GetMember<FloatType>("S");

        /// <summary>
        /// Item ID of anything that may be in the Secondary slot
        /// </summary>
        public IntType Secondary => GetMember<IntType>("Secondary");

        /// <summary>
        /// Spawn can see invis, takes an index of 0 - 2, guessing for invis/invis vs undead/improved invis?
        /// TODO: Confirm function of SpawnType.SeeInvis
        /// </summary>
        public IndexedMember<IntType, int> SeeInvis { get; }

        /// <summary>
        /// Sitting?
        /// </summary>
        public BoolType Sitting => GetMember<BoolType>("Sitting");

        /// <summary>
        /// Sneaking?
        /// </summary>
        public BoolType Sneaking => GetMember<BoolType>("Sneaking");

        /// <summary>
        /// Spawn status, takes an index of 0 - 5. TODO: Confirm what they mean
        /// </summary>
        public IndexedMember<IntType, int> SpawnStatus { get; }

        /// <summary>
        /// Speed as a percentage of regular run speed
        /// </summary>
        public FloatType Speed => GetMember<FloatType>("Speed");

        /// <summary>
        /// Standing?
        /// </summary>
        public BoolType Standing => GetMember<BoolType>("Standing");

        /// <summary>
        /// StandState
        /// </summary>
        public IntType StandState => GetMember<IntType>("StandState");

        /// <summary>
        /// STAND, SIT, DUCK, BIND, FEIGN, DEAD, STUN, HOVER, MOUNT, UNKNOWN
        /// </summary>
        public string State => GetMember<StringType>("State");

        /// <summary>
        /// Stuck?
        /// </summary>
        public BoolType Stuck => GetMember<BoolType>("Stuck");

        /// <summary>
        /// Stunned?
        /// </summary>
        public BoolType Stunned => GetMember<BoolType>("Stunned");

        /// <summary>
        /// Suffix attached to name, eg. of servername
        /// </summary>
        public string Suffix => GetMember<StringType>("Suffix");

        /// <summary>
        /// Last name
        /// </summary>
        public string Surname => GetMember<StringType>("Surname");

        /// <summary>
        /// Target of this spawn's target
        /// </summary>
        public SpawnType TargetOfTarget => GetMember<SpawnType>("TargetOfTarget");

        /// <summary>
        /// Time this spawn has been dead for
        /// </summary>
        public TimeStampType TimeBeenDead => GetMember<TimeStampType>("TimeBeenDead");

        /// <summary>
        /// Prefix/Title before name
        /// </summary>
        public string Title => GetMember<StringType>("Title");

        /// <summary>
        /// Trader (in bazaar)?
        /// </summary>
        public BoolType Trader => GetMember<BoolType>("Trader");

        /// <summary>
        /// PC, NPC, Untargetable, Mount, Pet, Corpse, Chest, Trigger, Trap, Timer, Item, Mercenary, Aura, Object, Banner, Campfire, Flyer
        /// </summary>
        public string Type => GetMember<StringType>("Type");

        /// <summary>
        /// Underwater?
        /// </summary>
        public BoolType Underwater => GetMember<BoolType>("Underwater");

        /// <summary>
        /// TODO: What is SpawnType.WarCry?
        /// </summary>
        public IntType WarCry => GetMember<IntType>("WarCry");

        /// <summary>
        /// X, the Northward-positive coordinate
        /// </summary>
        public FloatType X => GetMember<FloatType>("X");

        /// <summary>
        /// GREY, GREEN, LIGHT BLUE, BLUE, WHITE, YELLOW, RED
        /// </summary>
        public string ConColor => GetMember<StringType>("ConColor");

        /// <summary>
        /// Group leader?
        /// </summary>
        public BoolType GroupLeader => GetMember<BoolType>("GroupLeader");

        /// <summary>
        /// Returns TRUE if spawn is in LoS
        /// </summary>
        public BoolType LineOfSight => GetMember<BoolType>("LineOfSight");

        /// <summary>
        /// Spawn can be targetted?
        /// </summary>
        public BoolType Targetable => GetMember<BoolType>("Targetable");

        /// <summary>
        /// Y, the Westward-positive coordinate
        /// </summary>
        public FloatType Y => GetMember<FloatType>("Y");

        /// <summary>
        /// Z, the Upward-positive coordinate
        /// </summary>
        public FloatType Z => GetMember<FloatType>("Z");

        /// <summary>
        /// Targets the spawn (equivalent of /target)
        /// </summary>
        public void DoTarget() => GetMember<MQ2DataType>("DoTarget");

        /// <summary>
        /// Faces the spawn (equivalent of /face)
        /// </summary>
        public void DoFace() => GetMember<MQ2DataType>("DoFace");

        /// <summary>
        /// Left click on the spawn
        /// </summary>
        public void LeftClick() => GetMember<MQ2DataType>("LeftClick");

        /// <summary>
        /// Right click on the spawn
        /// </summary>
        public void RightClick() => GetMember<MQ2DataType>("RightClick");

        /// <summary>
        /// Assists the spawn (equivalent of /assist)
        /// </summary>
        public void DoAssist() => GetMember<MQ2DataType>("DoAssist");
    }
}