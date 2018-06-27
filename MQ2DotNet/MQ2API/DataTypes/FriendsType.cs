namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for FriendsType
    public class FriendsType : MQ2DataType
    {
        public StringType xFriendByName => GetMember<StringType>("xFriend");
    }
}