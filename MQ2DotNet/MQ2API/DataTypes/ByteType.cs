using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a byte
    /// </summary>
    [PublicAPI]
    [MQ2Type("byte")]
    public class ByteType : MQ2DataType
    {
        internal ByteType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Implicit conversion to a byte
        /// </summary>
        /// <param name="typeVar"></param>
        public static implicit operator byte(ByteType typeVar)
        {
            return (byte) (typeVar.VarPtr.Dword & 0xFF);
        }
    }
}