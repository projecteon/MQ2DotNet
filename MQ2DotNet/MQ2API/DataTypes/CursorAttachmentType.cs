namespace MQ2DotNet.MQ2API.DataTypes
{
    [MQ2Type("cursorattachment")]
    public class CursorAttachmentType : MQ2DataType
    {
        public CursorAttachmentType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
        }

        public int? Index => GetMember<IntType>("Index");
        public int? IconID => GetMember<IntType>("IconID");
        public int? ItemID => GetMember<IntType>("ItemID");
        public string Type => GetMember<StringType>("Type");
        public int? Quantity => GetMember<IntType>("Quantity");
        public ItemType Item => GetMember<ItemType>("Item");
        public SpellType Spell => GetMember<SpellType>("Spell");
        public string ButtonText => GetMember<StringType>("ButtonText");
    }
}
