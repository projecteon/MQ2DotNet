namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ItemFilterDataType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType ID => GetMember<IntType>("ID");
        public BoolType AutoRoll => GetMember<BoolType>("AutoRoll");
        public BoolType Need => GetMember<BoolType>("Need");
        public BoolType Greed => GetMember<BoolType>("Greed");
        public BoolType Never => GetMember<BoolType>("Never");
        public IntType IconID => GetMember<IntType>("IconID");
        public IntType Types => GetMember<IntType>("Types");
    }
}