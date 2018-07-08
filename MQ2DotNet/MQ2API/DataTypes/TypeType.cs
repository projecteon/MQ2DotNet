// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TypeType : MQ2DataType
    {
        internal TypeType(MQ2TypeVar typeVar) : base(typeVar)
        {
            Member = new IndexedMember<StringType, int, IntType, string>(this, "Member");
        }

        /// <summary>
        /// Type name
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// Member name from an internal ID number (1 based), or ID number from name
        /// </summary>
        public IndexedMember<StringType, int, IntType, string> Member { get; }
    }
}