using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;

namespace MQ2DotNet
{
    // ReSharper disable once UnusedMember.Global
    public static class PluginStub
    {
        #region Delegates/typedefs
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        // ReSharper disable InconsistentNaming
        private delegate void fMQShutdownPlugin();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQCleanUI();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQReloadUI();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQDrawHUD();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQSetGameState(uint gameState);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQPulse();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint fMQIncomingChat([MarshalAs(UnmanagedType.LPStr)]string line, uint color);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint fMQWriteChatColor([MarshalAs(UnmanagedType.LPStr)]string line, uint color, uint filter);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQSpawn(IntPtr pSpawn);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQGroundItem(IntPtr pGroundItem);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQBeginZone();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQEndZone();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void fMQZoned();
        // ReSharper restore InconsistentNaming
        #endregion

        #region Instances of delegates
        // These are required to keep the garbage collector from cleaning up the parameter to GetFunctionPointerForDelegate
        private static readonly fMQShutdownPlugin _shutdownPlugin = ShutdownPlugin;
        private static readonly fMQBeginZone _beginZone = BeginZone;
        private static readonly fMQEndZone _endZone = EndZone;
        private static readonly fMQGroundItem _onAddGroundItem = OnAddGroundItem;
        private static readonly fMQSpawn _onAddSpawn = OnAddSpawn;
        private static readonly fMQCleanUI _onCleanUI = OnCleanUI;
        private static readonly fMQDrawHUD _onDrawHUD = OnDrawHUD;
        private static readonly fMQIncomingChat _onIncomingChat = OnIncomingChat;
        private static readonly fMQPulse _onPulse = OnPulse;
        private static readonly fMQReloadUI _onReloadUI = OnReloadUI;
        private static readonly fMQGroundItem _onRemoveGroundItem = OnRemoveGroundItem;
        private static readonly fMQSpawn _onRemoveSpawn = OnRemoveSpawn;
        private static readonly fMQWriteChatColor _onWriteChatColor = OnWriteChatColor;
        private static readonly fMQSetGameState _setGameState = SetGameState;
        private static readonly fMQZoned _onZoned = OnZoned;
        #endregion

        private static readonly Dictionary<string, PluginLoader> _plugins = new Dictionary<string, PluginLoader>();
        private static readonly Dictionary<string, ProgramLoader> _programs = new Dictionary<string, ProgramLoader>();
        private static ScriptRunner _script;

        // ReSharper disable once UnusedMember.Global
        public static int InitializePlugin(string arg)
        {
            // This will be the first managed function that gets called. 
            try
            {
                // MQ2DotNet.dll exports function pointers that it then calls when the corresponding plugin function is called
                // Here we set them to our managed functions in this class
                IntPtr hDll = NativeMethods.LoadLibrary("MQ2DotNetLoader.dll");
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfShutdownPlugin"), Marshal.GetFunctionPointerForDelegate(_shutdownPlugin));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnCleanUI"), Marshal.GetFunctionPointerForDelegate(_onCleanUI));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnReloadUI"), Marshal.GetFunctionPointerForDelegate(_onReloadUI));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnDrawHUD"), Marshal.GetFunctionPointerForDelegate(_onDrawHUD));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfSetGameState"), Marshal.GetFunctionPointerForDelegate(_setGameState));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnPulse"), Marshal.GetFunctionPointerForDelegate(_onPulse));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnIncomingChat"), Marshal.GetFunctionPointerForDelegate(_onIncomingChat));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnWriteChatColor"), Marshal.GetFunctionPointerForDelegate(_onWriteChatColor));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnAddSpawn"), Marshal.GetFunctionPointerForDelegate(_onAddSpawn));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnRemoveSpawn"), Marshal.GetFunctionPointerForDelegate(_onRemoveSpawn));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnAddGroundItem"), Marshal.GetFunctionPointerForDelegate(_onAddGroundItem));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnRemoveGroundItem"), Marshal.GetFunctionPointerForDelegate(_onRemoveGroundItem));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfBeginZone"), Marshal.GetFunctionPointerForDelegate(_beginZone));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfEndZone"), Marshal.GetFunctionPointerForDelegate(_endZone));
                Marshal.WriteIntPtr(NativeMethods.GetProcAddress(hDll, "g_pfOnZoned"), Marshal.GetFunctionPointerForDelegate(_onZoned));

                // Add command to load/unload .net plugins
                Commands.AddCommand("/netplugin", NetPluginCommand);

                // And command to run/end .net programs
                Commands.AddCommand("/netrun", NetRunCommand);
                Commands.AddCommand("/netend", NetEndCommand);

                // And C# scripts
                Commands.AddCommand("/cs", CsCommand);
                Commands.AddCommand("/endcs", EndCsCommand);

                // The script app domain gets loaded immediately
                _script = new ScriptRunner("CsScriptDomain");

                // Load any plugins that are set to autoload. Fuck ini files
                try
                {
                    foreach (Match match in Regex.Matches(File.ReadAllText(MQ2.INIPath + "\\MQ2DotNet.ini"), @"(?<name>\w+)=1"))
                        NetPluginCommand(match.Groups["name"].Value);
                }
                catch (Exception)
                {
                }

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        private static void ShutdownPlugin()
        {
            Commands.RemoveCommand("/netplugin");
            Commands.RemoveCommand("/netrun");
            Commands.RemoveCommand("/netend");
            Commands.RemoveCommand("/cs");
            Commands.RemoveCommand("/endcs");

            // Call shutdown on each plugin, then dispose of it to unload the appdomain/dll
            foreach (var kvp in _plugins.ToList())
            {
                kvp.Value.ShutdownPlugin();
                kvp.Value.Dispose();
                _plugins.Remove(kvp.Key);
            }

            // And likewise on each program
            foreach (var kvp in _programs.ToList())
            {
                kvp.Value.Stop();
                kvp.Value.Dispose();
                _programs.Remove(kvp.Key);
            }

            _script.Stop();
            _script.Dispose();
        }

        private static void NetPluginCommand(params string[] args)
        {
            // Argument parsing & validation
            if (args.Length == 0 || args.Length > 3
                                 || (args.Length >= 2 && args[1] != "noauto" && args[1] != "unload")
                                 || (args.Length == 3 && (args[1] != "unload" || args[2] != "noauto")))
            {
                MQ2.WriteChatPlugin("Usage: /netplugin <plugin> [unload] [noauto]");
                MQ2.WriteChatPlugin("Usage: /netplugin list");
                return;
            }

            // List command
            if (args[0] == "list")
            {
                foreach (var plugin in _plugins.Keys)
                    MQ2.WriteChatPlugin(plugin);
                MQ2.WriteChatPlugin($"{_plugins.Count} plugins loaded");
                return;
            }

            var pluginName = args[0];
            var unload = args.Length >= 2 && args[1] == "unload";
            var noauto = (args.Length >= 2 && args[1] == "noauto") || (args.Length >= 3 && args[2] == "noauto");

            // Load command
            if (!unload)
            {
                if (_plugins.ContainsKey(pluginName))
                {
                    MQ2.WriteChatPlugin($"{pluginName} already loaded");
                    return;
                }

                try
                {
                    _plugins[pluginName] = new PluginLoader(pluginName, pluginName + "Domain");
                    MQ2.WriteChatPlugin($"{pluginName} loaded");
                    NativeMethods.WritePrivateProfileString("Plugins", pluginName, noauto ? "0" : "1", MQ2.INIPath + "\\MQ2DotNet.ini");

                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Error loading plugin {pluginName}:");
                    MQ2.WriteChatPluginError(e.ToString());
                }

                return;
            }

            // Unload command
            if (_plugins.ContainsKey(pluginName))
            {
                _plugins[pluginName].Dispose();
                _plugins.Remove(pluginName);

                MQ2.WriteChatPlugin($"{pluginName} unloaded");

                if (noauto)
                    NativeMethods.WritePrivateProfileString("Plugins", pluginName, "0", MQ2.INIPath + "\\MQ2DotNet.ini");
            }
            else
            {
                MQ2.WriteChatPlugin($"{pluginName} not loaded");
            }
        }

        private static void CsCommand(params string[] args)
        {
            if (args.Length == 0)
            {
                MQ2.WriteChatScript("Usage: /cs <file> [<arg1> <arg2> ...]");
                return;
            }

            var scriptFile = args[0];

            try
            {
                _script.RunScript(scriptFile, args.Skip(1).ToArray());

            }
            catch (Exception e)
            {
                MQ2.WriteChatScriptError($"Error running C# script {scriptFile}:");
                MQ2.WriteChatScriptError(e.ToString());
            }
        }

        private static void EndCsCommand(params string[] args)
        {
            if (_script.Name == null)
            {
                MQ2.WriteChatScript("No C# script running");
                return;
            }

            _script.Stop();
        }

        private static void NetRunCommand(params string[] args)
        {
            if (args.Length == 0)
            {
                MQ2.WriteChatProgram("Usage: /netrun <program> [<arg1> <arg2> ...]");
                return;
            }

            var programName = args[0];

            try
            {
                _programs[programName] = new ProgramLoader(programName, programName + "Domain");
                MQ2.WriteChatProgram($"Starting {programName}");

            }
            catch (Exception e)
            {
                MQ2.WriteChatProgramError($"Error loading {programName}:");
                MQ2.WriteChatProgramError(e.ToString());
            }

            try
            {
                _programs[programName].Start(args.Skip(1).ToArray());
            }
            catch (Exception e)
            {
                _programs[programName].Stop();
                _programs[programName].Dispose();
                _programs.Remove(programName);
                MQ2.WriteChatProgramError($"Error starting {programName}:");
                MQ2.WriteChatProgramError(e.ToString());
            }
        }

        private static void NetEndCommand(params string[] args)
        {
            if (args.Length != 1)
            {
                MQ2.WriteChatProgram("Usage: /netend <program|*>");
                return;
            }

            if (_programs.Count == 0)
            {
                MQ2.WriteChatProgram("No programs running");
                return;
            }

            var programName = args[0];

            if (programName == "*")
            {
                foreach (var kvp in _programs.ToArray())
                {
                    kvp.Value.Stop();
                    kvp.Value.Dispose();
                    _programs.Remove(kvp.Key);
                    MQ2.WriteChatProgram($"{kvp.Key} ended");
                }
            }
            else
            {
                if (_programs.TryGetValue(programName, out var program))
                {
                    program.Stop();
                    program.Dispose();
                    _programs.Remove(programName);
                    MQ2.WriteChatProgram($"{programName} ended");
                }
                else
                    MQ2.WriteChatProgram($"{programName} not running");
            }
        }

        private static void OnPulse()
        {
            // Call OnPulse for each plugin
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnPulse();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnPulse in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }

            // Also call OnPulse for each program, which will run any queued continuations. Remove & unload any finished programs
            foreach (var kvp in _programs.ToList())
                try
                {
                    var status = kvp.Value.OnPulse();
                    if (status == TaskStatus.RanToCompletion || status == TaskStatus.Canceled ||
                        status == TaskStatus.Faulted)
                    {
                        MQ2.WriteChatProgram($"{kvp.Key} finished, status = {status}");
                        kvp.Value.Stop();
                        kvp.Value.Dispose();
                        _programs.Remove(kvp.Key);
                    }
                }
                catch (Exception e)
                {
                    MQ2.WriteChatProgramError($"Exception in OnPulse in program {kvp.Key}");
                    MQ2.WriteChatProgramError(e.ToString());
                }

            try
            {
                _script.OnPulse();
            }
            catch (Exception e)
            {
                MQ2.WriteChatScriptError($"Exception in OnPulse in script");
                MQ2.WriteChatScriptError(e.ToString());
            }
        }

        #region Plugin API callbacks, each of these will invoke the corresponding method on each loaded plugin
            private static void BeginZone()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.BeginZone();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in BeginZone in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void EndZone()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.EndZone();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in EndZone in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnAddGroundItem(IntPtr pNewGroundItem)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnAddGroundItem(pNewGroundItem);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnAddGroundItem in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnAddSpawn(IntPtr pNewSpawn)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnAddSpawn(pNewSpawn);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnAddSpawn in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnCleanUI()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnCleanUI();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnCleanUI in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnDrawHUD()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnDrawHUD();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnDrawHUD in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static uint OnIncomingChat(string line, uint color)
        {
            uint ret = 0;

            foreach (var kvp in _plugins)
                try
                {
                    ret |= kvp.Value.OnIncomingChat(line, color);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnIncomingChat in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }

            return ret;
        }

        private static void OnReloadUI()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnReloadUI();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnReloadUI in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnRemoveGroundItem(IntPtr pGroundItem)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnRemoveGroundItem(pGroundItem);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnRemoveGroundItem in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void OnRemoveSpawn(IntPtr pSpawn)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnRemoveSpawn(pSpawn);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnRemoveSpawn in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static uint OnWriteChatColor(string line, uint color, uint filter)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnWriteChatColor(line, color, filter);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnWriteChatColor in plugin {kvp.Key}:");
                    MQ2.WriteChatPluginError(e.ToString());
                }

            return 0;
        }

        private static void OnZoned()
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.OnZoned();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnZoned in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }

        private static void SetGameState(uint gameState)
        {
            foreach (var kvp in _plugins)
                try
                {
                    kvp.Value.SetGameState(gameState);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in SetGameState in plugin {kvp.Key}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
        }
        #endregion
    }
}
