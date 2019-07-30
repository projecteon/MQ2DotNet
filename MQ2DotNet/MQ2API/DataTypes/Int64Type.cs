using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a 64 bit integer
    /// </summary>
    [PublicAPI]
    [MQ2Type("int64")]
    public class Int64Type : MQ2DataType
    {
        internal Int64Type(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
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