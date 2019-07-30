using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a switch object
    /// </summary>
    [PublicAPI]
    [MQ2Type("switch")]
    public class SwitchType : MQ2DataType
    {
        internal SwitchType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the DOOR struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Switch ID
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public float? X => GetMember<FloatType>("X");

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public float? Y => GetMember<FloatType>("Y");

        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public float? Z => GetMember<FloatType>("Z");

        /// <summary>
        /// X coordinate of "closed" switch (Westward-positive)
        /// </summary>
        public float? DefaultX => GetMember<FloatType>("DefaultX");

        /// <summary>
        /// Y coordinate of "closed" switch (Northward-positive)
        /// </summary>
        public float? DefaultY => GetMember<FloatType>("DefaultY");

        /// <summary>
        /// Z coordinate of "closed" switch (Upward-positive)
        /// </summary>
        public float? DefaultZ => GetMember<FloatType>("DefaultZ");

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
        public bool Open => GetMember<BoolType>("Open");

        /// <summary>
        /// Direction player must move to meet this switch
        /// </summary>
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");

        /// <summary>
        /// Name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// 2D distance from player to this switch in the XY plane
        /// </summary>
        public float? Distance => GetMember<FloatType>("Distance");

        /// <summary>
        /// 3D distance from player to this switch
        /// </summary>
        public float? Distance3D => GetMember<FloatType>("Distance3D");

        /// <summary>
        /// Returns TRUE if the switch is in LoS
        /// </summary>
        public bool LineOfSight => GetMember<BoolType>("LineOfSight");

        /// <summary>
        /// Toggle the switch, equivalent of clicking on it. Uses an item if you have it on the cursor
        /// </summary>
        public void Toggle() => GetMember<MQ2DataType>("Toggle");
    }
}