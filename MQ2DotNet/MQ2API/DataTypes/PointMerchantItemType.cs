namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PointMerchantItemType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType ItemID => GetMember<IntType>("ItemID");
        public Int64Type Price => GetMember<Int64Type>("Price");
        public IntType ThemeID => GetMember<IntType>("ThemeID");
        public BoolType IsStackable => GetMember<BoolType>("IsStackable");
        public BoolType IsLore => GetMember<BoolType>("IsLore");
        public IntType RaceMask => GetMember<IntType>("RaceMask");
        public IntType ClassMask => GetMember<IntType>("ClassMask");
        public BoolType CanUse => GetMember<BoolType>("CanUse");
    }
}