namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SolventType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public IntType ID => GetMember<IntType>("ID");
        public ItemType Item => GetMember<ItemType>("Item");
        public IntType Count => GetMember<IntType>("Count");
    }
}