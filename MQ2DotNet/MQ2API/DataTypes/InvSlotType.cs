namespace MQ2DotNet.MQ2API.DataTypes
{
    public class InvSlotType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public ItemType Item => GetMember<ItemType>("Item");
        public InvSlotType Pack => GetMember<InvSlotType>("Pack");
        public IntType Slot => GetMember<IntType>("Slot");
        public StringType Name => GetMember<StringType>("Name");
    }
}