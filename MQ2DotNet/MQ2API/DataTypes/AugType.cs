namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AugType
    public class AugType : MQ2DataType
    {
        public IntType Slot => GetMember<IntType>("Slot");
        public IntType Type => GetMember<IntType>("Type");
        public BoolType Visible => GetMember<BoolType>("Visible");
        public BoolType Infusable => GetMember<BoolType>("Infusable");
        public BoolType Empty => GetMember<BoolType>("Empty");
        public StringType Name => GetMember<StringType>("Name");
        public ItemType Item => GetMember<ItemType>("Item");
        public SolventType Solvent => GetMember<SolventType>("Solvent");
    }
}