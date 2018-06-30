// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class XTargetType : SpawnType
    {
        /// <summary>
        /// Memory address of XTargetMgr
        /// </summary>
        public IntType xAddress => GetMember<IntType>("xAddress");

        /// <summary>
        /// Extended target type e.g. Auto Hater
        /// </summary>
        public StringType TargetType => GetMember<StringType>("TargetType");

        /// <summary>
        /// Spawn ID
        /// </summary>
        public new IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Spawn's name
        /// </summary>
        public new StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Your percentage aggro on the spawn
        /// </summary>
        public IntType PctAggro => GetMember<IntType>("PctAggro");
    }
}