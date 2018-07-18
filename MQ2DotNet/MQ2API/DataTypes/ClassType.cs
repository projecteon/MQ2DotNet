// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ClassType : MQ2DataType
    {
        internal ClassType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Full name of the class e.g. Cleric
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// 3 letter name e.g. CLR
        /// </summary>
        public string ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// Can cast spells, including Bard
        /// </summary>
        public BoolType CanCast => GetMember<BoolType>("CanCast");

        /// <summary>
        /// Any one of: Cleric, Druid, Shaman, Necromancer, Wizard, Mage, Enchanter
        /// </summary>
        public BoolType PureCaster => GetMember<BoolType>("PureCaster");

        /// <summary>
        /// Any one of: Shaman, Necromancer, Mage, Beastlord
        /// </summary>
        public BoolType PetClass => GetMember<BoolType>("PetClass");

        /// <summary>
        /// Druid/Ranger?
        /// </summary>
        public BoolType DruidType => GetMember<BoolType>("DruidType");

        /// <summary>
        /// Shaman/Beastlord?
        /// </summary>
        public BoolType ShamanType => GetMember<BoolType>("ShamanType");

        /// <summary>
        /// Necromancer/Shadow Knight?
        /// </summary>
        public BoolType NecromancerType => GetMember<BoolType>("NecromancerType");

        /// <summary>
        /// Cleric/Paladin?
        /// </summary>
        public BoolType ClericType => GetMember<BoolType>("ClericType");

        /// <summary>
        /// Cleric/Druid/Shaman?
        /// </summary>
        public BoolType HealerType => GetMember<BoolType>("HealerType");

        /// <summary>
        /// Mercenary?
        /// </summary>
        public BoolType MercType => GetMember<BoolType>("MercType");
    }
}