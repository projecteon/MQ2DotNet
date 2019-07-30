using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a task objective
    /// </summary>
    [PublicAPI]
    [MQ2Type("taskobjectivemember")]
    public class TaskObjectiveType : MQ2DataType
    {
        internal TaskObjectiveType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Index of this objective in the list (0 based)
        /// Confusingly, ${Task[taskname].Objective[1].Index} == 0
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Instruction text for this objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public string Instruction => GetMember<StringType>("Instruction");

        /// <summary>
        /// Status text for the objective, e.g. 0/1 or Done, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public string Status => GetMember<StringType>("Status");

        /// <summary>
        /// Zone for the objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public string Zone => GetMember<StringType>("Zone");
    }
}