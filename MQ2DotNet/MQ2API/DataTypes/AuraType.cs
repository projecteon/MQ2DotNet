using System;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class AuraType : MQ2DataType
    {
        internal AuraType(MQ2TypeVar typeVar) : base(typeVar)
        {
#pragma warning disable 612
            Find = new IndexedMember<IntType>(this, "Find");
#pragma warning restore 612
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
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Spawn ID of the caster
        /// </summary>
        public IntType SpawnID => GetMember<IntType>("SpawnID");

        /// <summary>
        /// Remove the aura
        /// </summary>
        public void Remove() => GetMember<MQ2DataType>("Remove");
    }
}