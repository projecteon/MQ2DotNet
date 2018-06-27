namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ByteType : MQ2DataType
    {
        public static implicit operator byte(ByteType typeVar)
        {
            return (byte) (typeVar.VarPtr.Dword & 0xFF);
        }
    }
}