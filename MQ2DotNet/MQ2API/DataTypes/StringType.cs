using System.Runtime.InteropServices;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class StringType : MQ2DataType
    {
        internal StringType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public static implicit operator string(StringType typeVar)
        {
            return typeVar != null ? Marshal.PtrToStringAnsi(typeVar.VarPtr.Ptr) : null;
        }
    }
}