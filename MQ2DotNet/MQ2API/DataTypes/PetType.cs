using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a pet
    /// </summary>
    [PublicAPI]
    [MQ2Type("pet")]
    public class PetType : MQ2DataType
    {
        internal PetType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            BuffDuration = new IndexedMember<TimeStampType, int, TimeStampType, string>(this, "BuffDuration");
            Buff = new IndexedMember<SpellType, int, IntType, string>(this, "Buff");
        }

        /// <summary>
        /// A buff on your pet index (1 based), or the index of a buff on your pet by name
        /// </summary>
        public IndexedMember<SpellType, int, IntType, string> Buff { get; }

        /// <summary>
        /// Remaining duration on a pet's buff, by spell name or index (1 based)
        /// </summary>
        public IndexedMember<TimeStampType, int, TimeStampType, string> BuffDuration { get; }
    
        /// <summary>
        /// Is pet in combat?
        /// </summary>
        public bool Combat => GetMember<BoolType>("Combat");

        /// <summary>
        /// Is GHold enabled?
        /// </summary>
        public bool GHold => GetMember<BoolType>("GHold");

        /// <summary>
        /// Is Hold enabled?
        /// </summary>
        public bool Hold => GetMember<BoolType>("Hold");

        /// <summary>
        /// Is ReGroup enabled?
        /// </summary>
        public bool ReGroup => GetMember<BoolType>("ReGroup");

        /// <summary>
        /// Current stance, either "FOLLOW" or "GUARD"
        /// </summary>
        public string Stance => GetMember<StringType>("Stance");

        /// <summary>
        /// Is Stop enabled?
        /// </summary>
        public bool Stop => GetMember<BoolType>("Stop");
        
        /// <summary>
        /// Pet's target
        /// </summary>
        public SpawnType Target => GetMember<SpawnType>("Target");

        /// <summary>
        /// Is Taunt enabled?
        /// </summary>
        public bool Taunt => GetMember<BoolType>("Taunt");
    }
}