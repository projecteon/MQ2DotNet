using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a benchmark. This does not seem to be implemented.
    /// </summary>
    [PublicAPI]
    // The definition exists in MQ2, but the implementation doesn't and it's never added as a type
    //[MQ2Type("benchmark")]
    public class BenchmarkType : MQ2DataType
    {
        internal BenchmarkType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }
    }
}