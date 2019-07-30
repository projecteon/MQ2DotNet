using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an alert list
    /// </summary>
    /// <remarks>VarPtr identifies a SPAWNSEARCH struct on an alert list</remarks>
    [PublicAPI]
    [MQ2Type("alertlist")]
    public class AlertListType : MQ2DataType
    {
        internal AlertListType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Minimum level, inclusive
        /// </summary>
        public int? MinLevel => GetMember<IntType>("MinLevel");

        /// <summary>
        /// Maximum level, inclusive
        /// </summary>
        public int? MaxLevel => GetMember<IntType>("MaxLevel");

        /// <summary>
        /// Type, see eSpawnType in MQ2Internal.h
        /// </summary>
        public int? SpawnType => GetMember<IntType>("SpawnType");

        /// <summary>
        /// Spawn ID to match
        /// </summary>
        public int? SpawnID => GetMember<IntType>("SpawnID");

        /// <summary>
        /// Last spawn ID returned, used when iterating through a search spawn
        /// </summary>
        public int? FromSpawnID => GetMember<IntType>("FromSpawnID");

        /// <summary>
        /// Radius in which to search (around xLoc/yLoc if set, otherwise around character)
        /// </summary>
        public float? Radius => GetMember<FloatType>("Radius");

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
        public long? GuildID => GetMember<Int64Type>("GuildID");
        
        /// <summary>
        /// SpawnID filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bSpawnID => GetMember<BoolType>("bSpawnID");

        /// <summary>
        /// Not near alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNotNearAlert => GetMember<BoolType>("bNotNearAlert");

        /// <summary>
        /// Near alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNearAlert => GetMember<BoolType>("bNearAlert");

        /// <summary>
        /// No alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNoAlert => GetMember<BoolType>("bNoAlert");

        /// <summary>
        /// Alert filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bAlert => GetMember<BoolType>("bAlert");

        /// <summary>
        /// Only include LFG spawns?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bLFG => GetMember<BoolType>("bLFG");

        /// <summary>
        /// Only include trader spawns?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTrader => GetMember<BoolType>("bTrader");

        /// <summary>
        /// Light filter enabled?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bLight => GetMember<BoolType>("bLight");

        /// <summary>
        /// Return next spawn in list after <see cref="FromSpawnID"/>?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTargNext => GetMember<BoolType>("bTargNext");

        /// <summary>
        /// Return prev spawn in list before <see cref="FromSpawnID"/>?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTargPrev => GetMember<BoolType>("bTargPrev");

        /// <summary>
        /// Include group members only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bGroup => GetMember<BoolType>("bGroup");

        /// <summary>
        /// Include fellowship members only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bFellowship => GetMember<BoolType>("bFellowship");

        /// <summary>
        /// Exclude group members?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNoGroup => GetMember<BoolType>("bNoGroup");

        /// <summary>
        /// Exclude raid members?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bRaid => GetMember<BoolType>("bRaid");

        /// <summary>
        /// Include GMs only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bGM => GetMember<BoolType>("bGM");

        /// <summary>
        /// Include named NPCs only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNamed => GetMember<BoolType>("bNamed");

        /// <summary>
        /// Include merchants only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bMerchant => GetMember<BoolType>("bMerchant");

        /// <summary>
        /// Include tribute masters only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTributeMaster => GetMember<BoolType>("bTributeMaster");

        /// <summary>
        /// Include knights (PAL/SHD) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bKnight => GetMember<BoolType>("bKnight");

        /// <summary>
        /// Include tanks (WAR/PAL/SHD) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTank => GetMember<BoolType>("bTank");

        /// <summary>
        /// Include healers (CLR/SHM/DRU) only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bHealer => GetMember<BoolType>("bHealer");

        /// <summary>
        /// Include DPS classes only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bDps => GetMember<BoolType>("bDps");

        /// <summary>
        /// Include classes (ENC/SHM/BRD) that can slow only?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bSlower => GetMember<BoolType>("bSlower");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bAura => GetMember<BoolType>("bAura");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bBanner => GetMember<BoolType>("bBanner");

        /// <summary>
        /// Not used
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bCampfire => GetMember<BoolType>("bCampfire");

        /// <summary>
        /// Exclude spawn with an id of <see cref="SpawnID"/>
        /// </summary>
        public int? NotID => GetMember<IntType>("NotID");

        /// <summary>
        /// Exclude spawns near a spawn on this alert list
        /// </summary>
        public int? NotNearAlertList => GetMember<IntType>("NotNearAlertList");

        /// <summary>
        /// Include spawns near a spawn on this alert list
        /// </summary>
        public int? NearAlertList => GetMember<IntType>("NearAlertList");

        /// <summary>
        /// Exclude spawns on this alert list
        /// </summary>
        public int? NoAlertList => GetMember<IntType>("NoAlertList");

        /// <summary>
        /// Include spawns on this alert list
        /// </summary>
        public int? AlertList => GetMember<IntType>("AlertList");

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
        public float? xLoc => GetMember<FloatType>("xLoc");

        /// <summary>
        /// Y location to base search around instead of character's
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public float? yLoc => GetMember<FloatType>("yLoc");

        /// <summary>
        /// If true, use xLoc/yLoc/zLoc insted of character's position
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bKnownLocation => GetMember<BoolType>("bKnownLocation");

        /// <summary>
        /// Exclude pets?
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNoPet => GetMember<BoolType>("bNoPet");

        /// <summary>
        /// What to sort the list by
        /// 0 = level, 1 = display name (default), 2 = race, 3 = class, 4 = distance (2D, XY), 5 = guild, 6 = id
        /// </summary>
        public int? SortBy => GetMember<IntType>("SortBy");

        /// <summary>
        /// Exclude spawns in a guild
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bNoGuild => GetMember<BoolType>("bNoGuild");

        /// <summary>
        /// Only include spawns you have line of sight to
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bLoS => GetMember<BoolType>("bLoS");

        /// <summary>
        /// Match exact name rather than partial
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bExactName => GetMember<BoolType>("bExactName");

        /// <summary>
        /// Include only targetable spawns
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bTargetable => GetMember<BoolType>("bTargetable");

        /// <summary>
        /// Bitmask of player states to include
        /// </summary>
        public int? PlayerState => GetMember<IntType>("PlayerState");

        /// <summary>
        /// Return the first spawn matching the ID or Name filters (ignores all other filters)
        /// </summary>
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");
        
        /// <summary>
        /// Include only bankers
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool bBanker => GetMember<BoolType>("bBanker");
    }
}