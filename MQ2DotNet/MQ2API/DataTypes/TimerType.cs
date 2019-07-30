using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a timer
    /// </summary>
    [PublicAPI]
    [MQ2Type("timer")]
    public class TimerType : MQ2DataType
    {
        internal TimerType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Current value of the timer in 100ms intervals
        /// </summary>
        public int? Value => GetMember<IntType>("Value");

        /// <summary>
        /// Original value of the timer in 100ms, from when the variable was first created
        /// </summary>
        public int? OriginalValue => GetMember<IntType>("OriginalValue");
    }
}