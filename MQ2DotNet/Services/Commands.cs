using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Utility;

namespace MQ2DotNet.Services
{
    /// <summary>
    /// Plugin functions for adding or removing commands
    /// </summary>
    [PublicAPI]
    public sealed class Commands : CriticalFinalizerObject, IDisposable
    {
        private readonly EventLoopContext _eventLoopContext;

        internal Commands(EventLoopContext eventLoopContext)
        {
            _eventLoopContext = eventLoopContext;
        }

        /// <inheritdoc />
        ~Commands()
        {
            RemoveAllCommands();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            RemoveAllCommands();
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        /// <summary>
        /// Delegate for a synchronous command handler
        /// </summary>
        /// <param name="args"></param>
        public delegate void Command(params string[] args);

        /// <summary>
        /// Delegate for an asynchronous command handler
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public delegate Task AsyncCommand(params string[] args);

        /// <summary>
        /// Add a new synchronous command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <param name="EQ"></param>
        /// <param name="parse"></param>
        /// <param name="inGame"></param>
        public void AddCommand(string command, Command handler, bool EQ = false, bool parse = true, bool inGame = false)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Commands));

            AddCommand(command, (pChar, buffer) =>
            {
                try
                {
                    // Like plugin API callbacks, command handlers get executed with our sync context set
                    _eventLoopContext.SetExecuteRestore(() => handler(GetArgs(buffer).ToArray()));
                }
                catch (Exception e)
                {
                    MQ2.WriteChatGeneralError($"Exception in {command}: {e}");
                    MQ2.WriteChatGeneralError(e.ToString());
                }
            });
        }

        /// <summary>
        /// Add a new asynchronous command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <param name="EQ"></param>
        /// <param name="parse"></param>
        /// <param name="inGame"></param>
        public void AddAsyncCommand(string command, AsyncCommand handler, bool EQ = false, bool parse = true, bool inGame = false)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Commands));

            AddCommand(command, (pChar, buffer) =>
            {
                // Like plugin API callbacks, command handlers get executed with our sync context set
                _eventLoopContext.SetExecuteRestore(() =>
                {
                    try
                    {
                        // When an async command is executed, instead of calling the handler directly, a task is created to await the handler
                        // As I understand it, this basically means the handler will be posted as a continuation to EventLoopContext, and run on the next DoEvents()
                        var task = handler(GetArgs(buffer).ToArray());
                        Task.Factory.StartNew(async () => await task, CancellationToken.None, TaskCreationOptions.None,
                            TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch (Exception e)
                    {
                        // This won't catch exceptions from the command handler, since that will get called from EventLoopContext.DoEvents
                        MQ2.WriteChatGeneralError($"Exception in {command}:");
                        MQ2.WriteChatGeneralError(e.ToString());
                    }
                });
            });
        }

        /// <summary>
        /// Removes a command, and removes the stored reference to the delegate if it was added from this plugin
        /// </summary>
        /// <param name="command">Command to remove, including the slash e.g. "/echo"</param>
        public void RemoveCommand(string command)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Commands));

            if (_commands.ContainsKey(command))
            {
                _commands.Remove(command);
                MQ2RemoveCommand(command);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        private int RemoveAllCommands()
        {
            var count = 0;

            foreach (var command in _commands.Keys)
            {
                MQ2RemoveCommand(command);
                count++;
            }

            return count;
        }

        // .NET marshalling of delegates is a bit painful. If you pass a delegate to an unmanaged function, that doesn't count as a reference.
        // This means it could later get garbage collected, since the delegate is no longer referenced (even though the function it points to still exists).
        // To make life easier, this class keeps a copy of it so whatever class uses AddCommand can use it like normal
        private readonly Dictionary<string, fEQCommand> _commands = new Dictionary<string, fEQCommand>();

        private bool _disposed;

        /// <summary>
        /// Adds a new command
        /// Note: this function will ensure the delegate is not garbage collected prior to RemoveCommand being called
        /// </summary>
        /// <param name="command">Text to look for, including the slash e.g. "/echo"</param>
        /// <param name="function">Method to be invoked when command is executed</param>
        /// <param name="EQ">TODO: What is this?</param>
        /// <param name="parse">If <c>true</c>, MQ2 variables will be parsed prior to invoking <paramref name="function"/></param>
        /// <param name="inGame">TODO: What is this?</param>
        private void AddCommand(string command, fEQCommand function, bool EQ = false, bool parse = true, bool inGame = false)
        {
            if (_commands.ContainsKey(command))
                throw new ApplicationException("Command already exists");

            _commands[command] = function;
            MQ2AddCommand(command, function, EQ, parse, inGame);
        }

        /// <summary>
        /// Split a string into an array of arguments separated by spaces
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private static List<string> GetArgs(string buffer)
        {
            var args = new List<string>();
            var sb = new StringBuilder();
            var inQuote = false;

            foreach (char c in buffer)
            {
                switch (c)
                {
                    case '"':
                        inQuote = !inQuote;
                        break;

                    case ' ':
                        if (inQuote)
                            sb.Append(c);
                        else
                        {
                            args.Add(sb.ToString());
                            sb.Clear();
                        }
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            }

            if (sb.Length > 0)
                args.Add(sb.ToString());

            return args;
        }

        #region MQ2Main imports
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private delegate void fEQCommand(IntPtr pCharSpawn, [MarshalAs(UnmanagedType.LPStr)] string Buffer);

        [DllImport("MQ2Main.dll", EntryPoint = "AddCommand", CallingConvention = CallingConvention.Cdecl)]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static extern void MQ2AddCommand([MarshalAs(UnmanagedType.LPStr)] string Command, fEQCommand Function, bool EQ = false, bool Parse = true, bool InGame = false);

        [DllImport("MQ2Main.dll", EntryPoint = "RemoveCommand", CallingConvention = CallingConvention.Cdecl)]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static extern bool MQ2RemoveCommand([MarshalAs(UnmanagedType.LPStr)] string Command);
        #endregion
    }
}
