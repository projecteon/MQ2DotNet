namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for ClassType
    public class ClassType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public StringType Name => GetMember<StringType>("Name");
        public StringType ShortName => GetMember<StringType>("ShortName");
        public BoolType CanCast => GetMember<BoolType>("CanCast");
        public BoolType PureCaster => GetMember<BoolType>("PureCaster");
        public BoolType PetClass => GetMember<BoolType>("PetClass");
        public BoolType DruidType => GetMember<BoolType>("DruidType");
        public BoolType ShamanType => GetMember<BoolType>("ShamanType");
        public BoolType NecromancerType => GetMember<BoolType>("NecromancerType");
        public BoolType ClericType => GetMember<BoolType>("ClericType");
        public BoolType HealerType => GetMember<BoolType>("HealerType");
        public BoolType MercType => GetMember<BoolType>("MercType");
    }
}