namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for PetType
    public class PetType : MQ2DataType
    {
        public SpellType BuffByIndex => GetMember<SpellType>("BuffByIndex");
        public IntType BuffByName => GetMember<IntType>("BuffByName");
        public TimeStampType BuffDuration => GetMember<TimeStampType>("BuffDuration");
        public BoolType Combat => GetMember<BoolType>("Combat");
        public BoolType GHold => GetMember<BoolType>("GHold");
        public BoolType Hold => GetMember<BoolType>("Hold");
        public BoolType ReGroup => GetMember<BoolType>("ReGroup");
        public StringType Stance => GetMember<StringType>("Stance");
        public BoolType Stop => GetMember<BoolType>("Stop");
        public SpawnType Target => GetMember<SpawnType>("Target");
        public BoolType Taunt => GetMember<BoolType>("Taunt");
    }
}