using System;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.MQ2API
{
    public static class TLO
    {
        #region Unmanaged imports
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool fMQData([MarshalAs(UnmanagedType.LPStr)] string szIndex, out MQ2TypeVar ret);

        [StructLayout(LayoutKind.Explicit, Size = 68, CharSet = CharSet.Ansi)]
        internal struct MQ2DataItem
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            [FieldOffset(0)]
            public string Name;
            [FieldOffset(64)] public fMQData Function;
        }

        // Marshal doesn't want to return this struct (since it's non-blittable thanks to the delegate & string) so gotta do it manually
        internal static MQ2DataItem FindMQ2Data(string szName)
        {
            return Marshal.PtrToStructure<MQ2DataItem>(FindMQ2DataIntPtr(szName));
        }

        [DllImport("MQ2Main.dll", EntryPoint = "FindMQ2Data", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FindMQ2DataIntPtr(string szName);
        #endregion

        private static T GetTLO<T>(string name, string index = "") where T : MQ2DataType
        {
            // To get an MQ2TypeVar from a TLO, first we call FindMQ2Data to get a function pointer to the TLO's function
            var tlo = FindMQ2Data(name);// ?? throw new KeyNotFoundException();

            // Then we call that function, providing the index as a parameter
            if (!tlo.Function(index, out var typeVar))
                return null;

            return (T)MQ2DataType.Create(typeVar);
        }

        public class IndexedTLO<T> where T : MQ2DataType
        {
            private readonly string _name;

            public IndexedTLO(string name)
            {
                _name = name;
            }

            public T this[string index] => GetTLO<T>(_name, index);
        }

        // TLOs with no need for indexing
        public static CharacterType Me => GetTLO<CharacterType>("Me");
        public static TargetType Target => GetTLO<TargetType>("Target");
        public static SwitchType Switch => GetTLO<SwitchType>("Switch");
        public static MercenaryType Mercenary => GetTLO<MercenaryType>("Mercenary");
        public static PetType Pet => GetTLO<PetType>("Pet");
        public static MerchantType Merchant => GetTLO<MerchantType>("Merchant");
        public static CorpseType Corpse => GetTLO<CorpseType>("Corpse");
        public static MacroType Macro => GetTLO<MacroType>("Macro");
        public static MacroQuestType MacroQuest => GetTLO<MacroQuestType>("MacroQuest");
        public static EverQuestType EverQuest => GetTLO<EverQuestType>("EverQuest");
        public static HeadingType Heading => GetTLO<HeadingType>("Heading");
        public static GroupType Group => GetTLO<GroupType>("Group");
        public static ItemType Cursor => GetTLO<ItemType>("Cursor");
        public static TimeType GameTime => GetTLO<TimeType>("GameTime");
        public static ItemType SelectedItem => GetTLO<ItemType>("SelectedItem");
        public static RaidType Raid => GetTLO<RaidType>("Raid");
        public static SpawnType NamingSpawn => GetTLO<SpawnType>("NamingSpawn");
        public static SpawnType DoorTarget => GetTLO<SpawnType>("DoorTarget");
        public static SpawnType ItemTarget => GetTLO<SpawnType>("ItemTarget");
        public static DynamicZoneType DynamicZone => GetTLO<DynamicZoneType>("DynamicZone");
        public static FriendsType Friends => GetTLO<FriendsType>("Friends");
        public static AdvLootType AdvLoot => GetTLO<AdvLootType>("AdvLoot");
        public static PointMerchantType PointMerchant => GetTLO<PointMerchantType>("PointMerchant");
        public static CurrentZoneType CurrentZone => GetTLO<CurrentZoneType>("Zone");

        // TLOs that take an index
        public static IndexedTLO<SpawnType> Spawn { get; } = new IndexedTLO<SpawnType>("Spawn");
        public static IndexedTLO<SpellType> Spell { get; } = new IndexedTLO<SpellType>("Spell");
        public static IndexedTLO<GroundType> GroundItem { get; } = new IndexedTLO<GroundType>("GroundItem");
        public static IndexedTLO<IntType> GroundItemCount { get; } = new IndexedTLO<IntType>("GroundItemCount");
        public static IndexedTLO<WindowType> Window { get; } = new IndexedTLO<WindowType>("Window");
        public static IndexedTLO<ZoneType> Zone { get; } = new IndexedTLO<ZoneType>("Zone");
        public static IndexedTLO<SpawnType> LastSpawn { get; } = new IndexedTLO<SpawnType>("LastSpawn");
        public static IndexedTLO<SpawnType> NearestSpawn { get; } = new IndexedTLO<SpawnType>("NearestSpawn");
        public static IndexedTLO<IntType> SpawnCount { get; } = new IndexedTLO<IntType>("SpawnCount");
        public static IndexedTLO<BoolType> Defined { get; } = new IndexedTLO<BoolType>("Defined");
        public static IndexedTLO<ItemType> FindItem { get; } = new IndexedTLO<ItemType>("FindItem");
        public static IndexedTLO<ItemType> FindItemBank { get; } = new IndexedTLO<ItemType>("FindItemBank");
        public static IndexedTLO<IntType> FindItemCount { get; } = new IndexedTLO<IntType>("FindItemCount");
        public static IndexedTLO<IntType> FindItemBankCount { get; } = new IndexedTLO<IntType>("FindItemBankCount");
        public static IndexedTLO<InvSlotType> InvSlot { get; } = new IndexedTLO<InvSlotType>("InvSlot");
        public static IndexedTLO<PluginType> Plugin { get; } = new IndexedTLO<PluginType>("Plugin");
        public static IndexedTLO<SkillType> Skill { get; } = new IndexedTLO<SkillType>("Skill");
        public static IndexedTLO<AltAbilityType> AltAbility { get; } = new IndexedTLO<AltAbilityType>("AltAbility");
        public static IndexedTLO<BoolType> LineOfSight { get; } = new IndexedTLO<BoolType>("LineOfSight");
        public static IndexedTLO<TaskType> Task { get; } = new IndexedTLO<TaskType>("Task");
        public static IndexedTLO<KeyRingType> Mount { get; } = new IndexedTLO<KeyRingType>("Mount");
        public static IndexedTLO<KeyRingType> Illusion { get; } = new IndexedTLO<KeyRingType>("Illusion");
        public static IndexedTLO<KeyRingType> Familiar { get; } = new IndexedTLO<KeyRingType>("Familiar");
        public static IndexedTLO<BoolType> Alias { get; } = new IndexedTLO<BoolType>("Alias");

        // This one returns pAlertType given a number, or pStringType given nothing :(
        public static IndexedTLO<AlertType> AlertByNumber { get; } = new IndexedTLO<AlertType>("Alert");

        // Plugin types
        public static CastType Cast => GetTLO<CastType>("Cast");
    }
}