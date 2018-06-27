using System.Runtime.InteropServices;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class StringType : MQ2DataType
    {
        public static implicit operator string(StringType typeVar)
        {
            return Marshal.PtrToStringAnsi(typeVar.VarPtr.Ptr);
        }
    }
}