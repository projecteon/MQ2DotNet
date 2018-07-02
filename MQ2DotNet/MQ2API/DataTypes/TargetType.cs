// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TargetType : SpawnType
    {
        internal TargetType(MQ2TypeVar typeVar) : base(typeVar)
        {
            BuffDuration = new IndexedMember<TimeStampType, string, TimeStampType, int>(this, "BuffDuration");
            MyBuffDuration = new IndexedMember<TimeStampType, string, TimeStampType, int>(this, "MyBuffDuration");
            MyBuff = new IndexedMember<SpellType, string, SpellType, int>(this, "MyBuff");
            Buff = new IndexedMember<SpellType, string, SpellType, int>(this, "Buff");
        }

        /// <summary>
        /// Returns TRUE when the target's buffs are finished populating.
        /// </summary>
        public BoolType BuffsPopulated => GetMember<BoolType>("BuffsPopulated");

        /// <summary>
        /// Buff/debuff on the target by name or slot # (1 based)
        /// </summary>
        public IndexedMember<SpellType, string, SpellType, int> Buff { get; }

        /// <summary>
        /// Buff/debuff on the target that you cast, by name or slot # (1 based)
        /// </summary>
        public IndexedMember<SpellType, string, SpellType, int> MyBuff { get; }

        /// <summary>
        /// Total number of buffs/debuffs
        /// </summary>
        public IntType BuffCount => GetMember<IntType>("BuffCount");

        /// <summary>
        /// Total number of buffs/debuffs cast by you
        /// </summary>
        public IntType MyBuffCount => GetMember<IntType>("MyBuffCount");

        /// <summary>
        /// Remaining duration on a buff you cast by name or slot # (1 based)
        /// </summary>
        public IndexedMember<TimeStampType, string, TimeStampType, int> MyBuffDuration { get; }

        /// <summary>
        /// Remaining duration on a buff by name or slot # (1 based)
        /// </summary>
        public IndexedMember<TimeStampType, string, TimeStampType, int> BuffDuration { get; }

        /// <summary>
        /// Your percentage aggro on the target
        /// </summary>
        public IntType PctAggro => GetMember<IntType>("PctAggro");

        /// <summary>
        /// Secondary aggro percentage on the target
        /// </summary>
        public IntType SecondaryPctAggro => GetMember<IntType>("SecondaryPctAggro");

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
        public TargetBuffType Slowed => GetMember<TargetBuffType>("Slowed");

        /// <summary>
        /// Root debuff it the target has one
        /// </summary>
        public TargetBuffType Rooted => GetMember<TargetBuffType>("Rooted");

        /// <summary>
        /// Mez debuff if the target has one
        /// </summary>
        public TargetBuffType Mezzed => GetMember<TargetBuffType>("Mezzed");

        /// <summary>
        /// Cripple debuff if the target has one
        /// </summary>
        public TargetBuffType Crippled => GetMember<TargetBuffType>("Crippled");

        /// <summary>
        /// Malo debuff if the target has one
        /// </summary>
        public TargetBuffType Maloed => GetMember<TargetBuffType>("Maloed");

        /// <summary>
        /// Tash debuff if the target has one
        /// </summary>
        public TargetBuffType Tashed => GetMember<TargetBuffType>("Tashed");

        /// <summary>
        /// Snare debuff if the target has one
        /// </summary>
        public TargetBuffType Snared => GetMember<TargetBuffType>("Snared");

        /// <summary>
        /// Haste buff if the target has one
        /// </summary>
        public TargetBuffType Hasted => GetMember<TargetBuffType>("Hasted");

        /// <summary>
        /// First beneficial buff if the target has one
        /// </summary>
        public TargetBuffType Beneficial => GetMember<TargetBuffType>("Beneficial");

        /// <summary>
        /// Damage shield buff if the target has one
        /// </summary>
        public TargetBuffType DSed => GetMember<TargetBuffType>("DSed");

        /// <summary>
        /// Reverse damage shield buff if the target has one
        /// </summary>
        public TargetBuffType RevDSed => GetMember<TargetBuffType>("RevDSed");

        /// <summary>
        /// Charm debuff if the target has one
        /// </summary>
        public TargetBuffType Charmed => GetMember<TargetBuffType>("Charmed");

        /// <summary>
        /// Aego buff if the target has one
        /// </summary>
        public TargetBuffType Aego => GetMember<TargetBuffType>("Aego");

        /// <summary>
        /// Skin buff if the target has one
        /// </summary>
        public TargetBuffType Skin => GetMember<TargetBuffType>("Skin");

        /// <summary>
        /// Focus buff if the target has one
        /// </summary>
        public TargetBuffType Focus => GetMember<TargetBuffType>("Focus");

        /// <summary>
        /// Regen buff if the target has one
        /// </summary>
        public TargetBuffType Regen => GetMember<TargetBuffType>("Regen");

        /// <summary>
        /// Debuff that is increasing target's disease counter
        /// </summary>
        public TargetBuffType Diseased => GetMember<TargetBuffType>("Diseased");

        /// <summary>
        /// Debuff that is increasing target's poison counter
        /// </summary>
        public TargetBuffType Poisoned => GetMember<TargetBuffType>("Poisoned");

        /// <summary>
        /// Debuff that is increasing target's curse counter
        /// </summary>
        public TargetBuffType Cursed => GetMember<TargetBuffType>("Cursed");

        /// <summary>
        /// Debuff that is increasing target's corruption counter
        /// </summary>
        public TargetBuffType Corrupted => GetMember<TargetBuffType>("Corrupted");

        /// <summary>
        /// Symbol buff if the target has one
        /// </summary>
        public TargetBuffType Symbol => GetMember<TargetBuffType>("Symbol");

        /// <summary>
        /// Clarify buff if the target has one
        /// </summary>
        public TargetBuffType Clarity => GetMember<TargetBuffType>("Clarity");

        /// <summary>
        /// Pred buff if the target has one
        /// </summary>
        public TargetBuffType Pred => GetMember<TargetBuffType>("Pred");

        /// <summary>
        /// Strength buff if the target has one
        /// </summary>
        public TargetBuffType Strength => GetMember<TargetBuffType>("Strength");

        /// <summary>
        /// Brells buff if the target has one
        /// </summary>
        public TargetBuffType Brells => GetMember<TargetBuffType>("Brells");

        /// <summary>
        /// Spiritual Vitality buff if the target has one
        /// </summary>
        public TargetBuffType SV => GetMember<TargetBuffType>("SV");

        /// <summary>
        /// Spiritual Enlightenment buff if the target has one
        /// </summary>
        public TargetBuffType SE => GetMember<TargetBuffType>("SE");

        /// <summary>
        /// Hybrid HP buff if the target has one
        /// </summary>
        public TargetBuffType HybridHP => GetMember<TargetBuffType>("HybridHP");

        /// <summary>
        /// Growth buff if the target has one
        /// </summary>
        public TargetBuffType Growth => GetMember<TargetBuffType>("Growth");

        /// <summary>
        /// Shining buff if the target has one
        /// </summary>
        public TargetBuffType Shining => GetMember<TargetBuffType>("Shining");
    }
}