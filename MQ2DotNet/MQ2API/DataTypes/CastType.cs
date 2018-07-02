namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CastType : MQ2DataType
    {
        internal CastType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public BoolType Active => GetMember<BoolType>("Active");
        public SpellType Effect => GetMember<SpellType>("Effect");
        public SpellType Stored => GetMember<SpellType>("Stored");
        public IntType Timing => GetMember<IntType>("Timing");
        public StringType Status => GetMember<StringType>("Status");
        public StringType Result => GetMember<StringType>("Result");
        public StringType Return => GetMember<StringType>("Return");
        public BoolType Ready => GetMember<BoolType>("Ready");
        public BoolType Taken => GetMember<BoolType>("Taken");
    }
}