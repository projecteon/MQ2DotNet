namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AlertListType
    public class AlertListType : MQ2DataType
    {
        public IntType MinLevel => GetMember<IntType>("MinLevel");
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");
        public IntType SpawnType => GetMember<IntType>("SpawnType");
        public IntType SpawnID => GetMember<IntType>("SpawnID");
        public IntType FromSpawnID => GetMember<IntType>("FromSpawnID");
        public FloatType Radius => GetMember<FloatType>("Radius");
        public StringType Name => GetMember<StringType>("Name");
        public StringType BodyType => GetMember<StringType>("BodyType");
        public StringType Race => GetMember<StringType>("Race");
        public StringType Class => GetMember<StringType>("Class");
        public StringType Light => GetMember<StringType>("Light");
        public Int64Type GuildID => GetMember<Int64Type>("GuildID");
        public BoolType bSpawnID => GetMember<BoolType>("bSpawnID");
        public BoolType bNotNearAlert => GetMember<BoolType>("bNotNearAlert");
        public BoolType bNearAlert => GetMember<BoolType>("bNearAlert");
        public BoolType bNoAlert => GetMember<BoolType>("bNoAlert");
        public BoolType bAlert => GetMember<BoolType>("bAlert");
        public BoolType bLFG => GetMember<BoolType>("bLFG");
        public BoolType bTrader => GetMember<BoolType>("bTrader");
        public BoolType bLight => GetMember<BoolType>("bLight");
        public BoolType bTargNext => GetMember<BoolType>("bTargNext");
        public BoolType bTargPrev => GetMember<BoolType>("bTargPrev");
        public BoolType bGroup => GetMember<BoolType>("bGroup");
        public BoolType bFellowship => GetMember<BoolType>("bFellowship");
        public BoolType bNoGroup => GetMember<BoolType>("bNoGroup");
        public BoolType bRaid => GetMember<BoolType>("bRaid");
        public BoolType bGM => GetMember<BoolType>("bGM");
        public BoolType bNamed => GetMember<BoolType>("bNamed");
        public BoolType bMerchant => GetMember<BoolType>("bMerchant");
        public BoolType bTributeMaster => GetMember<BoolType>("bTributeMaster");
        public BoolType bKnight => GetMember<BoolType>("bKnight");
        public BoolType bTank => GetMember<BoolType>("bTank");
        public BoolType bHealer => GetMember<BoolType>("bHealer");
        public BoolType bDps => GetMember<BoolType>("bDps");
        public BoolType bSlower => GetMember<BoolType>("bSlower");
        public BoolType bAura => GetMember<BoolType>("bAura");
        public BoolType bBanner => GetMember<BoolType>("bBanner");
        public BoolType bCampfire => GetMember<BoolType>("bCampfire");
        public IntType NotID => GetMember<IntType>("NotID");
        public IntType NotNearAlertList => GetMember<IntType>("NotNearAlertList");
        public IntType NearAlertList => GetMember<IntType>("NearAlertList");
        public IntType NoAlertList => GetMember<IntType>("NoAlertList");
        public IntType AlertList => GetMember<IntType>("AlertList");
        public DoubleType ZRadius => GetMember<DoubleType>("ZRadius");
        public DoubleType FRadius => GetMember<DoubleType>("FRadius");
        public FloatType xLoc => GetMember<FloatType>("xLoc");
        public FloatType yLoc => GetMember<FloatType>("yLoc");
        public BoolType bKnownLocation => GetMember<BoolType>("bKnownLocation");
        public BoolType bNoPet => GetMember<BoolType>("bNoPet");
        public IntType SortBy => GetMember<IntType>("SortBy");
        public BoolType bNoGuild => GetMember<BoolType>("bNoGuild");
        public BoolType bLoS => GetMember<BoolType>("bLoS");
        public BoolType bExactName => GetMember<BoolType>("bExactName");
        public BoolType bTargetable => GetMember<BoolType>("bTargetable");
        public IntType PlayerState => GetMember<IntType>("PlayerState");
        public SpawnType Spawn => GetMember<SpawnType>("Spawn");
    }
}