namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for MacroType
    public class MacroType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public Int64Type RunTime => GetMember<Int64Type>("RunTime");
        public BoolType Paused => GetMember<BoolType>("Paused");
        public StringType Return => GetMember<StringType>("Return");
        public BoolType IsTLO => GetMember<BoolType>("IsTLO");
        public BoolType IsOuterVariable => GetMember<BoolType>("IsOuterVariable");
        public IntType StackSize => GetMember<IntType>("StackSize");
        public IntType Params => GetMember<IntType>("Params");
        public IntType CurLine => GetMember<IntType>("CurLine");
        public StringType CurCommand => GetMember<StringType>("CurCommand");
        public IntType MemUse => GetMember<IntType>("MemUse");
    }
}