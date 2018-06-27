namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TaskMemberType : MQ2DataType
    {
        public StringType Name => GetMember<StringType>("Name");
        public BoolType Leader => GetMember<BoolType>("Leader");
        public IntType xIndex => GetMember<IntType>("xIndex");
    }
}