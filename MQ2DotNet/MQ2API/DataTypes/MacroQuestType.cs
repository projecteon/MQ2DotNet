using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for general information about MQ2
    /// </summary>
    [PublicAPI]
    [MQ2Type("macroquest")]
    public class MacroQuestType : EverQuestType
    {
        internal MacroQuestType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            _path = new IndexedStringMember<string>(this, "Path");
        }
        /// <summary>
        /// Directory that Macroquest.exe launched from. When passed root/config/crashdumps/logs/mqini/macros/plugins/resources, returns the respective path
        /// Path[Option]
        /// 
        /// Index values:
        /// - root
        /// - config
        /// - crashdumps
        /// - logs
        /// - mqini
        /// - macros
        /// - plugins
        /// - resources
        /// </summary>
        private readonly IndexedStringMember<string> _path;

        public string PathRoot => _path["root"];
        public string PathConfig => _path["config"];
        public string PathCrashDumps => _path["crashdumps"];
        public string PathLogs => _path["logs"];
        public string PathMQIni => _path["mqini"];
        public string PathMacros => _path["macros"];
        public string PathPlugins => _path["plugins"];
        public string PathResources => _path["resources"];

        /// <summary>
        /// Last normal error message
        /// </summary>
        public string Error => GetMember<StringType>("Error");

        /// <summary>
        /// Last syntax error message
        /// </summary>
        public string SyntaxError => GetMember<StringType>("SyntaxError");

        /// <summary>
        /// Last MQ2Data parsing error message
        /// </summary>
        public string MQ2DataError => GetMember<StringType>("MQ2DataError");

        /// <summary>
        /// Date that MQ2Main.dll was built
        /// </summary>
        public string BuildDate => GetMember<StringType>("BuildDate");

        /// <summary>
        /// The build (client target) name for MQ2Main.dll (Live, Test, Beta, Emu)
        /// </summary>
        public string BuildName => GetMember<StringType>("BuildName");

        /// <summary>
        /// Build number
        /// </summary>
        public int? Build => GetMember<IntType>("Build");

        /// <summary>
        /// Version number of MQ2Main.dll
        /// </summary>
        public string Version => GetMember<StringType>("Version");

        /// <summary>
        /// Internal name of build e.g. RedGuides
        /// </summary>
        public string InternalName => GetMember<StringType>("InternalName");

        /// <summary>
        /// Which parser engine is currently active
        /// </summary>
        public int? Parser => GetMember<IntType>("Parser");

        /// <summary>
        /// Is anonymized?
        /// </summary>
        public bool Anonymize => GetMember<BoolType>("Anonymize");
    }
}