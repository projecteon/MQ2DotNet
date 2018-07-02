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
        public StringType Error => GetMember<StringType>("Error");

        /// <summary>
        /// Last syntax error message
        /// </summary>
        public StringType SyntaxError => GetMember<StringType>("SyntaxError");

        /// <summary>
        /// Last MQ2Data parsing error message
        /// </summary>
        public StringType MQ2DataError => GetMember<StringType>("MQ2DataError");

        /// <summary>
        /// Date that MQ2Main.dll was built
        /// </summary>
        public StringType BuildDate => GetMember<StringType>("BuildDate");

        /// <summary>
        /// Build number
        /// </summary>
        public IntType Build => GetMember<IntType>("Build");

        /// <summary>
        /// Directory of MQ2Main.dll (equivalent of INI path, <seealso cref="MQ2.INIPath"/>)
        /// </summary>
        public StringType Path => GetMember<StringType>("Path");

        /// <summary>
        /// Version number of MQ2Main.dll
        /// </summary>
        public StringType Version => GetMember<StringType>("Version");

        /// <summary>
        /// Internal name of build e.g. RedGuides
        /// </summary>
        public StringType InternalName => GetMember<StringType>("InternalName");
    }
}