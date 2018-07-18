namespace MQ2DotNet.MQ2API.DataTypes
{
    public class CurrentZoneType : MQ2DataType
    {
        internal CurrentZoneType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Memory address of the TODO: struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");
        
        /// <summary>
        /// ID of the zone
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

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
        public IntType Type => GetMember<IntType>("Type");
        
        /// <summary>
        /// Value of gravity in the zone
        /// </summary>
        public FloatType Gravity => GetMember<FloatType>("Gravity");
        
        /// <summary>
        /// Type of sky in the zone
        /// </summary>
        public IntType SkyType => GetMember<IntType>("SkyType");
        
        /// <summary>
        /// Minimum setting for far clip plane
        /// </summary>
        public FloatType MinClip => GetMember<FloatType>("MinClip");
        
        /// <summary>
        /// Maximum setting for far clip plane
        /// </summary>
        public FloatType MaxClip => GetMember<FloatType>("MaxClip");

        /// <summary>
        /// Zone type:0=Indoor Dungeon 1=Outdoor 2=Outdoor City 3=Dungeon City 4=Indoor City 5=Outdoor Dungeon
        /// </summary>
        public IntType ZoneType => GetMember<IntType>("ZoneType");
        
        /// <summary>
        /// Is the zone a dungeon, i.e. mounts cannot be used
        /// </summary>
        public BoolType Dungeon => Indoor;
        
        /// <summary>
        /// Is the zone indoors, i.e. mounts cannot be used
        /// </summary>
        public BoolType Indoor => GetMember<BoolType>("Indoor");
        
        /// <summary>
        /// Is the zone outdoors, i.e. mounts can be used
        /// </summary>
        public BoolType Outdoor => GetMember<BoolType>("Outdoor");
        
        /// <summary>
        /// Binding in the zone is disabled TODO: For melee only or everyone?
        /// </summary>
        public BoolType NoBind => GetMember<BoolType>("NoBind");
    }
}