namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for CorpseType
    public class CorpseType : SpawnType
    {
        public BoolType Open => GetMember<BoolType>("Open");
        public ItemType Item => GetMember<ItemType>("Item");
        public IntType Items => GetMember<IntType>("Items");
    }
}