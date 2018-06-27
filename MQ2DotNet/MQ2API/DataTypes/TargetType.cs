namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TargetType : SpawnType
    {
        public TargetType()
        {
            BuffDuration = new IndexedMember<TimeStampType>(this, "BuffDuration");
            MyBuffDuration = new IndexedMember<TimeStampType>(this, "MyBuffDuration");
            MyBuff = new IndexedMember<SpellType>(this, "MyBuff");
            Buff = new IndexedMember<SpellType>(this, "Buff");
        }

        public BoolType BuffsPopulated => GetMember<BoolType>("BuffsPopulated");
        public IndexedMember<SpellType> Buff { get; }
        public IndexedMember<SpellType> MyBuff { get; }
        public IntType BuffCount => GetMember<IntType>("BuffCount");
        public IntType MyBuffCount => GetMember<IntType>("MyBuffCount");
        public IndexedMember<TimeStampType> MyBuffDuration { get; }
        public IndexedMember<TimeStampType> BuffDuration { get; }
        public IntType PctAggro => GetMember<IntType>("PctAggro");
        public IntType SecondaryPctAggro => GetMember<IntType>("SecondaryPctAggro");
        public SpawnType SecondaryAggroPlayer => GetMember<SpawnType>("SecondaryAggroPlayer");
        public SpawnType AggroHolder => GetMember<SpawnType>("AggroHolder");
        public TargetBuffType Slowed => GetMember<TargetBuffType>("Slowed");
        public TargetBuffType Rooted => GetMember<TargetBuffType>("Rooted");
        public TargetBuffType Mezzed => GetMember<TargetBuffType>("Mezzed");
        public TargetBuffType Crippled => GetMember<TargetBuffType>("Crippled");
        public TargetBuffType Maloed => GetMember<TargetBuffType>("Maloed");
        public TargetBuffType Tashed => GetMember<TargetBuffType>("Tashed");
        public TargetBuffType Snared => GetMember<TargetBuffType>("Snared");
        public TargetBuffType Hasted => GetMember<TargetBuffType>("Hasted");
        public TargetBuffType Beneficial => GetMember<TargetBuffType>("Beneficial");
        public TargetBuffType DSed => GetMember<TargetBuffType>("DSed");
        public TargetBuffType RevDSed => GetMember<TargetBuffType>("RevDSed");
        public TargetBuffType Charmed => GetMember<TargetBuffType>("Charmed");
        public TargetBuffType Aego => GetMember<TargetBuffType>("Aego");
        public TargetBuffType Skin => GetMember<TargetBuffType>("Skin");
        public TargetBuffType Focus => GetMember<TargetBuffType>("Focus");
        public TargetBuffType Regen => GetMember<TargetBuffType>("Regen");
        public TargetBuffType Diseased => GetMember<TargetBuffType>("Diseased");
        public TargetBuffType Poisoned => GetMember<TargetBuffType>("Poisoned");
        public TargetBuffType Cursed => GetMember<TargetBuffType>("Cursed");
        public TargetBuffType Corrupted => GetMember<TargetBuffType>("Corrupted");
        public TargetBuffType Symbol => GetMember<TargetBuffType>("Symbol");
        public TargetBuffType Clarity => GetMember<TargetBuffType>("Clarity");
        public TargetBuffType Pred => GetMember<TargetBuffType>("Pred");
        public TargetBuffType Strength => GetMember<TargetBuffType>("Strength");
        public TargetBuffType Brells => GetMember<TargetBuffType>("Brells");
        public TargetBuffType SV => GetMember<TargetBuffType>("SV");
        public TargetBuffType SE => GetMember<TargetBuffType>("SE");
        public TargetBuffType HybridHP => GetMember<TargetBuffType>("HybridHP");
        public TargetBuffType Growth => GetMember<TargetBuffType>("Growth");
        public TargetBuffType Shining => GetMember<TargetBuffType>("Shining");
    }
}