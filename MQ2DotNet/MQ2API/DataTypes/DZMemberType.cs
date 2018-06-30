namespace MQ2DotNet.MQ2API.DataTypes
{
    public class DZMemberType : MQ2DataType
    {
        /// <summary>
        /// The name of the member
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// The status of the member - one of the following: Unknown, Online, Offline, In Dynamic Zone, Link Dead
        /// </summary>
        public StringType Status => GetMember<StringType>("Status");
    }
}