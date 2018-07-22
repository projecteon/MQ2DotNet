// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MacroQuestType : EverQuestType
    {
        internal MacroQuestType(MQ2TypeVar typeVar) : base(typeVar)
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
        public int Build => GetMember<IntType>("Build");

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