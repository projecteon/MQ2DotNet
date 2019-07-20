using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a benchmark. This does not seem to be implemented.
    /// </summary>
    [PublicAPI]
    public class BenchmarkType : MQ2DataType
    {
        internal BenchmarkType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }
    }
}