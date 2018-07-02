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
        public IntType Hours => GetMember<IntType>("Hours");

        [Obsolete("Use conversion to TimeSpan")]
        public IntType Minutes => GetMember<IntType>("Minutes");

        [Obsolete("Use conversion to TimeSpan")]
        public IntType Seconds => GetMember<IntType>("Seconds");

        // ReSharper disable once InconsistentNaming
        [Obsolete("Use conversion to TimeSpan")]
        public StringType TimeHMS => GetMember<StringType>("TimeHMS");

        [Obsolete("Use conversion to TimeSpan")]
        public StringType Time => GetMember<StringType>("Time");

        [Obsolete("Use conversion to TimeSpan")]
        public IntType TotalMinutes => GetMember<IntType>("TotalMinutes");

        [Obsolete("Use conversion to TimeSpan")]
        public IntType TotalSeconds => GetMember<IntType>("TotalSeconds");

        [Obsolete("Use conversion to TimeSpan")]
        public IntType Ticks => GetMember<IntType>("Ticks");

        public static implicit operator TimeSpan(TicksType ticksType)
        {
            // Dword is the number of 6 second ticks, constructor wants number of 100 nano seconds
            return new TimeSpan((long)10_000_000 * 6 * ticksType.VarPtr.Dword);
        }
    }
}