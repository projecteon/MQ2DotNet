// ReSharper disable UnusedMember.Global
using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TicksType : MQ2DataType
    {
        internal TicksType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        [Obsolete("Use conversion to TimeSpan")]
        public int? Hours => GetMember<IntType>("Hours");

        [Obsolete("Use conversion to TimeSpan")]
        public int? Minutes => GetMember<IntType>("Minutes");

        [Obsolete("Use conversion to TimeSpan")]
        public int? Seconds => GetMember<IntType>("Seconds");

        // ReSharper disable once InconsistentNaming
        [Obsolete("Use conversion to TimeSpan")]
        public string TimeHMS => GetMember<StringType>("TimeHMS");

        [Obsolete("Use conversion to TimeSpan")]
        public string Time => GetMember<StringType>("Time");

        [Obsolete("Use conversion to TimeSpan")]
        public int? TotalMinutes => GetMember<IntType>("TotalMinutes");

        [Obsolete("Use conversion to TimeSpan")]
        public int? TotalSeconds => GetMember<IntType>("TotalSeconds");

        [Obsolete("Use conversion to TimeSpan")]
        public int? Ticks => GetMember<IntType>("Ticks");

        public static implicit operator TimeSpan?(TicksType ticksType)
        {
            // Dword is the number of 6 second ticks, constructor wants number of 100 nano seconds
            return ticksType != null ? new TimeSpan((long)10_000_000 * 6 * ticksType.VarPtr.Dword) : (TimeSpan?) null;
        }
    }
}