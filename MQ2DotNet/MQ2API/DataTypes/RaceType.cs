// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class RaceType : MQ2DataType
    {
        /// <summary>
        /// ID of the race, this should correspond to the <see cref="Race"/> enum
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Full name of the race e.g. Froglok
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");
    }
}