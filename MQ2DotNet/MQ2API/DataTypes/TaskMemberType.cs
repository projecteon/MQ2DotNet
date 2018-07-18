// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TaskMemberType : MQ2DataType
    {
        internal TaskMemberType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Name of the task member
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Is this member the task leader?
        /// </summary>
        public BoolType Leader => GetMember<BoolType>("Leader");

        /// <summary>
        /// Index of the member in the list (1 based)
        /// </summary>
        public IntType Index => GetMember<IntType>("Index");
    }
}