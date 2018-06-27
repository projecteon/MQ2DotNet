using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SpawnType : MQ2DataType
    {
        public SpawnType()
        {
        }

        public SpawnType(IntPtr pSpawn) : base("spawn",
            new MQ2TypeVar.MQ2VarPtr()
            {
                FullArray = BitConverter.GetBytes(pSpawn.ToInt32()).Concat(Enumerable.Repeat((byte) 0, 4)).ToArray()
            })
        {
        }

        /// <summary>
        /// Memory address of the SPAWNINFO struct for this spawn
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Level of the spawn
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Spawn's ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Internal name of the spawn e.g. a_rat01
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        public StringType Surname => GetMember<StringType>("Surname");
        public StringType CleanName => GetMember<StringType>("CleanName");
        public StringType DisplayName => GetMember<StringType>("DisplayName");
        public FloatType E => GetMember<FloatType>("E");
        public FloatType X => GetMember<FloatType>("X");
        public FloatType S => GetMember<FloatType>("S");
        public FloatType Y => GetMember<FloatType>("Y");
        public FloatType D => GetMember<FloatType>("D");
        public FloatType Z => GetMember<FloatType>("Z");
        public FloatType FloorZ => GetMember<FloatType>("FloorZ");
        public SpawnType Next => GetMember<SpawnType>("Next");
        public SpawnType Prev => GetMember<SpawnType>("Prev");
        public Int64Type CurrentHPs => GetMember<Int64Type>("CurrentHPs");
        public Int64Type MaxHPs => GetMember<Int64Type>("MaxHPs");
        public Int64Type PctHPs => GetMember<Int64Type>("PctHPs");
        public IntType AARank => GetMember<IntType>("AARank");
        public FloatType Speed => GetMember<FloatType>("Speed");
        public HeadingType Heading => GetMember<HeadingType>("Heading");
        public PetType Pet => GetMember<PetType>("Pet");
        public SpawnType Master => GetMember<SpawnType>("Master");
        public StringType Gender => GetMember<StringType>("Gender");
        public RaceType Race => GetMember<RaceType>("Race");
        public ClassType Class => GetMember<ClassType>("Class");
        public BodyType Body => GetMember<BodyType>("Body");
        public BoolType GM => GetMember<BoolType>("GM");
        public BoolType Levitating => GetMember<BoolType>("Levitating");
        public BoolType Sneaking => GetMember<BoolType>("Sneaking");
        public BoolType Invis => GetMember<BoolType>("Invis");
        public FloatType Height => GetMember<FloatType>("Height");
        public FloatType MaxRange => GetMember<FloatType>("MaxRange");
        public FloatType MaxRangeTo => GetMember<FloatType>("MaxRangeTo");
        public StringType Guild => GetMember<StringType>("Guild");
        public StringType GuildStatus => GetMember<StringType>("GuildStatus");
        public StringType Type => GetMember<StringType>("Type");
        public StringType Light => GetMember<StringType>("Light");
        public IntType StandState => GetMember<IntType>("StandState");
        public StringType State => GetMember<StringType>("State");
        public BoolType Standing => GetMember<BoolType>("Standing");
        public BoolType Sitting => GetMember<BoolType>("Sitting");
        public TimeStampType TimeBeenDead => GetMember<TimeStampType>("TimeBeenDead");
        public BoolType IsSummoned => GetMember<BoolType>("IsSummoned");
        public SpawnType TargetOfTarget => GetMember<SpawnType>("TargetOfTarget");
        public BoolType Ducking => GetMember<BoolType>("Ducking");
        public BoolType Feigning => GetMember<BoolType>("Feigning");
        public BoolType Binding => GetMember<BoolType>("Binding");
        public BoolType Dead => GetMember<BoolType>("Dead");
        public BoolType Stunned => GetMember<BoolType>("Stunned");
        public BoolType Aggressive => GetMember<BoolType>("Aggressive");
        public BoolType Hovering => GetMember<BoolType>("Hovering");
        public DeityType Deity => GetMember<DeityType>("Deity");

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
        /// Heading player must travel in to reach this spawn
        /// </summary>
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");
        public SpellType Casting => GetMember<SpellType>("Casting");
        public SpawnType Mount => GetMember<SpawnType>("Mount");
        public BoolType Underwater => GetMember<BoolType>("Underwater");
        public BoolType FeetWet => GetMember<BoolType>("FeetWet");
        public IntType PlayerState => GetMember<IntType>("PlayerState");
        public BoolType Stuck => GetMember<BoolType>("Stuck");
        public IntType Animation => GetMember<IntType>("Animation");
        public BoolType Holding => GetMember<BoolType>("Holding");
        public FloatType Look => GetMember<FloatType>("Look");
        public StringType xConColor => GetMember<StringType>("xConColor");
        public BoolType Invited => GetMember<BoolType>("Invited");
        public StringType Inviter => GetMember<StringType>("Inviter");
        public SpawnType NearestSpawn => GetMember<SpawnType>("NearestSpawn");
        public BoolType Trader => GetMember<BoolType>("Trader");
        public BoolType AFK => GetMember<BoolType>("AFK");
        public BoolType LFG => GetMember<BoolType>("LFG");
        public BoolType Linkdead => GetMember<BoolType>("Linkdead");
        public StringType Title => GetMember<StringType>("Title");
        public StringType Suffix => GetMember<StringType>("Suffix");
        public BoolType xGroupLeader => GetMember<BoolType>("xGroupLeader");
        public BoolType Assist => GetMember<BoolType>("Assist");
        public IntType Mark => GetMember<IntType>("Mark");
        public BoolType Anonymous => GetMember<BoolType>("Anonymous");
        public BoolType Roleplaying => GetMember<BoolType>("Roleplaying");
        public BoolType xLineOfSight => GetMember<BoolType>("xLineOfSight");
        public HeadingType HeadingToLoc => GetMember<HeadingType>("HeadingToLoc");
        public BoolType Fleeing => GetMember<BoolType>("Fleeing");
        public BoolType Named => GetMember<BoolType>("Named");
        public BoolType Buyer => GetMember<BoolType>("Buyer");
        public BoolType Moving => GetMember<BoolType>("Moving");
        public IntType CurrentMana => GetMember<IntType>("CurrentMana");
        public IntType MaxMana => GetMember<IntType>("MaxMana");
        public IntType PctMana => GetMember<IntType>("PctMana");
        public IntType CurrentEndurance => GetMember<IntType>("CurrentEndurance");
        public IntType PctEndurance => GetMember<IntType>("PctEndurance");
        public IntType MaxEndurance => GetMember<IntType>("MaxEndurance");
        public StringType Loc => GetMember<StringType>("Loc");
        public StringType LocYX => GetMember<StringType>("LocYX");
        public StringType LocYXZ => GetMember<StringType>("LocYXZ");
        public StringType EQLoc => GetMember<StringType>("EQLoc");
        public StringType MQLoc => GetMember<StringType>("MQLoc");
        public SpawnType Owner => GetMember<SpawnType>("Owner");
        public SpawnType Following => GetMember<SpawnType>("Following");
        public IntType MercID => GetMember<IntType>("MercID");
        public IntType ContractorID => GetMember<IntType>("ContractorID");
        public IntType Primary => GetMember<IntType>("Primary");
        public IntType Secondary => GetMember<IntType>("Secondary");
        public IntType Equipment => GetMember<IntType>("Equipment");
        public BoolType xTargetable => GetMember<BoolType>("xTargetable");
        public BoolType CanSplashLand => GetMember<BoolType>("CanSplashLand");
        public IntType IsBerserk => GetMember<IntType>("IsBerserk");
        public IntType pTouchingSwitch => GetMember<IntType>("pTouchingSwitch");
        public BoolType bShowHelm => GetMember<BoolType>("bShowHelm");
        public IntType CorpseDragCount => GetMember<IntType>("CorpseDragCount");
        public BoolType bBetaBuffed => GetMember<BoolType>("bBetaBuffed");
        public IntType CombatSkillTicks => GetMember<IntType>("CombatSkillTicks");
        public IntType FD => GetMember<IntType>("FD");
        public IntType InPvPArea => GetMember<IntType>("InPvPArea");
        public BoolType bAlwaysShowAura => GetMember<BoolType>("bAlwaysShowAura");
        public IntType GMRank => GetMember<IntType>("GMRank");
        public IntType WarCry => GetMember<IntType>("WarCry");
        public IntType IsPassenger => GetMember<IntType>("IsPassenger");
        public IntType LastCastTime => GetMember<IntType>("LastCastTime");
        public StringType DragNames => GetMember<StringType>("DragNames");
        public StringType DraggingPlayer => GetMember<StringType>("DraggingPlayer");
        public BoolType bStationary => GetMember<BoolType>("bStationary");
        public FloatType BearingToTarget => GetMember<FloatType>("BearingToTarget");
        public BoolType bTempPet => GetMember<BoolType>("bTempPet");
        public IntType HoldingAnimation => GetMember<IntType>("HoldingAnimation");
        public IntType Blind => GetMember<IntType>("Blind");
        public IntType LastCastNum => GetMember<IntType>("LastCastNum");
        public IntType CollisionCounter => GetMember<IntType>("CollisionCounter");
        public FloatType CeilingHeightAtCurrLocation => GetMember<FloatType>("CeilingHeightAtCurrLocation");
        public StringType AssistName => GetMember<StringType>("AssistName");
        public IntType SeeInvis => GetMember<IntType>("SeeInvis");
        public IntType SpawnStatus => GetMember<IntType>("SpawnStatus");
        public BoolType bWaitingForPort => GetMember<BoolType>("bWaitingForPort");

        public static IEnumerable<SpawnType> All
        {
            get
            {
                var hDll = NativeMethods.LoadLibrary("MQ2Main.dll");
                var ppSpawnManager = Marshal.ReadIntPtr(NativeMethods.GetProcAddress(hDll, "ppSpawnManager"));
                var pSpawnManager = Marshal.ReadIntPtr(ppSpawnManager);
                var pSpawn = Marshal.ReadIntPtr(pSpawnManager + 8);

                while (pSpawn != IntPtr.Zero)
                {
                    yield return new SpawnType(pSpawn);
                    pSpawn = Marshal.ReadIntPtr(pSpawn + 8);
                }
            }
        }
    }
}