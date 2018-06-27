namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PluginType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public FloatType Version => GetMember<FloatType>("Version");
    }
}