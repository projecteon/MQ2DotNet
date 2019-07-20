using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// Contains various mathematical functions. Not implemented for .NET
    /// </summary>
    [Obsolete("Use System.Math")]
    public class MathType : MQ2DataType
    {
        internal MathType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }
    }
}