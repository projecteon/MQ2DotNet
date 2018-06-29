namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for BodyType
    public class BodyType : MQ2DataType
    {
        /// <summary>
        /// ID of the body type, internal use only?
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Description e.g. Humanoid
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");
    }
}