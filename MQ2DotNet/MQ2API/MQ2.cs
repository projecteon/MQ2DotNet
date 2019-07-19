using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MQ2DotNet.MQ2API
{
    public static class MQ2
    {
        #region MQ2Main imports
        [DllImport("MQ2Main.dll", EntryPoint = "Calculate", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2Calculate([MarshalAs(UnmanagedType.LPStr)] string formula, out double result);

        [DllImport("MQ2Main.dll", EntryPoint = "ParseMacroData", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool MQ2ParseMacroData([MarshalAs(UnmanagedType.LPStr)] StringBuilder szOriginal, uint BufferSize);

        [DllImport("MQ2Main.dll", EntryPoint = "HideDoCommand", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MQ2HideDoCommand(IntPtr pCharSpawn, [MarshalAs(UnmanagedType.LPStr)] string Command, bool delayed);

        [DllImport("MQ2Main.dll", EntryPoint = "WriteChatf", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MQ2WriteChatf([MarshalAs(UnmanagedType.LPStr)] string buffer);

        [DllImport("MQ2Main.dll", EntryPoint = "WriteChatfSafe", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MQ2WriteChatfSafe([MarshalAs(UnmanagedType.LPStr)] string buffer);
        #endregion

        /// <summary>
        /// Uses MQ2's parser to evaluate a formula
        /// </summary>
        /// <param name="formula">Formula to calculate</param>
        /// <param name="parse">If <c>true</c>, will first parse any MQ2 variables in <paramref name="formula"/> before calculating</param>
        /// <returns>Result of the calculation</returns>
        public static double Calculate(string formula, bool parse = true)
        {
            if (parse)
                formula = Parse(formula);

            if (!MQ2Calculate(formula, out var result))
                throw new FormatException("Could not parse if condition: " + formula);

            return result;
        }

        /// <summary>
        /// Use MQ2's parser to evaluate a formula and return true if it is non-zero
        /// </summary>
        /// <param name="formula">Formula to calculate</param>
        /// <param name="parse">If <c>true</c>, will first parse any MQ2 variables in <paramref name="formula"/> before calculating</param>
        /// <returns>True if the result is non-zero, otherwise false</returns>
        public static bool If(string formula, bool parse = true)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return Calculate(formula, parse) != 0.0;
        }

        /// <summary>
        /// Parse any MQ2 variables in <paramref name="expression"/> and replace them with the resulting text
        /// </summary>
        /// <param name="expression">Expression to parse</param>
        /// <returns>Parsed expression</returns>
        public static string Parse(string expression)
        {
            var sb = new StringBuilder(expression, 2047);
            if (!MQ2ParseMacroData(sb, (uint)sb.Capacity + 1))
                throw new FormatException("Could not parse expression: " + expression);

            return sb.ToString();
        }

        /// <summary>
        /// Execute a command, exactly as if you typed it in the chat window
        /// Note: whether this will parse MQ2 variables or not depends only on the command entered. Use /noparse to force no parsing
        /// </summary>
        /// <param name="command">Command to execute</param>
        public static void DoCommand(string command)
        {
            MQ2HideDoCommand(GetCharSpawn(), command, false);
        }

        private static IntPtr GetCharSpawn()
        {
            var pppPlayer = NativeMethods.GetProcAddress(NativeMethods.LoadLibrary("MQ2Main.dll"), "ppLocalPlayer");
            var ppPlayer = Marshal.ReadIntPtr(pppPlayer);
            return Marshal.ReadIntPtr(ppPlayer);
        }

        /// <summary>
        /// Directory of MQ2 ini files (and binaries too hopefully)
        /// </summary>
        public static string INIPath
        {
            get
            {
                var hDll = NativeMethods.LoadLibrary("MQ2Main.dll");
                return Marshal.PtrToStringAnsi(NativeMethods.GetProcAddress(hDll, "gszINIPath"));
            }
        }

        private static string Sanitize(string text)
        {
            // Trim so as to not crash MQ2/EQ
            var sanitized = text.Substring(0, Math.Min(text.Length, 2047));
            var index = text.IndexOfAny(new[] { '\r', '\n' });
            if (index > 0)
                sanitized = sanitized.Substring(0, index);
            return sanitized;
        }

        /// <summary>
        /// Write a line of chat to the MQ2 chat window
        /// </summary>
        /// <param name="text">Text to write</param>
        public static void WriteChat(string text)
        {
            MQ2WriteChatf(Sanitize(text));
        }

        /// <summary>
        /// Threadsafe version of <see cref="WriteChat"/>
        /// </summary>
        /// <param name="text">Text to write</param>
        public static void WriteChatSafe(string text)
        {
            // Trim so as to not crash MQ2/EQ
            MQ2WriteChatf(Sanitize(text));
        }

        #region Internal WriteChat overloads
        internal static void WriteChatGeneralError(string text)
        {
            WriteChat($"\ag[.NET] \arError: \aw{text}");
        }

        internal static void WriteChatGeneralWarning(string text)
        {
            WriteChat($"\ag[.NET] \ayWarning: \aw{text}");
        }

        internal static void WriteChatGeneral(string text)
        {
            WriteChat($"\ag[.NET] \aw{text}");
        }

        internal static void WriteChatPluginError(string text)
        {
            WriteChat($"\ag[.NET Plugin] \arError: \aw{text}");
        }

        internal static void WriteChatPluginWarning(string text)
        {
            WriteChat($"\ag[.NET Plugin] \ayWarning: \aw{text}");
        }

        internal static void WriteChatPlugin(string text)
        {
            WriteChat($"\ag[.NET Plugin] \aw{text}");
        }

        internal static void WriteChatProgramError(string text)
        {
            WriteChat($"\ag[.NET Program] \arError: \aw{text}");
        }

        internal static void WriteChatProgramWarning(string text)
        {
            WriteChat($"\ag[.NET Program] \ayWarning: \aw{text}");
        }

        internal static void WriteChatProgram(string text)
        {
            WriteChat($"\ag[.NET Program] \aw{text}");
        }

        internal static void WriteChatScriptError(string text)
        {
            WriteChat($"\ag[C# Script] \arError: \aw{text}");
        }

        internal static void WriteChatScriptWarning(string text)
        {
            WriteChat($"\ag[C# Script] \ayWarning: \aw{text}");
        }

        internal static void WriteChatScript(string text)
        {
            WriteChat($"\ag[C# Script] \aw{text}");
        }
        #endregion
    }
}
