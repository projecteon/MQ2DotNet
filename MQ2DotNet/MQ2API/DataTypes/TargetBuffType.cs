// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TargetBuffType : SpellType
    {
        internal TargetBuffType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Memory address of the spell ID DWORD for this buff slot in CTARGETWND
        /// </summary>
        public new IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Index (0 based) of this buff in the target's buff window, i.e. slot #
        /// </summary>
        public IntType Index => GetMember<IntType>("Index");

        /// <summary>
        /// Remaining duration on the buff
        /// </summary>
        public new TimeStampType Duration => GetMember<TimeStampType>("Duration");
    }
}