namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MercenaryType : SpawnType
    {
        public IntType AAPoints => GetMember<IntType>("AAPoints");
        public StringType Stance => GetMember<StringType>("Stance");
        public new StringType State => GetMember<StringType>("State");
        public IntType StateID => GetMember<IntType>("StateID");
        public IntType xIndex => GetMember<IntType>("xIndex");
    }
}