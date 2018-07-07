using System;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API
{
    public static class TLO
    {
        #region Unmanaged imports
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool fMQData([MarshalAs(UnmanagedType.LPStr)] string szIndex, out MQ2TypeVar ret);

        [StructLayout(LayoutKind.Explicit, Size = 68)]
        internal struct MQ2DataItem
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            [FieldOffset(0)]
            public byte[] Name;

            [FieldOffset(64)]
            public IntPtr pFunction;

            public fMQData Function => Marshal.GetDelegateForFunctionPointer<fMQData>(pFunction);
        }

        // Marshal doesn't want to return this struct (since it's non-blittable thanks to the delegate & string) so gotta do it manually
        internal static MQ2DataItem FindMQ2Data(string szName)
        {
            return Marshal.PtrToStructure<MQ2DataItem>(FindMQ2DataIntPtr(szName));
        }

        [DllImport("MQ2Main.dll", EntryPoint = "FindMQ2Data", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FindMQ2DataIntPtr([MarshalAs(UnmanagedType.LPStr)] string szName);
        #endregion

        #region Helper classes
        private static T GetTLO<T>(string name, string index = "") where T : MQ2DataType
        {
            // To get an MQ2TypeVar from a TLO, first we call FindMQ2Data to get a function pointer to the TLO's function
            var tlo = FindMQ2Data(name);// ?? throw new KeyNotFoundException();

            // Then we call that function, providing the index as a parameter
            if (tlo.pFunction == IntPtr.Zero || !tlo.Function(index, out var typeVar))
                return null;

            return (T)MQ2TypeFactory.Create(typeVar);
        }

        /// <summary>
        /// Helper class for a TLO that is accessed with an indexer
        /// </summary>
        /// <typeparam name="T">Data type to return</typeparam>
        /// <typeparam name="TIndex">Type for index parameter</typeparam>
        public class IndexedTLO<T, TIndex> where T : MQ2DataType
        {
            private readonly string _name;

            internal IndexedTLO(string name)
            {
                _name = name;
            }
            
            public T this[TIndex index] => GetTLO<T>(_name, index.ToString());
        }

        /// <inheritdoc />
        public class IndexedTLO<T> : IndexedTLO<T, string> where T : MQ2DataType
        {
            internal IndexedTLO(string name) : base(name)
            {
            }
        }

        /// <summary>
        /// Helper class for a TLO that is accessed with an indexer
        /// </summary>
        /// <typeparam name="T1">Data type to return given first index type</typeparam>
        /// <typeparam name="TIndex1">First type for index parameter</typeparam>
        /// <typeparam name="T2">Data type to return given second index type</typeparam>
        /// <typeparam name="TIndex2">Second type for index parameter</typeparam>
        public class IndexedTLO<T1, TIndex1, T2, TIndex2> where T1 : MQ2DataType where T2 : MQ2DataType
        {
            private readonly string _name;

            internal IndexedTLO(string name)
            {
                _name = name;
            }
            
            public T1 this[TIndex1 index] => GetTLO<T1>(_name, index.ToString());
            public T2 this[TIndex2 index] => GetTLO<T2>(_name, index.ToString());
        }
#endregion

        /// <summary>
        /// Your character
        /// </summary>
        public static CharacterType Me => GetTLO<CharacterType>("Me");

        /// <summary>
        /// Your target
        /// </summary>
        public static TargetType Target => GetTLO<TargetType>("Target");

        /// <summary>
        /// Your current door target
        /// </summary>
        public static SwitchType Switch => GetTLO<SwitchType>("Switch");

        /// <summary>
        /// Your mercenary
        /// </summary>
        public static MercenaryType Mercenary => GetTLO<MercenaryType>("Mercenary");

        /// <summary>
        /// Your pet
        /// </summary>
        public static PetType Pet => GetTLO<PetType>("Pet");

        /// <summary>
        /// Merchant that is currently open
        /// </summary>
        public static MerchantType Merchant => GetTLO<MerchantType>("Merchant");

        /// <summary>
        /// Corpse that is currently open
        /// </summary>
        public static CorpseType Corpse => GetTLO<CorpseType>("Corpse");

        /// <summary>
        /// Macro that is running
        /// </summary>
        public static MacroType Macro => GetTLO<MacroType>("Macro");

        /// <summary>
        /// <see cref="MacroQuestType"/> instance
        /// </summary>
        public static MacroQuestType MacroQuest => GetTLO<MacroQuestType>("MacroQuest");

        /// <summary>
        /// <see cref="EverQuestType"/> instance
        /// </summary>
        public static EverQuestType EverQuest => GetTLO<EverQuestType>("EverQuest");

        /// <summary>
        /// <see cref="GroupType"/> instance
        /// </summary>
        public static GroupType Group => GetTLO<GroupType>("Group");

        /// <summary>
        /// Item on your cursor
        /// </summary>
        public static ItemType Cursor => GetTLO<ItemType>("Cursor");

        /// <summary>
        /// Current in game time
        /// </summary>
        public static TimeType GameTime => GetTLO<TimeType>("GameTime");

        /// <summary>
        /// TODO: What does SelectedItem give?
        /// </summary>
        public static ItemType SelectedItem => GetTLO<ItemType>("SelectedItem");

        /// <summary>
        /// <see cref="RaidType"/> instance
        /// </summary>
        public static RaidType Raid => GetTLO<RaidType>("Raid");

        /// <summary>
        /// Spawn whose name is currently being drawn
        /// </summary>
        public static SpawnType NamingSpawn => GetTLO<SpawnType>("NamingSpawn");

        /// <summary>
        /// Your current door target
        /// </summary>
        public static SpawnType DoorTarget => GetTLO<SpawnType>("DoorTarget");

        /// <summary>
        /// Your current item target
        /// </summary>
        public static SpawnType ItemTarget => GetTLO<SpawnType>("ItemTarget");

        /// <summary>
        /// <see cref="DynamicZoneType"/> instance
        /// </summary>
        public static DynamicZoneType DynamicZone => GetTLO<DynamicZoneType>("DynamicZone");

        /// <summary>
        /// <see cref="FriendsType"/> instance
        /// </summary>
        public static FriendsType Friends => GetTLO<FriendsType>("Friends");

        /// <summary>
        /// <see cref="AdvLootType"/> instance
        /// </summary>
        public static AdvLootType AdvLoot => GetTLO<AdvLootType>("AdvLoot");

        /// <summary>
        /// Point merchnat that is currently open
        /// </summary>
        public static PointMerchantType PointMerchant => GetTLO<PointMerchantType>("PointMerchant");

        /// <summary>
        /// Zone you are currently in
        /// </summary>
        public static CurrentZoneType CurrentZone => GetTLO<CurrentZoneType>("Zone");
    
        /// <summary>
        /// Heading to a location in y,x format
        /// </summary>
        public static HeadingType Heading => GetTLO<HeadingType>("Heading");

        /// <summary>
        /// First spawn that matches a search string
        /// </summary>
        public static IndexedTLO<SpawnType> Spawn { get; } = new IndexedTLO<SpawnType>("Spawn");

        /// <summary>
        /// Spell by name or ID
        /// </summary>
        public static IndexedTLO<SpellType, string, SpellType, int> Spell { get; } = new IndexedTLO<SpellType, string, SpellType, int>("Spell");

        /// <summary>
        /// Ground item by name (partial match), or your current ground target if an empty index is supplied
        /// </summary>
        public static IndexedTLO<GroundType> GroundItem { get; } = new IndexedTLO<GroundType>("GroundItem");

        /// <summary>
        /// Number of ground items by name (partial match), or total number of ground items if an empty index is supplied
        /// </summary>
        public static IndexedTLO<IntType> GroundItemCount { get; } = new IndexedTLO<IntType>("GroundItemCount");

        /// <summary>
        /// Window by name
        /// </summary>
        public static IndexedTLO<WindowType> Window { get; } = new IndexedTLO<WindowType>("Window");

        /// <summary>
        /// Zone by ID or short name. For current zone, use <see cref="CurrentZone"/>
        /// </summary>
        public static IndexedTLO<ZoneType> Zone { get; } = new IndexedTLO<ZoneType>("Zone");

        /// <summary>
        /// Spawn by position in the list, from the end for negative numbers
        /// </summary>
        public static IndexedTLO<SpawnType, int> LastSpawn { get; } = new IndexedTLO<SpawnType, int>("LastSpawn");

        /// <summary>
        /// Nth nearest spawn that matches a search e.g. "2,npc" for the 2nd closest NPC
        /// </summary>
        public static IndexedTLO<SpawnType> NearestSpawn { get; } = new IndexedTLO<SpawnType>("NearestSpawn");

        /// <summary>
        /// Total number of spawns that match a search
        /// </summary>
        public static IndexedTLO<IntType> SpawnCount { get; } = new IndexedTLO<IntType>("SpawnCount");

        /// <summary>
        /// Is a variable by the given name defined?
        /// </summary>
        public static IndexedTLO<BoolType> Defined { get; } = new IndexedTLO<BoolType>("Defined");

        /// <summary>
        /// Item by name, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public static IndexedTLO<ItemType> FindItem { get; } = new IndexedTLO<ItemType>("FindItem");

        /// <summary>
        /// An item in your bank, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public static IndexedTLO<ItemType> FindItemBank { get; } = new IndexedTLO<ItemType>("FindItemBank");

        /// <summary>
        /// Total number of an item you have, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public static IndexedTLO<IntType> FindItemCount { get; } = new IndexedTLO<IntType>("FindItemCount");

        /// <summary>
        /// Total number of an item you have in your bank, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public static IndexedTLO<IntType> FindItemBankCount { get; } = new IndexedTLO<IntType>("FindItemBankCount");

        /// <summary>
        /// An inventory slot by name or number
        /// </summary>
        public static IndexedTLO<InvSlotType, string, InvSlotType, int> InvSlot { get; } = new IndexedTLO<InvSlotType, string, InvSlotType, int>("InvSlot");

        /// <summary>
        /// Plugin by name or number
        /// </summary>
        public static IndexedTLO<PluginType, string, PluginType, int> Plugin { get; } = new IndexedTLO<PluginType, string, PluginType, int>("Plugin");

        /// <summary>
        /// Skill by name or number
        /// </summary>
        public static IndexedTLO<SkillType, string, SkillType, int> Skill { get; } = new IndexedTLO<SkillType, string, SkillType, int>("Skill");

        /// <summary>
        /// Alt ability by name or number
        /// </summary>
        public static IndexedTLO<AltAbilityType> AltAbility { get; } = new IndexedTLO<AltAbilityType>("AltAbility");

        /// <summary>
        /// Is there line of sight between two locations, in the format "y,x,z:y,x,z"
        /// </summary>
        public static IndexedTLO<BoolType> LineOfSight { get; } = new IndexedTLO<BoolType>("LineOfSight");

        /// <summary>
        /// Task by name or position in window (1 based)
        /// </summary>
        public static IndexedTLO<TaskType, string, TaskType, int> Task { get; } = new IndexedTLO<TaskType, string, TaskType, int>("Task");

        /// <summary>
        /// Mount (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public static IndexedTLO<KeyRingType, string, KeyRingType, int> Mount { get; } = new IndexedTLO<KeyRingType, string, KeyRingType, int>("Mount");

        /// <summary>
        /// Illusion (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public static IndexedTLO<KeyRingType, string, KeyRingType, int> Illusion { get; } = new IndexedTLO<KeyRingType, string, KeyRingType, int>("Illusion");

        /// <summary>
        /// Familiar (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public static IndexedTLO<KeyRingType, string, KeyRingType, int> Familiar { get; } = new IndexedTLO<KeyRingType, string, KeyRingType, int>("Familiar");

        /// <summary>
        /// Is an alias set for a command, including the slash e.g. Alias["/chaseon"]
        /// </summary>
        public static IndexedTLO<BoolType> Alias { get; } = new IndexedTLO<BoolType>("Alias");

        /// <summary>
        /// An alert list by number
        /// For the equivalent of ${Alert}, see <see cref="Alerts"/>
        /// </summary>
        public static IndexedTLO<AlertType> AlertByNumber { get; } = new IndexedTLO<AlertType>("Alert");

        /// <summary>
        /// Pipe separated list of all alert lists in use, e.g. "1|2"
        /// Equivalent of ${Alert}
        /// </summary>
        public static StringType Alerts => GetTLO<StringType>("Alert");

        // Plugin types
        public static CastType Cast => GetTLO<CastType>("Cast");
    }
}