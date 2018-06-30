// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class PluginType : MQ2DataType
    {
        /// <summary>
        /// Plugin's name e.g. mq2cast
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Plugin's version as exported by the PLUGIN_VERSION macro
        /// </summary>
        public FloatType Version => GetMember<FloatType>("Version");
    }
}