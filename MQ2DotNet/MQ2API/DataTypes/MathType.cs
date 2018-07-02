using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    [Obsolete("Use System.Math")]
    public class MathType : MQ2DataType
    {
        internal MathType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }
    }
}