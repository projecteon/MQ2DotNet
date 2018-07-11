using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.MQ2API
{
    public static class MQ2TypeFactory
    {
        private static readonly Dictionary<IntPtr, Func<MQ2TypeVar, MQ2DataType>> _constructors = new Dictionary<IntPtr, Func<MQ2TypeVar, MQ2DataType>>();

        /// <summary>
        /// Create the appropriate wrapper type given an MQ2TypeVar
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        internal static MQ2DataType Create(MQ2TypeVar typeVar)
        {
            // If we have a special constructor registered, use it, otherwise create an MQ2DataType by default
            var dataType = _constructors.ContainsKey(typeVar.pType)
                ? _constructors[typeVar.pType](typeVar)
                : new MQ2DataType(typeVar);

            return dataType;
        }

        [DllImport("MQ2Main.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FindMQ2DataType(string Name);

        public static void Register(string typeName, Func<MQ2TypeVar, MQ2DataType> constructor)
        {
            var dataType = FindMQ2DataType(typeName);

            if (dataType != IntPtr.Zero)
                _constructors[dataType] = constructor;
            else
                throw new KeyNotFoundException($"Could not find data type: {typeName}");
        }

        internal static void RegisterBuiltInTypes()
        {
            Register("bool", typeVar => new BoolType(typeVar));
            Register("int", typeVar => new IntType(typeVar));
            Register("int64", typeVar => new Int64Type(typeVar));
            Register("argb", typeVar => new ArgbType(typeVar));
            Register("byte", typeVar => new ByteType(typeVar));
            Register("string", typeVar => new StringType(typeVar));
            Register("float", typeVar => new FloatType(typeVar));
            Register("double", typeVar => new DoubleType(typeVar));
            Register("ticks", typeVar => new TicksType(typeVar));
            Register("timestamp", typeVar => new TimeStampType(typeVar));
            Register("spawn", typeVar => new SpawnType(typeVar));
            Register("character", typeVar => new CharacterType(typeVar));
            Register("spell", typeVar => new SpellType(typeVar));
            Register("buff", typeVar => new BuffType(typeVar));
            Register("targetbuff", typeVar => new TargetBuffType(typeVar));
            Register("itemspell", typeVar => new ItemSpellType(typeVar));
            Register("item", typeVar => new ItemType(typeVar));
            Register("switch", typeVar => new SwitchType(typeVar));
            Register("ground", typeVar => new GroundType(typeVar));
            Register("corpse", typeVar => new CorpseType(typeVar));
            Register("merchant", typeVar => new MerchantType(typeVar));
            Register("pointmerchantitem", typeVar => new PointMerchantItemType(typeVar));
            Register("pointmerchant", typeVar => new PointMerchantType(typeVar));
            Register("mercenary", typeVar => new MercenaryType(typeVar));
            Register("pet", typeVar => new PetType(typeVar));
            Register("window", typeVar => new WindowType(typeVar));
            Register("macro", typeVar => new MacroType(typeVar));
            Register("zone", typeVar => new ZoneType(typeVar));
            Register("currentzone", typeVar => new CurrentZoneType(typeVar));
            Register("charselectlist", typeVar => new CharSelectListType(typeVar));
            Register("everquest", typeVar => new EverQuestType(typeVar));
            Register("macroquest", typeVar => new MacroQuestType(typeVar));
#pragma warning disable 618
            Register("math", typeVar => new MathType(typeVar));
#pragma warning restore 618
            Register("race", typeVar => new RaceType(typeVar));
            Register("class", typeVar => new ClassType(typeVar));
            Register("body", typeVar => new BodyType(typeVar));
            Register("Deity", typeVar => new DeityType(typeVar));
            Register("time", typeVar => new TimeType(typeVar));
            Register("type", typeVar => new TypeType(typeVar));
            Register("heading", typeVar => new HeadingType(typeVar));
            Register("invslot", typeVar => new InvSlotType(typeVar));
            Register("plugin", typeVar => new PluginType(typeVar));
            //Register("benchmark", typeVar => new BenchmarkType(typeVar));
            Register("skill", typeVar => new SkillType(typeVar));
            Register("altability", typeVar => new AltAbilityType(typeVar));
            Register("timer", typeVar => new TimerType(typeVar));
            Register("array", typeVar => new ArrayType(typeVar));
            Register("group", typeVar => new GroupType(typeVar));
            Register("groupmember", typeVar => new GroupMemberType(typeVar));
            Register("raid", typeVar => new RaidType(typeVar));
            Register("raidmember", typeVar => new RaidMemberType(typeVar));
            Register("Evolving", typeVar => new EvolvingItemType(typeVar));
            Register("dynamiczone", typeVar => new DynamicZoneType(typeVar));
            Register("dzmember", typeVar => new DZMemberType(typeVar));
            Register("fellowship", typeVar => new FellowshipType(typeVar));
            Register("fellowshipmember", typeVar => new FellowshipMemberType(typeVar));
            Register("friend", typeVar => new FriendsType(typeVar));
            Register("target", typeVar => new TargetType(typeVar));
            Register("taskobjectivemember", typeVar => new TaskObjectiveType(typeVar));
            Register("taskmember", typeVar => new TaskMemberType(typeVar));
            Register("task", typeVar => new TaskType(typeVar));
            Register("xtarget", typeVar => new XTargetType(typeVar));
            Register("keyring", typeVar => new KeyRingType(typeVar));
            Register("itemfilterdata", typeVar => new ItemFilterDataType(typeVar));
            Register("advlootitem", typeVar => new AdvLootItemType(typeVar));
            Register("advloot", typeVar => new AdvLootType(typeVar));
            Register("alert", typeVar => new AlertType(typeVar));
            Register("alertlist", typeVar => new AlertListType(typeVar));
            Register("worldlocation", typeVar => new WorldLocationType(typeVar));
            Register("augtype", typeVar => new AugType(typeVar));
            Register("auratype", typeVar => new AuraType(typeVar));
            Register("solventtype", typeVar => new SolventType(typeVar));
            Register("Cast", typeVar => new CastType(typeVar));
        }
    }
}