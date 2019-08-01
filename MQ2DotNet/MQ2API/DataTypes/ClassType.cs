using System;
using JetBrains.Annotations;
using MQ2DotNet.EQ;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a character class
    /// </summary>
    [PublicAPI]
    [MQ2Type("class")]
    public class ClassType : MQ2DataType
    {
        internal ClassType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// TODO: What is this
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

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
        public bool CanCast => GetMember<BoolType>("CanCast");

        /// <summary>
        /// Any one of: Cleric, Druid, Shaman, Necromancer, Wizard, Mage, Enchanter
        /// </summary>
        public bool PureCaster => GetMember<BoolType>("PureCaster");

        /// <summary>
        /// Any one of: Shaman, Necromancer, Mage, Beastlord
        /// </summary>
        public bool PetClass => GetMember<BoolType>("PetClass");

        /// <summary>
        /// Druid/Ranger?
        /// </summary>
        public bool DruidType => GetMember<BoolType>("DruidType");

        /// <summary>
        /// Shaman/Beastlord?
        /// </summary>
        public bool ShamanType => GetMember<BoolType>("ShamanType");

        /// <summary>
        /// Necromancer/Shadow Knight?
        /// </summary>
        public bool NecromancerType => GetMember<BoolType>("NecromancerType");

        /// <summary>
        /// Cleric/Paladin?
        /// </summary>
        public bool ClericType => GetMember<BoolType>("ClericType");

        /// <summary>
        /// Cleric/Druid/Shaman?
        /// </summary>
        public bool HealerType => GetMember<BoolType>("HealerType");

        /// <summary>
        /// Mercenary?
        /// </summary>
        public bool MercType => GetMember<BoolType>("MercType");

        /// <summary>
        /// Implicit conversion to a Class enumeration
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator Class?(ClassType typeVar) => (Class?) (1 << (typeVar?.VarPtr.Int - 1));
    }
}