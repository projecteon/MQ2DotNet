// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class KeyRingType : MQ2DataType
    {
        /// <summary>
        /// Index of the item in the list (1 based)
        /// </summary>
        public IntType Index => GetMember<IntType>("Index");

        /// <summary>
        /// Name of the item
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");
    }
}