using System;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a timestamp
    /// </summary>
    [PublicAPI]
    [MQ2Type("timestamp")]
    public class TimeStampType : MQ2DataType
    {
        internal TimeStampType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }
        
        /// <summary>
        /// The hours component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? Hours => GetMember<Int64Type>("Hours");

        /// <summary>
        /// The minutes component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? Minutes => GetMember<Int64Type>("Minutes");

        /// <summary>
        /// The seconds component of "hh:mm:ss"
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? Seconds => GetMember<Int64Type>("Seconds");

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
        public long? TotalMinutes => GetMember<Int64Type>("TotalMinutes");

        /// <summary>
        /// The total number of seconds
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? TotalSeconds => GetMember<Int64Type>("TotalSeconds");

        /// <summary>
        /// Number of milliseconds
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? Raw => GetMember<Int64Type>("Raw");

        /// <summary>
        /// Number of seconds
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public float? Float => GetMember<FloatType>("Float");

        /// <summary>
        /// Equivalent number of ticks
        /// </summary>
        [Obsolete("Use conversion to TimeSpan")]
        public long? Ticks => GetMember<Int64Type>("Ticks");
        
        /// <summary>
        /// Implicit conversion to TimeSpan
        /// </summary>
        /// <param name="timestampType"></param>
        /// <returns></returns>
        public static implicit operator TimeSpan? (TimeStampType timestampType)
        {
            // Dword is in ms
            return timestampType != null ? TimeSpan.FromMilliseconds(timestampType.VarPtr.Dword) : (TimeSpan?)null;
        }
    }
}