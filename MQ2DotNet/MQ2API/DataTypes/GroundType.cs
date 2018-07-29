﻿// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class GroundType : MQ2DataType
    {
        internal GroundType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Ground item ID (not the same as item ID, this is like spawn ID)
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// TODO: Document GroundType.SubID
        /// </summary>
        public int? SubID => GetMember<IntType>("SubID");

        /// <summary>
        /// ID of the zone the spawn is in?
        /// </summary>
        public int? ZoneID => GetMember<IntType>("ZoneID");

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public float? W => X;

        /// <summary>
        /// X coordinate (Westward-positive)
        /// </summary>
        public float? X => GetMember<FloatType>("X");

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public float? N => Y;

        /// <summary>
        /// Y coordinate (Northward-positive)
        /// </summary>
        public float? Y => GetMember<FloatType>("Y");

        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public float? U => Z;
        /// <summary>
        /// Z coordinate (Upward-positive)
        /// </summary>
        public float? Z => GetMember<FloatType>("Z");
        
        /// <summary>
        /// Internal name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Display name as it appears on MQ2Map
        /// </summary>
        public string DisplayName => GetMember<StringType>("DisplayName");

        /// <summary>
        /// Ground item is facing this heading
        /// </summary>
        public HeadingType Heading => GetMember<HeadingType>("Heading");

        /// <summary>
        /// 2D distance from character to the ground item in the XY plane
        /// </summary>
        public float? Distance => GetMember<FloatType>("Distance");

        /// <summary>
        /// 3D distance from character to the ground item
        /// </summary>
        public float? Distance3D => GetMember<FloatType>("Distance3D");

        /// <summary>
        /// Direction player must move to meet this ground item
        /// </summary>
        public HeadingType HeadingTo => GetMember<HeadingType>("HeadingTo");

        /// <summary>
        /// Returns TRUE if ground spawn is in line of sight
        /// </summary>
        public bool LineOfSight => GetMember<BoolType>("LineOfSight");

        /// <summary>
        /// Next ground spawn
        /// </summary>
        public GroundType Next => GetMember<GroundType>("Next");
        
        /// <summary>
        /// Previous ground spawn
        /// </summary>
        public GroundType Prev => GetMember<GroundType>("Prev");

        /// <summary>
        /// Pick up the item (must be within 20 units of it
        /// </summary>
        public void Grab() => GetMember<MQ2DataType>("Grab");
    }
}