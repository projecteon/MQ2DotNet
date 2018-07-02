namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ByteType : MQ2DataType
    {
        internal ByteType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public static implicit operator byte(ByteType typeVar)
        {
            return (byte) (typeVar.VarPtr.Dword & 0xFF);
        }
    }
}