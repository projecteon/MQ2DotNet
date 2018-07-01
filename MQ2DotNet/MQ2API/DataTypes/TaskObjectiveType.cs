// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TaskObjectiveType : MQ2DataType
    {
        /// <summary>
        /// Index of this objective in the list (0 based)
        /// Confusingly, ${Task[taskname].Objective[1].Index} == 0
        /// </summary>
        public IntType Index => GetMember<IntType>("Index");

        /// <summary>
        /// Instruction text for this objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public StringType Instruction => GetMember<StringType>("Instruction");

        /// <summary>
        /// Status text for the objective, e.g. 0/1 or Done, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public StringType Status => GetMember<StringType>("Status");

        /// <summary>
        /// Zone for the objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public StringType Zone => GetMember<StringType>("Zone");
    }
}