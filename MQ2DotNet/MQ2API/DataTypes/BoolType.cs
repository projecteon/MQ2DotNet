namespace MQ2DotNet.MQ2API.DataTypes
{
    public class BoolType : MQ2DataType
    {
        internal BoolType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public static implicit operator bool(BoolType typeVar)
        {
            return typeVar.VarPtr.Dword != 0;
        }
    }
}