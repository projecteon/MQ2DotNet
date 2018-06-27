namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for MacroQuestType
    public class MacroQuestType : EverQuestType
    {
        public StringType Error => GetMember<StringType>("Error");
        public StringType SyntaxError => GetMember<StringType>("SyntaxError");
        public StringType MQ2DataError => GetMember<StringType>("MQ2DataError");
        public StringType BuildDate => GetMember<StringType>("BuildDate");
        public IntType Build => GetMember<IntType>("Build");
        public StringType Path => GetMember<StringType>("Path");
        public StringType Version => GetMember<StringType>("Version");
        public StringType InternalName => GetMember<StringType>("InternalName");
    }
}