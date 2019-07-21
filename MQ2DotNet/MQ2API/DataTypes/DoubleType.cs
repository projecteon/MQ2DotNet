using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a double precision float
    /// </summary>
    [PublicAPI]
    [MQ2Type("double")]
    public class DoubleType : MQ2DataType
    {
        internal DoubleType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Implicit conversion to double
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator double?(DoubleType typeVar)
        {
            return typeVar?.VarPtr.Double;
        }
    }
}