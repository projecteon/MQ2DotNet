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
        }

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
        /// Build number
        /// </summary>
        public int? Build => GetMember<IntType>("Build");

        /// <summary>
        /// Directory of MQ2Main.dll (equivalent of INI path, <seealso cref="MQ2.INIPath"/>)
        /// </summary>
        public string Path => GetMember<StringType>("Path");

        /// <summary>
        /// Version number of MQ2Main.dll
        /// </summary>
        public string Version => GetMember<StringType>("Version");

        /// <summary>
        /// Internal name of build e.g. RedGuides
        /// </summary>
        public string InternalName => GetMember<StringType>("InternalName");
    }
}