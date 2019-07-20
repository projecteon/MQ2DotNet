using System;
using System.Runtime.InteropServices;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a string
    /// </summary>
    public class StringType : MQ2DataType
    {
        private string _string;

        internal StringType(MQ2TypeVar typeVar) : base(typeVar)
        {
            // Since most MQ2 strings share the same storage (DataTypeTemp), lazy evaluation is a bad idea
            _string = typeVar.VarPtr.Ptr != IntPtr.Zero ? Marshal.PtrToStringAnsi(typeVar.VarPtr.Ptr) : null;
        }

        /// <summary>
        /// Implicit conversion to a string
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator string(StringType typeVar)
        {
            return typeVar._string;
        }
    }
}