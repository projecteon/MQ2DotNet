using System;
using System.Drawing;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Data component of an MQ2 variable
    /// </summary>
    [PublicAPI]

# if WIN64
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
# else
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
#endif
    public struct MQ2VarPtr
    {
#pragma warning disable 1591
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

#if WIN64
        [FieldOffset(0x10)]
#else
        [FieldOffset(0x8)]
#endif
        public long Which;


#if WIN64
        [FieldOffset(0x18)]
#else
        [FieldOffset(0x10)]
#endif
        public uint HighPart;
#pragma warning restore 1591
    }
}