namespace MQ2DotNet.MQ2API.DataTypes
{
    public class DoubleType : MQ2DataType
    {
        internal DoubleType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public static implicit operator double?(DoubleType typeVar)
        {
            return typeVar?.VarPtr.Double;
        }
    }
}