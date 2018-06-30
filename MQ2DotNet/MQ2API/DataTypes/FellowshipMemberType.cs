// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for FellowshipMemberType
    public class FellowshipMemberType : MQ2DataType
    {
        /// <summary>
        /// Zone the member is currently in
        /// </summary>
        public ZoneType Zone => GetMember<ZoneType>("Zone");

        /// <summary>
        /// Member's level
        /// </summary>
        public IntType Level => GetMember<IntType>("Level");

        /// <summary>
        /// Member's class
        /// </summary>
        public ClassType Class => GetMember<ClassType>("Class");

        /// <summary>
        /// How long since the member was last online
        /// </summary>
        public TicksType LastOn => GetMember<TicksType>("LastOn");

        /// <summary>
        /// Member's name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");
    }
}