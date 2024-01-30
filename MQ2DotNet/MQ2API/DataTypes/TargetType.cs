using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the current target
    /// </summary>
    [PublicAPI]
    [MQ2Type("target")]
    public class TargetType : SpawnType
    {
        internal TargetType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Your percentage aggro on the target
        /// </summary>
        public int? PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Secondary aggro percentage on the target
        /// </summary>
        public int? SecondaryPctAggro => GetMember<IntType>("SecondaryPctAggro");

        /// <summary>
        /// Spawn that has secondary aggro
        /// </summary>
        public SpawnType SecondaryAggroPlayer => GetMember<SpawnType>("SecondaryAggroPlayer");

        /// <summary>
        /// Spawn that has aggro
        /// </summary>
        public SpawnType AggroHolder => GetMember<SpawnType>("AggroHolder");

        /// <summary>
        /// Slow debuff if the target has one
        /// </summary>
        public CachedBuffType Slowed => GetMember<CachedBuffType>("Slowed");

        /// <summary>
        /// Root debuff it the target has one
        /// </summary>
        public CachedBuffType Rooted => GetMember<CachedBuffType>("Rooted");

        /// <summary>
        /// Mez debuff if the target has one
        /// </summary>
        public CachedBuffType Mezzed => GetMember<CachedBuffType>("Mezzed");

        /// <summary>
        /// Cripple debuff if the target has one
        /// </summary>
        public CachedBuffType Crippled => GetMember<CachedBuffType>("Crippled");

        /// <summary>
        /// Malo debuff if the target has one
        /// </summary>
        public CachedBuffType Maloed => GetMember<CachedBuffType>("Maloed");

        /// <summary>
        /// Tash debuff if the target has one
        /// </summary>
        public CachedBuffType Tashed => GetMember<CachedBuffType>("Tashed");

        /// <summary>
        /// Snare debuff if the target has one
        /// </summary>
        public CachedBuffType Snared => GetMember<CachedBuffType>("Snared");

        /// <summary>
        /// Haste buff if the target has one
        /// </summary>
        public CachedBuffType Hasted => GetMember<CachedBuffType>("Hasted");

        /// <summary>
        /// First beneficial buff if the target has one
        /// </summary>
        public CachedBuffType Beneficial => GetMember<CachedBuffType>("Beneficial");

        /// <summary>
        /// Damage shield buff if the target has one
        /// </summary>
        public CachedBuffType DSed => GetMember<CachedBuffType>("DSed");

        /// <summary>
        /// Reverse damage shield buff if the target has one
        /// </summary>
        public CachedBuffType RevDSed => GetMember<CachedBuffType>("RevDSed");

        /// <summary>
        /// Charm debuff if the target has one
        /// </summary>
        public CachedBuffType Charmed => GetMember<CachedBuffType>("Charmed");

        /// <summary>
        /// Aego buff if the target has one
        /// </summary>
        public CachedBuffType Aego => GetMember<CachedBuffType>("Aego");

        /// <summary>
        /// Skin buff if the target has one
        /// </summary>
        public CachedBuffType Skin => GetMember<CachedBuffType>("Skin");

        /// <summary>
        /// Focus buff if the target has one
        /// </summary>
        public CachedBuffType Focus => GetMember<CachedBuffType>("Focus");

        /// <summary>
        /// Regen buff if the target has one
        /// </summary>
        public CachedBuffType Regen => GetMember<CachedBuffType>("Regen");

        /// <summary>
        /// Debuff that is increasing target's disease counter
        /// </summary>
        public CachedBuffType Diseased => GetMember<CachedBuffType>("Diseased");

        /// <summary>
        /// Debuff that is increasing target's poison counter
        /// </summary>
        public CachedBuffType Poisoned => GetMember<CachedBuffType>("Poisoned");

        /// <summary>
        /// Debuff that is increasing target's curse counter
        /// </summary>
        public CachedBuffType Cursed => GetMember<CachedBuffType>("Cursed");

        /// <summary>
        /// Debuff that is increasing target's corruption counter
        /// </summary>
        public CachedBuffType Corrupted => GetMember<CachedBuffType>("Corrupted");

        /// <summary>
        /// Symbol buff if the target has one
        /// </summary>
        public CachedBuffType Symbol => GetMember<CachedBuffType>("Symbol");

        /// <summary>
        /// Clarify buff if the target has one
        /// </summary>
        public CachedBuffType Clarity => GetMember<CachedBuffType>("Clarity");

        /// <summary>
        /// Pred buff if the target has one
        /// </summary>
        public CachedBuffType Pred => GetMember<CachedBuffType>("Pred");

        /// <summary>
        /// Strength buff if the target has one
        /// </summary>
        public CachedBuffType Strength => GetMember<CachedBuffType>("Strength");

        /// <summary>
        /// Brells buff if the target has one
        /// </summary>
        public CachedBuffType Brells => GetMember<CachedBuffType>("Brells");

        /// <summary>
        /// Spiritual Vitality buff if the target has one
        /// </summary>
        public CachedBuffType SV => GetMember<CachedBuffType>("SV");

        /// <summary>
        /// Spiritual Enlightenment buff if the target has one
        /// </summary>
        public CachedBuffType SE => GetMember<CachedBuffType>("SE");

        /// <summary>
        /// Hybrid HP buff if the target has one
        /// </summary>
        public CachedBuffType HybridHP => GetMember<CachedBuffType>("HybridHP");

        /// <summary>
        /// Growth buff if the target has one
        /// </summary>
        public CachedBuffType Growth => GetMember<CachedBuffType>("Growth");

        /// <summary>
        /// Shining buff if the target has one
        /// </summary>
        public CachedBuffType Shining => GetMember<CachedBuffType>("Shining");

        /// <summary>
        /// Fear debuff if the target has one
        /// </summary>
        public CachedBuffType Feared => GetMember<CachedBuffType>("Feared");

        /// <summary>
        /// Silence debuff if the target has one
        /// </summary>
        public CachedBuffType Silenced => GetMember<CachedBuffType>("Silenced");

        /// <summary>
        /// Invulnerability buff if the target has one
        /// </summary>
        public CachedBuffType Invulnerable => GetMember<CachedBuffType>("Invulnerable");

        /// <summary>
        /// DoT debuff if the target has one
        /// </summary>
        public CachedBuffType Dotted => GetMember<CachedBuffType>("Dotted");

        /// <summary>
        /// Maximum range from which the character can melee hit the target
        /// </summary>
        public float? MaxMeleeTo => GetMember<FloatType>("MaxMeleeTo");
    }
}