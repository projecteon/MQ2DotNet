using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace MQ2DotNet.MQ2API
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    internal struct MQ2VarPtr
    {
        [FieldOffset(0)]
        public IntPtr Ptr;

        [FieldOffset(0)]
        public float Float;

        [FieldOffset(0)]
        public uint Dword;

        [FieldOffset(0)]
        public int Int;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        //[FieldOffset(0)]
        //public byte[] Array; // This one seems pointless
        
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        //[FieldOffset(0)]
        //public byte[] FullArray;

        [FieldOffset(0)]
        public double Double;

        [FieldOffset(0)]
        public long Int64;

        [FieldOffset(0)]
        public ulong UInt64;

        public Color Argb
        {
            get => Color.FromArgb(Int);
            set => Int = value.ToArgb();
        }

        [FieldOffset(4)]
        public uint HighPart;
    }
}