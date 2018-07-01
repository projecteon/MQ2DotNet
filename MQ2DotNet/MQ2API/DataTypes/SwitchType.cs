// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SwitchType : MQ2DataType
    {
        /// <summary>
        /// Memory address of the DOOR struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Switch ID
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public FloatType X => GetMember<FloatType>("X");

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public FloatType Y => GetMember<FloatType>("Y");

        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public FloatType Z => GetMember<FloatType>("Z");

        /// <summary>
        /// X coordinate of "closed" switch (Westward-positive)
        /// </summary>
        public FloatType DefaultX => GetMember<FloatType>("DefaultX");

        /// <summary>
        /// Y coordinate of "closed" switch (Northward-positive)
        /// </summary>
        public FloatType DefaultY => GetMember<FloatType>("DefaultY");

        /// <summary>
        /// Z coordinate of "closed" switch (Upward-positive)
        /// </summary>
        public FloatType DefaultZ => GetMember<FloatType>("DefaultZ");

        /// <summary>
        /// Switch is facing this heading
        /// </summary>
        public HeadingType Heading => GetMember<HeadingType>("Heading");

        /// <summary>
        /// When "closed", switch is facing this heading
        /// </summary>
        public HeadingType DefaultHeading => GetMember<HeadingType>("DefaultHeading");

        /// <summary>
        /// Open?
        /// </summary>
        public BoolType Open => GetMember<BoolType>("Open");

        /// <summary>
        /// Direction player must move to meet this switch
        /// </summary>
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");

        /// <summary>
        /// Name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// 2D distance from player to this switch in the XY plane
        /// </summary>
        public FloatType Distance => GetMember<FloatType>("Distance");

        /// <summary>
        /// 3D distance from player to this switch
        /// </summary>
        public FloatType Distance3D => GetMember<FloatType>("Distance3D");

        /// <summary>
        /// Returns TRUE if the switch is in LoS
        /// </summary>
        public BoolType LineOfSight => GetMember<BoolType>("LineOfSight");
    }
}