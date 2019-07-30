using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a time
    /// </summary>
    [PublicAPI]
    [MQ2Type("time")]
    public class TimeType : MQ2DataType
    {
        internal TimeType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
        private struct tm
        {
            public int tm_sec;   // seconds after the minute - [0, 60] including leap second
            public int tm_min;   // minutes after the hour - [0, 59]
            public int tm_hour;  // hours since midnight - [0, 23]
            public int tm_mday;  // day of the month - [1, 31]
            public int tm_mon;   // months since January - [0, 11]
            public int tm_year;  // years since 1900
            public int tm_wday;  // days since Sunday - [0, 6]
            public int tm_yday;  // days since January 1 - [0, 365]
            public int tm_isdst; // daylight savings time flag
        }

        /// <summary>
        /// Hours since midnight
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Hour => GetMember<IntType>("Hour");

        /// <summary>
        /// Hour in 24h time
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public string Hour12 => GetMember<StringType>("Hour12");

        /// <summary>
        /// Minutes after the hour
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Minute => GetMember<IntType>("Minute");

        /// <summary>
        /// Seconds after the minute
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Second => GetMember<IntType>("Second");

        /// <summary>
        /// Day of the week (0 = Sunday)
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? DayOfWeek => GetMember<IntType>("DayOfWeek");

        /// <summary>
        /// Day of the month
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Day => GetMember<IntType>("Day");

        /// <summary>
        /// Month of the year
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Month => GetMember<IntType>("Month");

        /// <summary>
        /// Year
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? Year => GetMember<IntType>("Year");

        /// <summary>
        /// Time in "HH:mm:ss" format (24h time)
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public string Time12 => GetMember<StringType>("Time12");

        /// <summary>
        /// Time in "hh:mm:ss" format (12h time)
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public string Time24 => GetMember<StringType>("Time24");

        /// <summary>
        /// Date in "dd/MM/yyyy" format
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public string Date => GetMember<StringType>("Date");

        /// <summary>
        /// Before 7AM or after 9PM ?!
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public bool Night => GetMember<BoolType>("Night");

        /// <summary>
        /// Number of seconds since midnight
        /// </summary>
        [Obsolete("Use conversion to DateTime")]
        public int? SecondsSinceMidnight => GetMember<IntType>("SecondsSinceMidnight");

        /// <summary>
        /// Implicit conversion to DateTime
        /// </summary>
        /// <param name="timeType"></param>
        public static implicit operator DateTime? (TimeType timeType)
        {
            var pTm = timeType?.VarPtr.Ptr ?? IntPtr.Zero;
            if (pTm == IntPtr.Zero)
                return null;
            var tm = Marshal.PtrToStructure<tm>(pTm);
            return new DateTime(tm.tm_year, tm.tm_mon, tm.tm_mday, tm.tm_hour, tm.tm_min, tm.tm_sec);
        }
    }
}