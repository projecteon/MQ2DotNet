using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a single precision float
    /// </summary>
    [PublicAPI]
    public class FloatType : MQ2DataType
    {
        internal FloatType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Implicit conversion to nullable float
        /// </summary>
        /// <param name="typeVar"></param>
        public static implicit operator float?(FloatType typeVar)
        {
            return typeVar?.VarPtr.Float;
        }
    }
}