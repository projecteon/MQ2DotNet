using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;

/* To create the member properties, grab everything in the switch statement from the cpp MQ2xxxType::GetMember function
 * Then in notepad++, find all:
 *      (case (\w+):|Dest\.Type)
 * Select all and copy, then find/replace:
 *      case (\w+):\s+Dest.Type = p(\w+);
 *      public \2 \1 => GetMember<\2>\("\1"\);
 * Note this doesn't handle index members
 */
namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Base class from which all wrapped MQ2 data types derive
    /// </summary>
    public class MQ2DataType
    {
        private MQ2TypeVar _typeVar;

        internal MQ2DataType()
        {
        }

        internal MQ2DataType(string typeName, MQ2TypeVar.MQ2VarPtr varPtr)
        {
            _typeVar.pType = FindMQ2DataType(typeName);
            _typeVar.VarPtr = varPtr;
        }

        #region Helpers for derived classes
        protected T GetMember<T>(string name, string index = "") where T : MQ2DataType
        {
            return _typeVar.GetMember<T>(name, index);
        }

        public class IndexedMember<T, TIndex> where T : MQ2DataType
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public T this[TIndex index] => _owner.GetMember<T>(_name, index.ToString());
        }

        public class IndexedMember<T1, TIndex1, T2, TIndex2> where T1 : MQ2DataType where T2 : MQ2DataType
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public T1 this[TIndex1 index] => _owner.GetMember<T1>(_name, index.ToString());
            public T2 this[TIndex2 index] => _owner.GetMember<T2>(_name, index.ToString());
        }

        public class IndexedMember<T> : IndexedMember<T, string> where T : MQ2DataType
        {
            public IndexedMember(MQ2DataType owner, string name) : base(owner, name)
            {
            }
        }
        #endregion

        public override string ToString()
        {
            return _typeVar.ToString();
        }

        // Exposed for use in basic types e.g. int, double, etc
        internal MQ2TypeVar.MQ2VarPtr VarPtr => _typeVar.VarPtr;


        #region Static
        private static readonly Dictionary<IntPtr, Func<MQ2DataType>> _constructors = new Dictionary<IntPtr, Func<MQ2DataType>>();

        /// <summary>
        /// Create the appropriate wrapper type given an MQ2TypeVar
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        internal static MQ2DataType Create(MQ2TypeVar typeVar)
        {
            var dataType = _constructors.ContainsKey(typeVar.pType)
                ? _constructors[typeVar.pType]()
                : new MQ2DataType();

            dataType._typeVar = typeVar;

            return dataType;
        }

        [DllImport("MQ2Main.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FindMQ2DataType(string Name);

        internal static void Register(string typeName, Func<MQ2DataType> constructor)
        {
            var dataType = FindMQ2DataType(typeName);

            if (dataType != IntPtr.Zero)
                _constructors[dataType] = constructor;
        }
        #endregion

        internal static void RegisterBuiltInTypes()
        {
            Register("bool", () => new BoolType());
            Register("int", () => new IntType());
            Register("int64", () => new Int64Type());
            Register("argb", () => new ArgbType());
            Register("byte", () => new ByteType());
            Register("string", () => new StringType());
            Register("float", () => new FloatType());
            Register("double", () => new DoubleType());
            Register("ticks", () => new TicksType());
            Register("timestamp", () => new TimeStampType());
            Register("spawn", () => new SpawnType());
            Register("character", () => new CharacterType());
            Register("spell", () => new SpellType());
            Register("buff", () => new BuffType());
            Register("targetbuff", () => new TargetBuffType());
            Register("itemspell", () => new ItemSpellType());
            Register("item", () => new ItemType());
            Register("switch", () => new SwitchType());
            Register("ground", () => new GroundType());
            Register("corpse", () => new CorpseType());
            Register("merchant", () => new MerchantType());
            Register("pointmerchantitem", () => new PointMerchantItemType());
            Register("pointmerchant", () => new PointMerchantType());
            Register("mercenary", () => new MercenaryType());
            Register("pet", () => new PetType());
            Register("window", () => new WindowType());
            Register("macro", () => new MacroType());
            Register("zone", () => new ZoneType());
            Register("currentzone", () => new CurrentZoneType());
            Register("charselectlist", () => new CharSelectListType());
            Register("everquest", () => new EverQuestType());
            Register("macroquest", () => new MacroQuestType());
            Register("math", () => new MathType());
            Register("race", () => new RaceType());
            Register("class", () => new ClassType());
            Register("body", () => new BodyType());
            Register("Deity", () => new DeityType());
            Register("time", () => new TimeType());
            Register("type", () => new TypeType());
            Register("heading", () => new HeadingType());
            Register("invslot", () => new InvSlotType());
            Register("plugin", () => new PluginType());
            Register("benchmark", () => new BenchmarkType());
            Register("skill", () => new SkillType());
            Register("altability", () => new AltAbilityType());
            Register("timer", () => new TimerType());
            Register("array", () => new ArrayType());
            Register("group", () => new GroupType());
            Register("groupmember", () => new GroupMemberType());
            Register("raid", () => new RaidType());
            Register("raidmember", () => new RaidMemberType());
            Register("Evolving", () => new EvolvingItemType());
            Register("dynamiczone", () => new DynamicZoneType());
            Register("dzmember", () => new DZMemberType());
            Register("fellowship", () => new FellowshipType());
            Register("fellowshipmember", () => new FellowshipMemberType());
            Register("friend", () => new FriendsType());
            Register("target", () => new TargetType());
            Register("taskobjectivemember", () => new TaskObjectiveType());
            Register("taskmember", () => new TaskMemberType());
            Register("task", () => new TaskType());
            Register("xtarget", () => new XTargetType());
            Register("keyring", () => new KeyRingType());
            Register("itemfilterdata", () => new ItemFilterDataType());
            Register("advlootitem", () => new AdvLootItemType());
            Register("advloot", () => new AdvLootType());
            Register("alert", () => new AlertType());
            Register("alertlist", () => new AlertListType());
            Register("worldlocation", () => new WorldLocationType());
            Register("augtype", () => new AugType());
            Register("auratype", () => new AuraType());
            Register("Cast", () => new CastType());
        }
    }
}