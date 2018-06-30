// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MacroType : MQ2DataType
    {
        public MacroType()
        {
            IsTLO = new IndexedMember<BoolType>(this, "IsTLO");
            IsOuterVariable = new IndexedMember<BoolType>(this, "IsOuterVariable");
        }

        /// <summary>
        /// Name of the currently running macro including extension e.g. kissassist.mac
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");


        public Int64Type RunTime => GetMember<Int64Type>("RunTime");

        /// <summary>
        /// Macro currently paused?
        /// </summary>
        public BoolType Paused => GetMember<BoolType>("Paused");

        /// <summary>
        /// Value returned by the last subroutine call
        /// </summary>
        public StringType Return => GetMember<StringType>("Return");

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
        public IntType StackSize => GetMember<IntType>("StackSize");

        /// <summary>
        /// Number of parameters supplied to the currently executing macro
        /// </summary>
        public IntType Params => GetMember<IntType>("Params");

        /// <summary>
        /// Line the currently executing macro is on
        /// </summary>
        public IntType CurLine => GetMember<IntType>("CurLine");

        /// <summary>
        /// Current command to be run by the executed macro
        /// </summary>
        public StringType CurCommand => GetMember<StringType>("CurCommand");

        /// <summary>
        /// Memory usage in bytes of the currently executing macro
        /// </summary>
        public IntType MemUse => GetMember<IntType>("MemUse");
    }
}