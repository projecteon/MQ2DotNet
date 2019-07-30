using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a member of a shared task
    /// </summary>
    [PublicAPI]
    [MQ2Type("taskmember")]
    public class TaskMemberType : MQ2DataType
    {
        internal TaskMemberType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Name of the task member
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Is this member the task leader?
        /// </summary>
        public bool Leader => GetMember<BoolType>("Leader");

        /// <summary>
        /// Index of the member in the list (1 based)
        /// </summary>
        public int? Index => GetMember<IntType>("Index");
    }
}