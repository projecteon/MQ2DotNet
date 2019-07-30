using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a world location
    /// </summary>
    /// <remarks>This type is only used for character's bound locations, VarPtr.Dword is an index in CHARINFO2::BoundLocations</remarks>
    [PublicAPI]
    [MQ2Type("worldlocation")]
    public class WorldLocationType : MQ2DataType
    {
        internal WorldLocationType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Zone ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Zone information
        /// </summary>
        public ZoneType Zone => GetMember<ZoneType>("Zone");

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public float? Y => GetMember<FloatType>("Y");

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public float? X => GetMember<FloatType>("X");

        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public float? Z => GetMember<FloatType>("Z");

        /// <summary>
        /// Direction facing
        /// </summary>
        public float? Heading => GetMember<FloatType>("Heading");
    }
}