﻿// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CharSelectListType : MQ2DataType
    {
        internal CharSelectListType(MQ2TypeVar typeVar) : base(typeVar)
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
    }
}