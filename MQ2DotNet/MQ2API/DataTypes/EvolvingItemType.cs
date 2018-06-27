namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for EvolvingItemType
    public class EvolvingItemType : MQ2DataType
    {
        public FloatType ExpPct => GetMember<FloatType>("ExpPct");
        public BoolType ExpOn => GetMember<BoolType>("ExpOn");
        public IntType Level => GetMember<IntType>("Level");
        public IntType MaxLevel => GetMember<IntType>("MaxLevel");
    }
}