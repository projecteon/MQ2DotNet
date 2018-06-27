namespace MQ2DotNet.MQ2API.DataTypes
{
    public class DoubleType : MQ2DataType
    {
        public static implicit operator double(DoubleType typeVar)
        {
            return typeVar.VarPtr.Double;
        }
    }
}