using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MQ2DotNet.Utility
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string szDllName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hDll, string szProcName);
        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
