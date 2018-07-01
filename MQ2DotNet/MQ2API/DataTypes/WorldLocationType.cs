// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This type is only used for character's bound locations, VarPtr.Dword is an index in CHARINFO2::BoundLocations
    /// </summary>
    public class WorldLocationType : MQ2DataType
    {
        /// <summary>
        /// Zone ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Zone information
        /// </summary>
        public ZoneType Zone => GetMember<ZoneType>("Zone");

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public FloatType Y => GetMember<FloatType>("Y");

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public FloatType X => GetMember<FloatType>("X");

        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public FloatType Z => GetMember<FloatType>("Z");

        /// <summary>
        /// Direction facing
        /// </summary>
        public FloatType Heading => GetMember<FloatType>("Heading");
    }
}