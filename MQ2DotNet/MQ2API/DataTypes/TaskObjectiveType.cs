namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TaskObjectiveType : MQ2DataType
    {
        public IntType xIndex => GetMember<IntType>("xIndex");
        public StringType Instruction => GetMember<StringType>("Instruction");
        public StringType Status => GetMember<StringType>("Status");
        public StringType Zone => GetMember<StringType>("Zone");
    }
}