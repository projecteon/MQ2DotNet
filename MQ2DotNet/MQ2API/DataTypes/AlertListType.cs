// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// VarPtr identifies a SPAWNSEARCH struct on an alert list
    /// </summary>
    public class AlertListType : MQ2DataType
    {
        internal AlertListType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Minimum level, inclusive
        /// </summary>
        public IntType MinLevel => GetMember<IntType>("MinLevel");

        /// <summary>
        /// Maximum level, inclusive
        /// </summary>
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");

        /// <summary>
        /// Type, see eSpawnType in MQ2Internal.h
        /// </summary>
        public IntType SpawnType => GetMember<IntType>("SpawnType");

        /// <summary>
        /// Spawn ID to match
        /// </summary>
        public IntType SpawnID => GetMember<IntType>("SpawnID");

        /// <summary>
        /// Last spawn ID returned, used when iterating through a search spawn
        /// </summary>
        public IntType FromSpawnID => GetMember<IntType>("FromSpawnID");

        /// <summary>
        /// Radius in which to search (around xLoc/yLoc if set, otherwise around character)
        /// </summary>
        public FloatType Radius => GetMember<FloatType>("Radius");

        /// <summary>
        /// Include spawns matching this name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Include spawns with this body type description e.g. Humanoid
        /// </summary>
        public string BodyType => GetMember<StringType>("BodyType");

        /// <summary>
        /// Include spawns with this race e.g. Vah Shir
        /// </summary>
        public string Race => GetMember<StringType>("Race");
        
        /// <summary>
        /// Include spawns with this class e.g. Cleric
        /// </summary>
        public string Class => GetMember<StringType>("Class");

        /// <summary>
        /// Include spawns with this light
        /// </summary>
        public string Light => GetMember<StringType>("Light");

        /// <summary>
        /// Include spawns in this guild ID
        /// </summary>
        public Int64Type GuildID => GetMember<Int64Type>("GuildID");
        
        /// <summary>
        /// SpawnID filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bSpawnID => GetMember<BoolType>("bSpawnID");

        /// <summary>
        /// Not near alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNotNearAlert => GetMember<BoolType>("bNotNearAlert");

        /// <summary>
        /// Near alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNearAlert => GetMember<BoolType>("bNearAlert");

        /// <summary>
        /// No alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNoAlert => GetMember<BoolType>("bNoAlert");

        /// <summary>
        /// Alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bAlert => GetMember<BoolType>("bAlert");

        /// <summary>
        /// Only include LFG spawns?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bLFG => GetMember<BoolType>("bLFG");

        /// <summary>
        /// Only include trader spawns?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTrader => GetMember<BoolType>("bTrader");

        /// <summary>
        /// Light filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bLight => GetMember<BoolType>("bLight");

        /// <summary>
        /// Return next spawn in list after <see cref="FromSpawnID"/>?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTargNext => GetMember<BoolType>("bTargNext");

        /// <summary>
        /// Return prev spawn in list before <see cref="FromSpawnID"/>?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTargPrev => GetMember<BoolType>("bTargPrev");

        /// <summary>
        /// Include group members only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bGroup => GetMember<BoolType>("bGroup");

        /// <summary>
        /// Include fellowship members only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bFellowship => GetMember<BoolType>("bFellowship");

        /// <summary>
        /// Exclude group members?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNoGroup => GetMember<BoolType>("bNoGroup");

        /// <summary>
        /// Exclude raid members?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bRaid => GetMember<BoolType>("bRaid");

        /// <summary>
        /// Include GMs only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bGM => GetMember<BoolType>("bGM");

        /// <summary>
        /// Include named NPCs only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNamed => GetMember<BoolType>("bNamed");

        /// <summary>
        /// Include merchants only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bMerchant => GetMember<BoolType>("bMerchant");

        /// <summary>
        /// Include tribute masters only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTributeMaster => GetMember<BoolType>("bTributeMaster");

        /// <summary>
        /// Include knights (PAL/SHD) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bKnight => GetMember<BoolType>("bKnight");

        /// <summary>
        /// Include tanks (WAR/PAL/SHD) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTank => GetMember<BoolType>("bTank");

        /// <summary>
        /// Include healers (CLR/SHM/DRU) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bHealer => GetMember<BoolType>("bHealer");

        /// <summary>
        /// Include DPS classes only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bDps => GetMember<BoolType>("bDps");

        /// <summary>
        /// Include classes (ENC/SHM/BRD) that can slow only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bSlower => GetMember<BoolType>("bSlower");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bAura => GetMember<BoolType>("bAura");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bBanner => GetMember<BoolType>("bBanner");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bCampfire => GetMember<BoolType>("bCampfire");

        /// <summary>
        /// Exclude spawn with an id of <see cref="SpawnID"/>
        /// </summary>
        public IntType NotID => GetMember<IntType>("NotID");

        /// <summary>
        /// Exclude spawns near a spawn on this alert list
        /// </summary>
        public IntType NotNearAlertList => GetMember<IntType>("NotNearAlertList");

        /// <summary>
        /// Include spawns near a spawn on this alert list
        /// </summary>
        public IntType NearAlertList => GetMember<IntType>("NearAlertList");

        /// <summary>
        /// Exclude spawns on this alert list
        /// </summary>
        public IntType NoAlertList => GetMember<IntType>("NoAlertList");

        /// <summary>
        /// Include spawns on this alert list
        /// </summary>
        public IntType AlertList => GetMember<IntType>("AlertList");

        /// <summary>
        /// Include spawns within this distance of zLoc if set, otherwise character's z location
        /// </summary>
        public DoubleType ZRadius => GetMember<DoubleType>("ZRadius");

        /// <summary>
        /// Include spawns within this 3D distance of the xLoc/yLoc/zLoc if specified, otherwise character's location
        /// </summary>
        public DoubleType FRadius => GetMember<DoubleType>("FRadius");

        /// <summary>
        /// X location to base search around instead of character's
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public FloatType xLoc => GetMember<FloatType>("xLoc");

        /// <summary>
        /// Y location to base search around instead of character's
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public FloatType yLoc => GetMember<FloatType>("yLoc");

        /// <summary>
        /// If true, use xLoc/yLoc/zLoc insted of character's position
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bKnownLocation => GetMember<BoolType>("bKnownLocation");

        /// <summary>
        /// Exclude pets?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNoPet => GetMember<BoolType>("bNoPet");

        /// <summary>
        /// What to sort the list by
        /// 0 = level, 1 = display name (default), 2 = race, 3 = class, 4 = distance (2D, XY), 5 = guild, 6 = id
        /// </summary>
        public IntType SortBy => GetMember<IntType>("SortBy");

        /// <summary>
        /// Exclude spawns in a guild
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bNoGuild => GetMember<BoolType>("bNoGuild");

        /// <summary>
        /// Only include spawns you have line of sight to
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bLoS => GetMember<BoolType>("bLoS");

        /// <summary>
        /// Match exact name rather than partial
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bExactName => GetMember<BoolType>("bExactName");

        /// <summary>
        /// Include only targetable spawns
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BoolType bTargetable => GetMember<BoolType>("bTargetable");

        /// <summary>
        /// Bitmask of player states to include
        /// </summary>
        public IntType PlayerState => GetMember<IntType>("PlayerState");

        /// <summary>
        /// Return the first spawn matching the ID or Name filters (ignores all other filters)
        /// </summary>
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");
    }
}