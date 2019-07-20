using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a 64 bit integer
    /// </summary>
    [PublicAPI]
    public class Int64Type : MQ2DataType
    {
        internal Int64Type(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        internal Int64Type(long value) : base("int64", new MQ2VarPtr() {Int64 = value})
        {
        }

        // MQ2 type has a bunch of members, but it hardly seems worth implementing them here

        /// <summary>
        /// Implicit conversion to a nullable long
        /// </summary>
        /// <param name="typeVar"></param>
        public static implicit operator long?(Int64Type typeVar)
        {
            return typeVar?.VarPtr.Int64;
        }
    }
}