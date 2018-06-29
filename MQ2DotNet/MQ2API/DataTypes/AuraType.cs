using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AuraType
    public class AuraType : MQ2DataType
    {
        public AuraType()
        {
            Find = new IndexedMember<IntType>(this, "Find");
        }

        /// <summary>
        /// Appears to be the slot the aura is in. 1 based
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Returns the position of the index if found within the aura's name
        /// </summary>
        [Obsolete]
        public IndexedMember<IntType> Find { get; }

        /// <summary>
        /// Name of the aura
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Spawn ID of the caster
        /// </summary>
        public IntType SpawnID => GetMember<IntType>("SpawnID");
    }
}