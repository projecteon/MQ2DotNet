using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MQ2DotNet.MQ2API
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    internal struct MQ2TypeVar
    {

        // Since we don't care about members and will only be calling functions, marshalling as IntPtr seems the easiest/safest option
        // Only a 4 byte field but gets packed to 8 bytes. Many hours wasted before realizing this :(
        [FieldOffset(0)] internal IntPtr pType;
        [FieldOffset(8)] public MQ2VarPtr VarPtr;

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2Type__FromData(IntPtr pThis, out MQ2VarPtr VarPtr, ref MQ2TypeVar Source);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2Type__FromString(IntPtr pThis, out MQ2VarPtr VarPtr, string Source);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MQ2Type__InitVariable(IntPtr pThis, out MQ2VarPtr VarPtr);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MQ2Type__FreeVariable(IntPtr pThis, ref MQ2VarPtr VarPtr);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2Type__GetMember(IntPtr pThis, MQ2VarPtr VarPtr, string Member, string Index, out MQ2TypeVar Dest);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2Type__ToString(IntPtr pThis, MQ2VarPtr VarPtr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder Destination);

        public T GetMember<T>(string memberName, string index) where T : MQ2DataType
        {
            if (!MQ2Type__GetMember(pType, VarPtr, memberName, index, out var result))
                return null;

            return (T) MQ2DataType.Create(result);
        }

        public override string ToString()
        {
            var result = new StringBuilder(2048);
            if (!MQ2Type__ToString(pType, VarPtr, result))
                throw new ApplicationException("MQ2Type::ToString failed");

            return result.ToString();
        }
    }
}