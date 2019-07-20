using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 array type. Not well supported
    /// </summary>
    [PublicAPI]
    public class ArrayType : MQ2DataType
    {
        internal ArrayType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }
    }
}