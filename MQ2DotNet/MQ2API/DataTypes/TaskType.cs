using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a task
    /// </summary>
    [PublicAPI]
    [MQ2Type("task")]
    public class TaskType : MQ2DataType
    {
        internal TaskType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Member = new IndexedMember<TaskMemberType, string, TaskMemberType, int>(this, "Member");
            Objective = new IndexedMember<TaskObjectiveType, string, TaskObjectiveType, int>(this, "Objective");
        }

        /// <summary>
        /// Memory address of the TASKMEMBER struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Type of task, either Shared or Quest
        /// </summary>
        public string Type => GetMember<StringType>("Type");

        /// <summary>
        /// Index of the task in your task list, 1 based
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Name of the leader of the task
        /// </summary>
        public string Leader => GetMember<StringType>("Leader");

        /// <summary>
        /// Name/title of the task
        /// </summary>
        public string Title => GetMember<StringType>("Title");

        /// <summary>
        /// Time remaining on the task
        /// </summary>
        public TimeStampType Timer => GetMember<TimeStampType>("Timer");

        /// <summary>
        /// Member of the task, by name or index (1 based)
        /// </summary>
        public IndexedMember<TaskMemberType, string, TaskMemberType, int> Member { get; }

        /// <summary>
        /// Number of members
        /// </summary>
        public int? Members => GetMember<IntType>("Members");

        /// <summary>
        /// Task objective by name or index (1 based)
        /// </summary>
        public IndexedMember<TaskObjectiveType, string, TaskObjectiveType, int> Objective { get; }

        /// <summary>
        /// First task objective with a status other than "Done"
        /// </summary>
        public TaskObjectiveType Step => GetMember<TaskObjectiveType>("Step");

        /// <summary>
        /// Select the task in the task window
        /// </summary>
        public void Select() => GetMember<MQ2DataType>("Select");
    }
}