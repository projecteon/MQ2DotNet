// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class XTargetType : MQ2DataType
    {
        internal XTargetType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Memory address of XTargetMgr
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Extended target type e.g. Auto Hater
        /// </summary>
        public string TargetType => GetMember<StringType>("TargetType");

        /// <summary>
        /// Spawn ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Spawn's name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Your percentage aggro on the spawn
        /// </summary>
        public int? PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Spawn in the XTarget slot
        /// </summary>
        public SpawnType Spawn => TLO.Spawn["id " + ID];
    }
}