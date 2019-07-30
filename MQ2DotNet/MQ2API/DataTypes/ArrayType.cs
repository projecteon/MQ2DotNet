using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 array type. Not well supported
    /// </summary>
    [PublicAPI]
    [MQ2Type("array")]
    public class ArrayType : MQ2DataType
    {
        internal ArrayType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }
    }
}