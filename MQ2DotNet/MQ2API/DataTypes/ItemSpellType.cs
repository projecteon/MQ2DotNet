using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a spell effect on an item
    /// </summary>
    [PublicAPI]
    [MQ2Type("itemspell")]
    public class ItemSpellType : MQ2DataType
    {
        internal ItemSpellType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? SpellID => GetMember<IntType>("SpellID");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? RequiredLevel => GetMember<IntType>("RequiredLevel");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? EffectType => GetMember<IntType>("EffectType");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? EffectiveCasterLevel => GetMember<IntType>("EffectiveCasterLevel");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? MaxCharges => GetMember<IntType>("MaxCharges");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? CastTime => GetMember<IntType>("CastTime");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? TimerID => GetMember<IntType>("TimerID");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? RecastType => GetMember<IntType>("RecastType");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? ProcRate => GetMember<IntType>("ProcRate");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public string OtherName => GetMember<StringType>("OtherName");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? OtherID => GetMember<IntType>("OtherID");

        /// <summary>
        /// The spell
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");
    }
}