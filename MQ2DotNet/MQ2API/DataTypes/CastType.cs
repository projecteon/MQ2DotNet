namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CastType : MQ2DataType
    {
        internal CastType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public bool Active => GetMember<BoolType>("Active");
        public SpellType Effect => GetMember<SpellType>("Effect");
        public SpellType Stored => GetMember<SpellType>("Stored");
        public int Timing => GetMember<IntType>("Timing");
        public string Status => GetMember<StringType>("Status");
        public string Result => GetMember<StringType>("Result");
        public string Return => GetMember<StringType>("Return");
        public bool Ready => GetMember<BoolType>("Ready");
        public bool Taken => GetMember<BoolType>("Taken");
    }
}