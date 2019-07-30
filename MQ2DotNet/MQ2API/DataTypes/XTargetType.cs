using JetBrains.Annotations;
using MQ2DotNet.Services;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an entry in the xtarget list
    /// </summary>
    [PublicAPI]
    [MQ2Type("xtarget")]
    public class XTargetType : MQ2DataType // MQ2XTargetType inherits MQ2SpawnType, but we can't do this as it needs to do a transform on the VarPtr before calling the base's GetMember
    {
        internal XTargetType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
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
        public SpawnType GetSpawn(TLO tlo) => tlo.Spawn["id " + ID];
    }
}