// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class HeadingType : MQ2DataType
    {
        internal HeadingType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// The nearest clock direction, e.g. 1-12
        /// </summary>
        public IntType Clock => GetMember<IntType>("Clock");

        /// <summary>
        /// Heading in degrees (same as casting to float). N = 0, E = 90, S = 180, W = 270
        /// </summary>
        public FloatType Degrees => GetMember<FloatType>("Degrees");

        /// <summary>
        /// Heading in degrees, counter clockwise from north. N = 0, W = 90, S = 180, E = 270
        /// </summary>
        public FloatType DegreesCCW => GetMember<FloatType>("DegreesCCW");

        /// <summary>
        /// The short compass direction, eg. "S", "SSE"
        /// </summary>
        public StringType ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// The long compass direction, eg. "south", "south by southeast"
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        public static implicit operator float(HeadingType typeVar)
        {
            return typeVar.VarPtr.Float;
        }
    }
}