﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Used by MQ2 to represent a variable. Consists of a type component, pType, that points to an instance of MQ2Type, and a data component, VarPtr, that stores data for this variable
    /// </summary>

# if WIN64
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
# else
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
#endif
    public struct MQ2TypeVar
    {
        // Since we don't care about members and will only be calling functions, marshalling as IntPtr seems the easiest/safest option
        [FieldOffset(0)] 
        internal MQ2VarPtr VarPtr;
#if WIN64
        [FieldOffset(0x20)]
#else
        [FieldOffset(0x18)]
#endif
        internal IntPtr Type;

        internal bool TryGetMember(string memberName, string index, out MQ2TypeVar result)
        {
            if (Type == IntPtr.Zero)
                throw new InvalidOperationException();

            return MQ2Type__GetMember(Type, VarPtr, memberName, index, out result) && result.Type != IntPtr.Zero;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var result = new StringBuilder(2048);
            if (!MQ2Type__ToString(Type, VarPtr, result))
                throw new ApplicationException("MQ2Type::ToString failed");

            return result.ToString();
        }

        #region Unmanaged imports
        // These are all class methods and I don't want to deal with PInvoking that, so the loader dll has some helper methods
        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static extern bool MQ2Type__FromData(IntPtr pThis, out MQ2VarPtr varPtr, ref MQ2TypeVar source);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static extern bool MQ2Type__FromString(IntPtr pThis, out MQ2VarPtr varPtr, string source);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static extern void MQ2Type__InitVariable(IntPtr pThis, out MQ2VarPtr varPtr);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static extern void MQ2Type__FreeVariable(IntPtr pThis, ref MQ2VarPtr varPtr);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool MQ2Type__GetMember(IntPtr pThis, MQ2VarPtr varPtr, string member, string index, out MQ2TypeVar dest);

        [DllImport("MQ2DotNetLoader.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool MQ2Type__ToString(IntPtr pThis, MQ2VarPtr varPtr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder destination);
        #endregion
    }
}