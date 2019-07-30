using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the character in the select list
    /// </summary>
    [PublicAPI]
    [MQ2Type("charselectlist")]
    public class CharSelectListType : MQ2DataType
    {
        internal CharSelectListType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Character's name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Character's level
        /// </summary>
        public int? Level => GetMember<IntType>("Level");

        /// <summary>
        /// ID of the zone the character is in
        /// </summary>
        public int? ZoneID => GetMember<IntType>("ZoneID");

        /// <summary>
        /// Total number of characters in the character select list
        /// </summary>
        public int? Count => GetMember<IntType>("Count");

        /// <summary>
        /// Character's class
        /// </summary>
        public string Class => GetMember<StringType>("Class");

        /// <summary>
        /// Character's race
        /// </summary>
        public string Race => GetMember<StringType>("Race");
    }
}