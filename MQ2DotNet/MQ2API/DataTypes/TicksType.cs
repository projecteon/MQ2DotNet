using System;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a number of in game ticks
    /// </summary>
    [PublicAPI]
    [MQ2Type("ticks")]
    public class TicksType : MQ2DataType
    {
        internal TicksType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// The hours component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? Hours => GetMember<IntType>("Hours");

        /// <summary>
        /// The minutes component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? Minutes => GetMember<IntType>("Minutes");

        /// <summary>
        /// The seconds component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? Seconds => GetMember<IntType>("Seconds");

        /// <summary>
        /// The total time in "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        // ReSharper disable once InconsistentNaming
        public string TimeHMS => GetMember<StringType>("TimeHMS");

        /// <summary>
        /// The total time in "mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public string Time => GetMember<StringType>("Time");

        /// <summary>
        /// The total number of minutes
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? TotalMinutes => GetMember<IntType>("TotalMinutes");

        /// <summary>
        /// The total number of seconds
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? TotalSeconds => GetMember<IntType>("TotalSeconds");

        /// <summary>
        /// The number of ticks
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public int? Ticks => GetMember<IntType>("Ticks");

        /// <summary>
        /// Implicit conversion to TimeSpan
        /// </summary>
        /// <param name="ticksType"></param>
        /// <returns></returns>
        public static implicit operator TimeSpan?(TicksType ticksType)
        {
            // Dword is the number of 6 second ticks
            return ticksType != null ? TimeSpan.FromSeconds(6 * ticksType.VarPtr.Dword) : (TimeSpan?) null;
        }
    }
}