namespace MQ2DotNet.MQ2API.DataTypes
{
    public class XTargetType : SpawnType
    {
        public IntType xAddress => GetMember<IntType>("xAddress");
        public StringType TargetType => GetMember<StringType>("TargetType");
        public new IntType ID => GetMember<IntType>("ID");
        public new StringType Name => GetMember<StringType>("Name");
        public IntType PctAggro => GetMember<IntType>("PctAggro");
    }
}