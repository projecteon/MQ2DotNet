namespace MQ2DotNet.MQ2API.DataTypes
{
    public class FriendsType : MQ2DataType
    {
        internal FriendsType(MQ2TypeVar typeVar) : base(typeVar)
        {
            xFriend = new IndexedMember<StringType, int, BoolType, string>(this, "xFriend");
        }

        /// <summary>
        /// Name of a friend by index (1 based) or true/false if a name is on your friend list
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IndexedMember<StringType, int, BoolType, string> xFriend { get; }
    }
}