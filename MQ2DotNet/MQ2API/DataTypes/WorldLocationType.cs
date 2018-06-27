namespace MQ2DotNet.MQ2API.DataTypes
{
    public class WorldLocationType : MQ2DataType
    {
        public IntType ID => GetMember<IntType>("ID");
        public ZoneType Zone => GetMember<ZoneType>("Zone");
        public FloatType Y => GetMember<FloatType>("Y");
        public FloatType X => GetMember<FloatType>("X");
        public FloatType Z => GetMember<FloatType>("Z");
        public FloatType Heading => GetMember<FloatType>("Heading");
    }
}