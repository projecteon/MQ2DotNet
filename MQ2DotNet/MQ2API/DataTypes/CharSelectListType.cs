// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CharSelectListType : MQ2DataType
    {
        /// <summary>
        /// Character's name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Character's level
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// ID of the zone the character is in
        /// </summary>
        public IntType ZoneID => GetMember<IntType>("ZoneID");

        /// <summary>
        /// Total number of characters in the character select list
        /// </summary>
        public IntType Count => GetMember<IntType>("Count");
    }
}