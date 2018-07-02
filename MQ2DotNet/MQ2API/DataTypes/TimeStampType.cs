using System;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TimeStampType : MQ2DataType
    {
        internal TimeStampType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type Hours => GetMember<Int64Type>("Hours");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type Minutes => GetMember<Int64Type>("Minutes");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type Seconds => GetMember<Int64Type>("Seconds");

        // ReSharper disable once InconsistentNaming
        [Obsolete("Use conversion to TimeSpan")]
        public StringType TimeHMS => GetMember<StringType>("TimeHMS");

        [Obsolete("Use conversion to TimeSpan")]
        public StringType Time => GetMember<StringType>("Time");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type TotalMinutes => GetMember<Int64Type>("TotalMinutes");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type TotalSeconds => GetMember<Int64Type>("TotalSeconds");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type Raw => GetMember<Int64Type>("Raw");

        [Obsolete("Use conversion to TimeSpan")]
        public FloatType Float => GetMember<FloatType>("Float");

        [Obsolete("Use conversion to TimeSpan")]
        public Int64Type Ticks => GetMember<Int64Type>("Ticks");

        public static implicit operator TimeSpan(TimeStampType timeStampType)
        {
            // Dword is in ms, constructor wants number of 100ns intervals
            return new TimeSpan((long) 10_000 * timeStampType.VarPtr.Dword);
        }
    }
}