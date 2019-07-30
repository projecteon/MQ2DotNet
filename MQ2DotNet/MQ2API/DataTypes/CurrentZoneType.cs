using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the current zone
    /// </summary>
    [PublicAPI]
    [MQ2Type("currentzone")]
    public class CurrentZoneType : MQ2DataType
    {
        internal CurrentZoneType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Memory address of the TODO: struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");
        
        /// <summary>
        /// ID of the zone
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Full name of the zone e.g. "The Plane of Knowledge"
        /// </summary>
        public string Name => GetMember<StringType>("Name");
        
        /// <summary>
        /// Short name of the zone e.g. "PoKnowledge"
        /// </summary>
        public string ShortName => GetMember<StringType>("ShortName");
        
        /// <summary>
        /// TODO: Description
        /// </summary>
        public int? Type => GetMember<IntType>("Type");
        
        /// <summary>
        /// Value of gravity in the zone
        /// </summary>
        public float? Gravity => GetMember<FloatType>("Gravity");
        
        /// <summary>
        /// Type of sky in the zone
        /// </summary>
        public int? SkyType => GetMember<IntType>("SkyType");
        
        /// <summary>
        /// Minimum setting for far clip plane
        /// </summary>
        public float? MinClip => GetMember<FloatType>("MinClip");
        
        /// <summary>
        /// Maximum setting for far clip plane
        /// </summary>
        public float? MaxClip => GetMember<FloatType>("MaxClip");

        /// <summary>
        /// Zone type:0=Indoor Dungeon 1=Outdoor 2=Outdoor City 3=Dungeon City 4=Indoor City 5=Outdoor Dungeon
        /// </summary>
        public int? ZoneType => GetMember<IntType>("ZoneType");
        
        /// <summary>
        /// Is the zone a dungeon, i.e. mounts cannot be used
        /// </summary>
        public bool Dungeon => Indoor;
        
        /// <summary>
        /// Is the zone indoors, i.e. mounts cannot be used
        /// </summary>
        public bool Indoor => GetMember<BoolType>("Indoor");
        
        /// <summary>
        /// Is the zone outdoors, i.e. mounts can be used
        /// </summary>
        public bool Outdoor => GetMember<BoolType>("Outdoor");
        
        /// <summary>
        /// Binding in the zone is disabled TODO: For melee only or everyone?
        /// </summary>
        public bool NoBind => GetMember<BoolType>("NoBind");
    }
}