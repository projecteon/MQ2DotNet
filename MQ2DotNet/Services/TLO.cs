using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.Services
{
    /// <summary>
    /// Provides access to all top level objects
    /// </summary>
    [PublicAPI]
    public class TLO
    {
        private readonly MQ2TypeFactory _typeFactory;

        /// <summary>
        /// Creates a new instance of TLO that uses the supplied MQ2TypeFactory to create MQ2DataType
        /// </summary>
        /// <param name="typeFactory"></param>
        public TLO(MQ2TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
            LastSpawn = new IndexedTLO<SpawnType, int>(this, "LastSpawn");
            Spawn = new IndexedTLO<SpawnType>(this, "Spawn");
            Spell = new IndexedTLO<SpellType, string, SpellType, int>(this, "Spell");
            GroundItem = new IndexedTLO<GroundType>(this, "GroundItem");
            GroundItemCount = new IndexedTLO<IntType>(this, "GroundItemCount");
            Window = new IndexedTLO<WindowType>(this, "Window");
            Zone = new IndexedTLO<ZoneType>(this, "Zone");
            NearestSpawn = new IndexedTLO<SpawnType>(this, "NearestSpawn");
            SpawnCount = new IndexedTLO<IntType>(this, "SpawnCount");
            Defined = new IndexedTLO<BoolType>(this, "Defined");
            FindItem = new IndexedTLO<ItemType>(this, "FindItem");
            FindItemBank = new IndexedTLO<ItemType>(this, "FindItemBank");
            FindItemCount = new IndexedTLO<IntType>(this, "FindItemCount");
            FindItemBankCount = new IndexedTLO<IntType>(this, "FindItemBankCount");
            InvSlot = new IndexedTLO<InvSlotType, string, InvSlotType, int>(this, "InvSlot");
            Plugin = new IndexedTLO<PluginType, string, PluginType, int>(this, "Plugin");
            Skill = new IndexedTLO<SkillType, string, SkillType, int>(this, "Skill");
            AltAbility = new IndexedTLO<AltAbilityType>(this, "AltAbility");
            LineOfSight = new IndexedTLO<BoolType>(this, "LineOfSight");
            Task = new IndexedTLO<TaskType, string, TaskType, int>(this, "Task");
            Mount = new IndexedTLO<KeyRingType, string, KeyRingType, int>(this, "Mount");
            Illusion = new IndexedTLO<KeyRingType, string, KeyRingType, int>(this, "Illusion");
            Familiar = new IndexedTLO<KeyRingType, string, KeyRingType, int>(this, "Familiar");
            Alias = new IndexedTLO<BoolType>(this, "Alias");
            AlertByNumber = new IndexedTLO<AlertType>(this, "Alert");
            SubDefined = new IndexedTLO<BoolType>(this, "SubDefined");
        }

        /// <summary>
        /// Your character
        /// </summary>
        public CharacterType Me => GetTLO<CharacterType>("Me");

        /// <summary>
        /// Your target
        /// </summary>
        public TargetType Target => GetTLO<TargetType>("Target");

        /// <summary>
        /// Your current door target
        /// </summary>
        public SwitchType Switch => GetTLO<SwitchType>("Switch");

        /// <summary>
        /// Your mercenary
        /// </summary>
        public MercenaryType Mercenary => GetTLO<MercenaryType>("Mercenary");

        /// <summary>
        /// Your pet
        /// </summary>
        public PetType Pet => GetTLO<PetType>("Pet");

        /// <summary>
        /// Merchant that is currently open
        /// </summary>
        public MerchantType Merchant => GetTLO<MerchantType>("Merchant");

        /// <summary>
        /// Corpse that is currently open
        /// </summary>
        public CorpseType Corpse => GetTLO<CorpseType>("Corpse");

        /// <summary>
        /// Macro that is running
        /// </summary>
        public MacroType Macro => GetTLO<MacroType>("Macro");

        /// <summary>
        /// <see cref="MacroQuestType"/> instance
        /// </summary>
        public MacroQuestType MacroQuest => GetTLO<MacroQuestType>("MacroQuest");

        /// <summary>
        /// <see cref="EverQuestType"/> instance
        /// </summary>
        public EverQuestType EverQuest => GetTLO<EverQuestType>("EverQuest");

        /// <summary>
        /// <see cref="GroupType"/> instance
        /// </summary>
        public GroupType Group => GetTLO<GroupType>("Group");

        /// <summary>
        /// Item on your cursor
        /// </summary>
        public ItemType Cursor => GetTLO<ItemType>("Cursor");

        /// <summary>
        /// Current in game time
        /// </summary>
        public TimeType GameTime => GetTLO<TimeType>("GameTime");

        /// <summary>
        /// TODO: What does SelectedItem give?
        /// </summary>
        public ItemType SelectedItem => GetTLO<ItemType>("SelectedItem");

        /// <summary>
        /// <see cref="RaidType"/> instance
        /// </summary>
        public RaidType Raid => GetTLO<RaidType>("Raid");

        /// <summary>
        /// Spawn whose name is currently being drawn
        /// </summary>
        public SpawnType NamingSpawn => GetTLO<SpawnType>("NamingSpawn");

        /// <summary>
        /// Your current door target
        /// </summary>
        public SpawnType DoorTarget => GetTLO<SpawnType>("DoorTarget");

        /// <summary>
        /// Your current item target
        /// </summary>
        public SpawnType ItemTarget => GetTLO<SpawnType>("ItemTarget");

        /// <summary>
        /// <see cref="DynamicZoneType"/> instance
        /// </summary>
        public DynamicZoneType DynamicZone => GetTLO<DynamicZoneType>("DynamicZone");

        /// <summary>
        /// <see cref="FriendsType"/> instance
        /// </summary>
        public FriendsType Friends => GetTLO<FriendsType>("Friends");

        /// <summary>
        /// <see cref="AdvLootType"/> instance
        /// </summary>
        public AdvLootType AdvLoot => GetTLO<AdvLootType>("AdvLoot");

        /// <summary>
        /// Point merchnat that is currently open
        /// </summary>
        public PointMerchantType PointMerchant => GetTLO<PointMerchantType>("PointMerchant");

        /// <summary>
        /// Zone you are currently in
        /// </summary>
        public CurrentZoneType CurrentZone => GetTLO<CurrentZoneType>("Zone");
    
        /// <summary>
        /// Heading to a location in y,x format
        /// </summary>
        public HeadingType Heading => GetTLO<HeadingType>("Heading");

        /// <summary>
        /// First spawn that matches a search string
        /// </summary>
        public IndexedTLO<SpawnType> Spawn { get; }

        /// <summary>
        /// Spell by name or ID
        /// </summary>
        public IndexedTLO<SpellType, string, SpellType, int> Spell { get; }

        /// <summary>
        /// Ground item by name (partial match), or your current ground target if an empty index is supplied
        /// </summary>
        public IndexedTLO<GroundType> GroundItem { get; }

        /// <summary>
        /// Number of ground items by name (partial match), or total number of ground items if an empty index is supplied
        /// </summary>
        public IndexedTLO<IntType> GroundItemCount { get; }

        /// <summary>
        /// Window by name
        /// </summary>
        public IndexedTLO<WindowType> Window { get; }

        /// <summary>
        /// Zone by ID or short name. For current zone, use <see cref="CurrentZone"/>
        /// </summary>
        public IndexedTLO<ZoneType> Zone { get; }

        /// <summary>
        /// Spawn by position in the list, from the end for negative numbers
        /// </summary>
        public IndexedTLO<SpawnType, int> LastSpawn { get; }

        /// <summary>
        /// Nth nearest spawn that matches a search e.g. "2,npc" for the 2nd closest NPC
        /// </summary>
        public IndexedTLO<SpawnType> NearestSpawn { get; }

        /// <summary>
        /// Total number of spawns that match a search
        /// </summary>
        public IndexedTLO<IntType> SpawnCount { get; }

        /// <summary>
        /// Is a variable by the given name defined?
        /// </summary>
        public IndexedTLO<BoolType> Defined { get; }

        /// <summary>
        /// Item by name, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public IndexedTLO<ItemType> FindItem { get; }

        /// <summary>
        /// An item in your bank, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public IndexedTLO<ItemType> FindItemBank { get; }

        /// <summary>
        /// Total number of an item you have, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public IndexedTLO<IntType> FindItemCount { get; }

        /// <summary>
        /// Total number of an item you have in your bank, partial match unless it begins with an = e.g. "=Water Flask"
        /// </summary>
        public IndexedTLO<IntType> FindItemBankCount { get; }

        /// <summary>
        /// An inventory slot by name or number
        /// </summary>
        /// <remarks>Valid slot numbers are:
        /// 2000-2015 bank window
        /// 2500-2503 shared bank
        /// 5000-5031 loot window
        /// 3000-3015 trade window (including npc) 3000-3007 are your slots, 3008-3015 are other character's slots
        /// 4000-4010 world container window
        /// 6000-6080 merchant window
        /// 7000-7080 bazaar window
        /// 8000-8031 inspect window</remarks>
        public IndexedTLO<InvSlotType, string, InvSlotType, int> InvSlot { get; }

        /// <summary>
        /// Plugin by name or number
        /// </summary>
        public IndexedTLO<PluginType, string, PluginType, int> Plugin { get; }

        /// <summary>
        /// Skill by name or number
        /// </summary>
        public IndexedTLO<SkillType, string, SkillType, int> Skill { get; }

        /// <summary>
        /// Alt ability by name or number
        /// </summary>
        public IndexedTLO<AltAbilityType> AltAbility { get; }

        /// <summary>
        /// Is there line of sight between two locations, in the format "y,x,z:y,x,z"
        /// </summary>
        public IndexedTLO<BoolType> LineOfSight { get; }

        /// <summary>
        /// Task by name or position in window (1 based)
        /// </summary>
        public IndexedTLO<TaskType, string, TaskType, int> Task { get; }

        /// <summary>
        /// Mount (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public IndexedTLO<KeyRingType, string, KeyRingType, int> Mount { get; }

        /// <summary>
        /// Illusion (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public IndexedTLO<KeyRingType, string, KeyRingType, int> Illusion { get; }

        /// <summary>
        /// Familiar (on keyring) by name or position in window (1 based). Name is partial match unless it begins with =
        /// </summary>
        public IndexedTLO<KeyRingType, string, KeyRingType, int> Familiar { get; }

        /// <summary>
        /// Is an alias set for a command, including the slash e.g. Alias["/chaseon"]
        /// </summary>
        public IndexedTLO<BoolType> Alias { get; }

        /// <summary>
        /// An alert list by number
        /// For the equivalent of ${Alert}, see <see cref="Alerts"/>
        /// </summary>
        public IndexedTLO<AlertType> AlertByNumber { get; }

        /// <summary>
        /// Pipe separated list of all alert lists in use, e.g. "1|2"
        /// Equivalent of ${Alert}
        /// </summary>
        public StringType Alerts => GetTLO<StringType>("Alert");

        /// <summary>
        /// Currently open context menu
        /// </summary>
        public MenuType Menu => GetTLO<MenuType>("Menu");

        /// <summary>
        /// Is a sub with the given name defined?
        /// </summary>
        public IndexedTLO<BoolType> SubDefined { get; }

        // TODO: Plugin types
        //public CastType Cast => GetTLO<CastType>("Cast");

        /// <summary>
        /// Get a TLO by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetTLO<T>(string name, string index = "") where T : MQ2DataType
        {
            // To get an MQ2TypeVar from a TLO, first we call FindMQ2Data to get a function pointer to the TLO's function
            var tlo = FindMQ2Data(name);// ?? throw new KeyNotFoundException();

            // Then we call that function, providing the index as a parameter
            if (tlo.pFunction == IntPtr.Zero || !tlo.Function(index, out var typeVar))
                return null;

            return (T)_typeFactory.Create(typeVar);
        }

        #region Helper classes
        /// <summary>
        /// Helper class for a TLO that is accessed with an indexer
        /// </summary>
        /// <typeparam name="T">Data type to return</typeparam>
        /// <typeparam name="TIndex">Type for index parameter</typeparam>
        public class IndexedTLO<T, TIndex> where T : MQ2DataType
        {
            private readonly TLO _tlo;
            private readonly string _name;

            internal IndexedTLO(TLO tlo, string name)
            {
                _tlo = tlo;
                _name = name;
            }

            /// <summary>
            /// Get the TLO using an index
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public T this[TIndex index] => _tlo.GetTLO<T>(_name, index.ToString());
        }

        /// <inheritdoc />
        public class IndexedTLO<T> : IndexedTLO<T, string> where T : MQ2DataType
        {
            internal IndexedTLO(TLO tlo, string name) : base(tlo, name)
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
            private readonly TLO _tlo;
            private readonly string _name;

            internal IndexedTLO(TLO tlo, string name)
            {
                _tlo = tlo;
                _name = name;
            }

            /// <summary>
            /// Get the TLO using an index of type <typeparamref name="TIndex1"/>
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public T1 this[TIndex1 index] => _tlo.GetTLO<T1>(_name, index.ToString());

            /// <summary>
            /// Get the TLO using an index of type <typeparamref name="TIndex2"/>
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public T2 this[TIndex2 index] => _tlo.GetTLO<T2>(_name, index.ToString());
        }
        #endregion

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
    }
}