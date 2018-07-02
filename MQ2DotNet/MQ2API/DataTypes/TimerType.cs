// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TimerType : MQ2DataType
    {
        internal TimerType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Current value of the timer in 100ms intervals
        /// </summary>
        public IntType Value => GetMember<IntType>("Value");

        /// <summary>
        /// Original value of the timer in 100ms, from when the variable was first created
        /// </summary>
        public IntType OriginalValue => GetMember<IntType>("OriginalValue");
    }
}