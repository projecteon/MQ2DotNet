namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for CurrentZoneType
    public class CurrentZoneType : MQ2DataType
    {
        public IntType Address => GetMember<IntType>("Address");
        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
        public StringType ShortName => GetMember<StringType>("ShortName");
        public IntType Type => GetMember<IntType>("Type");
        public FloatType Gravity => GetMember<FloatType>("Gravity");
        public IntType SkyType => GetMember<IntType>("SkyType");
        public FloatType MinClip => GetMember<FloatType>("MinClip");
        public FloatType MaxClip => GetMember<FloatType>("MaxClip");
        public IntType ZoneType => GetMember<IntType>("ZoneType");
        public BoolType Dungeon => Indoor;
        public BoolType Indoor => GetMember<BoolType>("Indoor");
        public BoolType Outdoor => GetMember<BoolType>("Outdoor");
        public BoolType NoBind => GetMember<BoolType>("NoBind");
    }
}