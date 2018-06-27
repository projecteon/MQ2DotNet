namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TimerType : MQ2DataType
    {
        public IntType Value => GetMember<IntType>("Value");
        public IntType OriginalValue => GetMember<IntType>("OriginalValue");
    }
}