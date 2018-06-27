using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MQ2DotNet.MQ2API
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    internal struct MQ2TypeVar
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        internal struct MQ2VarPtr
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            [FieldOffset(0)]
            public byte[] FullArray;

            // PInvoke doesn't seem to have good support for unions, so everything else gets handled with BitConverter

            public IntPtr Ptr => new IntPtr(BitConverter.ToInt32(FullArray, 0));
            public uint HighPart => BitConverter.ToUInt32(FullArray, 4);
            public float Float => BitConverter.ToSingle(FullArray, 0);
            public uint Dword => BitConverter.ToUInt32(FullArray, 0);
            public Color Argb => Color.FromArgb(Int);
            public int Int => BitConverter.ToInt32(FullArray, 0);
            public byte[] Array => FullArray.Take(4).ToArray(); // This one seems pointless
            public double Double => BitConverter.ToDouble(FullArray, 0);
            public long Int64 => BitConverter.ToInt64(FullArray, 0);
            public ulong UInt64 => BitConverter.ToUInt64(FullArray, 0);
        }

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