using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a plugin
    /// </summary>
    [PublicAPI]
    [MQ2Type("plugin")]
    public class PluginType : MQ2DataType
    {
        internal PluginType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Plugin's name e.g. mq2cast
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Plugin's version as exported by the PLUGIN_VERSION macro
        /// </summary>
        public float? Version => GetMember<FloatType>("Version");
    }
}