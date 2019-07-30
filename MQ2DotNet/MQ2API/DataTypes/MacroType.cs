using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for information about the currently running macro
    /// </summary>
    [PublicAPI]
    [MQ2Type("macro")]
    public class MacroType : MQ2DataType
    {
        internal MacroType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            IsTLO = new IndexedMember<BoolType>(this, "IsTLO");
            IsOuterVariable = new IndexedMember<BoolType>(this, "IsOuterVariable");
        }

        /// <summary>
        /// Name of the currently running macro including extension e.g. kissassist.mac
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Time in milliseconds that the macro has been running for
        /// </summary>
        public long? RunTime => GetMember<Int64Type>("RunTime");

        /// <summary>
        /// Macro currently paused?
        /// </summary>
        public bool Paused => GetMember<BoolType>("Paused");

        /// <summary>
        /// Value returned by the last subroutine call
        /// </summary>
        public string Return => GetMember<StringType>("Return");

        /// <summary>
        /// Is the given name a Top Level Object?
        /// </summary>
        public IndexedMember<BoolType> IsTLO { get; }

        /// <summary>
        /// Is the given name a variable declared with outer scope?
        /// </summary>
        public IndexedMember<BoolType> IsOuterVariable { get; }

        /// <summary>
        /// Stack depth of the currently executing macro
        /// </summary>
        public int? StackSize => GetMember<IntType>("StackSize");

        /// <summary>
        /// Number of parameters supplied to the currently executing macro
        /// </summary>
        public int? Params => GetMember<IntType>("Params");

        /// <summary>
        /// Line the currently executing macro is on
        /// </summary>
        public int? CurLine => GetMember<IntType>("CurLine");

        /// <summary>
        /// Current command to be run by the executed macro
        /// </summary>
        public string CurCommand => GetMember<StringType>("CurCommand");

        /// <summary>
        /// Memory usage in bytes of the currently executing macro
        /// </summary>
        public int? MemUse => GetMember<IntType>("MemUse");

        /// <summary>
        /// Prints undeclared variables to chat
        /// </summary>
        public void Undeclared() => GetMember<MQ2DataType>("Undeclared");

        /// <summary>
        /// Subroutine currently being executed, including arguments e.g. "MySub(string arg1)"
        /// </summary>
        public string CurSub => GetMember<StringType>("CurSub");
    }
}