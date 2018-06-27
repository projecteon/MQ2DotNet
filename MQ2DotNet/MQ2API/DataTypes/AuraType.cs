namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AuraType
    public class AuraType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public IntType Find => GetMember<IntType>("Find");
        public StringType Name => GetMember<StringType>("Name");
        public IntType SpawnID => GetMember<IntType>("SpawnID");
    }
}