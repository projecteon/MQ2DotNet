namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TaskType : MQ2DataType
    {
        public TaskType()
        {
            xMember = new IndexedMember<TaskMemberType>(this, "xMember");
            Objective = new IndexedMember<TaskObjectiveType>(this, "Objective");
        }

        public IntType Address => GetMember<IntType>("Address");
        public StringType Type => GetMember<StringType>("Type");
        public IntType xIndex => GetMember<IntType>("xIndex");
        public StringType Leader => GetMember<StringType>("Leader");
        public StringType Title => GetMember<StringType>("Title");
        public TimeStampType Timer => GetMember<TimeStampType>("Timer");
        public IndexedMember<TaskMemberType> xMember { get; }
        public IntType Members => GetMember<IntType>("Members");
        public IndexedMember<TaskObjectiveType> Objective { get; }
        public TaskObjectiveType Step => GetMember<TaskObjectiveType>("Step");
    }
}