using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for details about another type
    /// </summary>
    [PublicAPI]
    [MQ2Type("type")]
    public class TypeType : MQ2DataType
    {
        internal TypeType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Member = new IndexedStringMember<int, IntType, string>(this, "Member");
        }

        /// <summary>
        /// Type name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Member name from an internal ID number (1 based), or ID number from name
        /// </summary>
        public IndexedStringMember<int, IntType, string> Member { get; }
    }
}