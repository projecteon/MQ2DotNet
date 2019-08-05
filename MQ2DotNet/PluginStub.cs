using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Plugin;
using MQ2DotNet.Program;
using MQ2DotNet.Script;
using MQ2DotNet.Services;
using MQ2DotNet.Utility;

namespace MQ2DotNet
{
    /// <summary>
    /// Class containing functions for MQ2DotNetLoader to call from the regular plugin callbacks
    /// </summary>
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
        
        /// <summary>
        /// Synchronization context that runs all continuations in OnPulse
        /// </summary>
        /// <remarks>Only used for async commands, of which we have none. It's here because it's required by Commands.</remarks>
        private static readonly EventLoopContext _eventLoopContext = new EventLoopContext();

        /// <summary>
        /// Service for adding commands
        /// </summary>
        private static readonly Commands _commands = new Commands(_eventLoopContext);

        private static readonly List<AppDomainBase> _appDomains = new List<AppDomainBase>();

        private static readonly string _iniFilePath = new MQ2().INIPath + "\\MQ2DotNet.ini";

        private static readonly string _mq2DirectoryPath = new MQ2().INIPath;

        private static ReadOnlyDictionary<string, PluginAppDomain> Plugins => new ReadOnlyDictionary<string, PluginAppDomain>(_appDomains
            .Where(d => d is PluginAppDomain)
            .Cast<PluginAppDomain>()
            .ToDictionary(p => p.Name, p => p));

        private static ReadOnlyDictionary<string, ProgramAppDomain> Programs => new ReadOnlyDictionary<string, ProgramAppDomain>(_appDomains
            .Where(d => d is ProgramAppDomain)
            .Cast<ProgramAppDomain>()
            .ToDictionary(p => p.Name, p => p));

        private static IReadOnlyList<ScriptAppDomain> ScriptDomains =>  _appDomains.Where(d => d is ScriptAppDomain).Cast<ScriptAppDomain>().ToList().AsReadOnly();

        private static ReadOnlyDictionary<string, ScriptAppDomain> ActiveScripts =>
            new ReadOnlyDictionary<string, ScriptAppDomain>(ScriptDomains.Where(d => d.Active).ToDictionary(s => s.Name, s => s));

        /// <summary>
        /// Entrypoint, called by MQ2DotNetLoader
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [PublicAPI]
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

#if DEBUG
                MQ2.WriteChatGeneral($"Loaded debug version {GitVersionInformation.MajorMinorPatch} ({GitVersionInformation.ShortSha})");
#else
                MQ2.WriteChatGeneral($"Loaded version {GitVersionInformation.MajorMinorPatch} ({GitVersionInformation.ShortSha})");
#endif
                
                // Add command to load/unload .net plugins
                _commands.AddCommand("/netplugin", NetPluginCommand);

                // And command to run/end .net programs
                _commands.AddCommand("/netrun", NetRunCommand);
                _commands.AddCommand("/netend", NetEndCommand);

                // And C# scripts
                _commands.AddCommand("/cs", CsCommand);
                _commands.AddCommand("/csend", EndCsCommand);
                _commands.AddCommand("/csreload", CsReloadCommand);

                // Load any plugins that are set to autoload. Fuck ini files
                try
                {
                    foreach (Match match in Regex.Matches(File.ReadAllText(_iniFilePath), @"(?<name>\w+)=1"))
                        LoadPlugin(match.Groups["name"].Value, true, false);
                }
                catch (FileNotFoundException)
                {
                    // It's OK if this doesn't exist, it gets created automatically by WritePrivateProfile and this is the only place it gets read
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
            _commands.Dispose();

            // Unload each app domain (by disposing of it)
            foreach (var appDomain in _appDomains.ToList())
            {
                appDomain.Dispose();
                _appDomains.Remove(appDomain);
            }
        }

#region .NET plugin commands
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
                foreach (var plugin in Plugins.Keys)
                    MQ2.WriteChatPlugin(plugin);
                MQ2.WriteChatPlugin($"{Plugins.Count} plugins loaded");
                return;
            }

            var pluginName = args[0];
            var unload = args.Length >= 2 && args[1] == "unload";
            var noauto = (args.Length >= 2 && args[1] == "noauto") || (args.Length >= 3 && args[2] == "noauto");

            // Load/unload command
            if (unload)
                UnloadPlugin(pluginName, noauto);
            else
                LoadPlugin(pluginName, noauto, true);
        }

        private static void LoadPlugin(string pluginName, bool noauto, bool showSuccessMessage)
        {
            if (Plugins.ContainsKey(pluginName))
            {
                MQ2.WriteChatPlugin($"{pluginName} already loaded");
                return;
            }

            try
            {
                // First look for it in its own folder
                var pluginFilePath = $"{_mq2DirectoryPath}\\DotNet\\Plugins\\{pluginName}\\{pluginName}.dll";
                if (!File.Exists(pluginFilePath))
                {
                    // Then in the plugins folder
                    pluginFilePath = $"{_mq2DirectoryPath}\\DotNet\\Plugins\\{pluginName}.dll";
                    if (!File.Exists(pluginFilePath))
                    {
                        MQ2.WriteChatPluginError($"Couldn't find plugin: {pluginName}");
                        return;
                    }
                }

                _appDomains.Add(PluginAppDomain.Load(pluginFilePath, pluginName + "PluginDomain"));
                NativeMethods.WritePrivateProfileString("Plugins", pluginName, noauto ? "0" : "1", _iniFilePath);

                // No need to spam for each plugin that's loaded automatically from the ini file
                if (showSuccessMessage)
                    MQ2.WriteChatPlugin($"{pluginName} loaded");
            }
            catch (Exception e)
            {
                MQ2.WriteChatPluginError($"Error loading plugin {pluginName}:");
                MQ2.WriteChatPluginError(e.ToString());
            }
        }

        private static void UnloadPlugin(string pluginName, bool noauto)
        {
            if (Plugins.TryGetValue(pluginName, out var pluginAppDomain))
            {
                pluginAppDomain.Dispose();
                _appDomains.Remove(pluginAppDomain);

                if (noauto)
                    NativeMethods.WritePrivateProfileString("Plugins", pluginName, "0", _iniFilePath);

                MQ2.WriteChatPlugin($"{pluginName} unloaded");
            }
            else
            {
                MQ2.WriteChatPlugin($"{pluginName} is not loaded");
            }
        }
#endregion

#region C# script commands
        private static void CsCommand(params string[] args)
        {
            if (args.Length == 0)
            {
                MQ2.WriteChatScript("Usage: /cs <file> [<arg1> <arg2> ...]");
                return;
            }

            StartScript(args[0], args.Skip(1).ToArray());
        }

        private static void EndCsCommand(params string[] args)
        {
            if (ScriptDomains.Count == 0)
            {
                MQ2.WriteChatScript("No C# scripts running");
                return;
            }

            if (args.Length == 0)
            {
                if (ScriptDomains.Count(s => s.Active) == 1)
                {
                    EndScript(ScriptDomains.First(s => s.Active).Name);
                    return;
                }

                MQ2.WriteChatScript("Usage: /endcs [<script|*>]");
                MQ2.WriteChatScript("If multiple scripts are running, an argument is mandatory");
                return;
            }

            var scriptName = args[0];

            if (scriptName == "*")
            {
                foreach (var kvp in ActiveScripts.ToArray())
                    EndScript(kvp.Key);
            }
            else
            {
                if (ActiveScripts.ContainsKey(scriptName))
                    EndScript(scriptName);
                else
                    MQ2.WriteChatScript($"{scriptName} is not running");
            }
        }

        private static void CsReloadCommand(params string[] args)
        {
            var count = 0;

            // Force unload on each inactive domain, and load a new one in its place
            foreach (var scriptAppDomain in ScriptDomains.Where(d => !d.Active).ToList())
            {
                count++;
                scriptAppDomain.Dispose();
                _appDomains.Remove(scriptAppDomain);
                _appDomains.Add(ScriptAppDomain.Load("ScriptDomain" + Guid.NewGuid()));
            }

            MQ2.WriteChatScript($"Unloaded {count} idle app domains");
        }

        private static void StartScript(string scriptName, params string[] args)
        {
            if (ActiveScripts.ContainsKey(scriptName))
            {
                MQ2.WriteChatScript($"{scriptName} already running");
                return;
            }

            try
            {
                // Find the file
                var scriptFilePath = _mq2DirectoryPath + "\\DotNet\\Scripts\\" + scriptName;
                if (!scriptFilePath.EndsWith(".csx"))
                    scriptFilePath += ".csx";

                if (!File.Exists(scriptFilePath))
                    throw new FileNotFoundException();

                // Grab the first available script domain
                var scriptDomain = ScriptDomains.FirstOrDefault(s => !s.Active);

                // Or in a loaded one if there's none available
                if (scriptDomain == null)
                {
                    scriptDomain = ScriptAppDomain.Load("ScriptDomain" + Guid.NewGuid());
                    _appDomains.Add(scriptDomain);
                }

                scriptDomain.Start(scriptFilePath, args);
            }
            catch (Exception e)
            {
                MQ2.WriteChatScriptError($"Error running C# script {scriptName}:");
                MQ2.WriteChatScriptError(e.ToString());
            }
        }

        private static void EndScript(string scriptName)
        {
            if (ActiveScripts.TryGetValue(scriptName, out var scriptAppDomain))
            {
                // Try to cancel cleanly
                scriptAppDomain.Cancel();
                
                // If it doesn't work, force unload the app domain
                if (scriptAppDomain.Status != TaskStatus.Canceled)
                {
                    MQ2.WriteChatScriptWarning($"{scriptName} did not respond to cancellation");

                    scriptAppDomain.Dispose();
                    _appDomains.Remove(scriptAppDomain);
                }

                MQ2.WriteChatScript($"{scriptName} stopped");
            }
            else
            {
                MQ2.WriteChatScript($"{scriptName} is not running");
            }
        }
#endregion

#region .NET program commands
        private static void NetRunCommand(params string[] args)
        {
            if (args.Length == 0)
            {
                MQ2.WriteChatProgram("Usage: /netrun <program> [<arg1> <arg2> ...]");
                return;
            }

            StartProgram(args[0], args.Skip(1).ToArray());
        }

        private static void NetEndCommand(params string[] args)
        {
            if (args.Length != 1)
            {
                MQ2.WriteChatProgram("Usage: /netend <program|*>");
                return;
            }

            if (Programs.Count == 0)
            {
                MQ2.WriteChatProgram("No programs running");
                return;
            }

            var programName = args[0];

            if (programName == "*")
            {
                foreach (var kvp in Programs.ToArray())
                    EndProgram(kvp.Key);
            }
            else
            {
                if (Programs.ContainsKey(programName))
                    EndProgram(programName);
                else
                    MQ2.WriteChatProgram($"{programName} is not running");
            }
        }

        private static void StartProgram(string programName, string[] args)
        {
            if (Programs.ContainsKey(programName))
            {
                MQ2.WriteChatProgram($"{programName} already running");
                return;
            }

            try
            {
                // First look for it in its own folder
                var programFilePath = $"{_mq2DirectoryPath}\\DotNet\\Programs\\{programName}\\{programName}.dll";
                if (!File.Exists(programFilePath))
                {
                    // Then in the programs folder
                    programFilePath = $"{_mq2DirectoryPath}\\DotNet\\Programs\\{programName}.dll";
                    if (!File.Exists(programFilePath))
                    {
                        MQ2.WriteChatProgramError($"Couldn't find program: {programName}");
                        return;
                    }
                }

                var programAppDomain = ProgramAppDomain.Load(programFilePath, programName + "ProgramDomain");
                _appDomains.Add(programAppDomain);
                
                MQ2.WriteChatProgram($"Starting {programName}");

                programAppDomain.Start(args);
            }
            catch (Exception e)
            {
                MQ2.WriteChatProgramError($"Error loading program {programName}:");
                MQ2.WriteChatProgramError(e.ToString());
            }
        }

        private static void EndProgram(string programName)
        {
            if (Programs.TryGetValue(programName, out var programAppDomain))
            {
                // Try to cancel cleanly
                programAppDomain.Cancel();
                if (programAppDomain.Status != TaskStatus.Canceled)
                    MQ2.WriteChatProgramWarning($"{programName} did not respond to cancellation");

                // Regardless, unload the AppDomain which will shut everything down
                programAppDomain.Dispose();
                _appDomains.Remove(programAppDomain);
                
                MQ2.WriteChatProgram($"{programName} stopped");
            }
            else
            {
                MQ2.WriteChatProgram($"{programName} is not running");
            }
        }
#endregion

#region Plugin API callbacks, each of these will invoke the corresponding method on each loaded AppDomain
        private static void OnPulse()
        {
            _eventLoopContext.DoEvents(true);

            foreach (var appDomain in _appDomains.ToList())
            {
                try
                {
                    appDomain.OnPulse();

                    if (appDomain is ProgramAppDomain program && program.Finished)
                    {
                        MQ2.WriteChatProgram($"{program.Name} finished: {program.Status}");
                        appDomain.Dispose();
                        _appDomains.Remove(appDomain);
                    }
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnPulse in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }

            // Make sure there's 2 available script domains
            if (ScriptDomains.Count(d => !d.Active) < 2)
            {
                _appDomains.Add(ScriptAppDomain.Load("ScriptDomain" + Guid.NewGuid()));
                _appDomains.Add(ScriptAppDomain.Load("ScriptDomain" + Guid.NewGuid()));
            }
        }

        private static void BeginZone()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeBeginZone();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in BeginZone in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void EndZone()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeEndZone();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in EndZone in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnAddGroundItem(IntPtr pNewGroundItem)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnAddGroundItem(pNewGroundItem);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnAddGroundItem in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnAddSpawn(IntPtr pNewSpawn)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnAddSpawn(pNewSpawn);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnAddSpawn in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnCleanUI()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnCleanUI();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnCleanUI in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnDrawHUD()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnDrawHUD();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnDrawHUD in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static uint OnIncomingChat(string line, uint color)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnChatEQ(line);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnChatEQ in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }

                try
                {
                    appDomain.InvokeOnChat(line);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnChat in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }

            return 0;
        }

        private static void OnReloadUI()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnReloadUI();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnReloadUI in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnRemoveGroundItem(IntPtr pGroundItem)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnRemoveGroundItem(pGroundItem);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnRemoveGroundItem in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void OnRemoveSpawn(IntPtr pSpawn)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnRemoveSpawn(pSpawn);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnRemoveSpawn in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static uint OnWriteChatColor(string line, uint color, uint filter)
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnChatMQ2(line);
                }
                catch (Exception e)
                {
                    // Writing an error message in chat caused by an error message in chat is probably not a great idea
                    //MQ2.WriteChatPluginError($"Exception in OnChatMQ2 in {appDomain.Name}");
                    //MQ2.WriteChatPluginError(e.ToString());
                }

                try
                {
                    appDomain.InvokeOnChat(line);
                }
                catch (Exception e)
                {
                    //MQ2.WriteChatPluginError($"Exception in OnChat in {appDomain.Name}");
                    //MQ2.WriteChatPluginError(e.ToString());
                }
            }

            return 0;
        }

        private static void OnZoned()
        {
            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeOnZoned();
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in OnZoned in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }

        private static void SetGameState(uint gameState)
        {
            var gameStateEnum = Enum.IsDefined(typeof(GameState), gameState)
                ? (GameState) gameState
                : GameState.Unknown;

            foreach (var appDomain in _appDomains)
            {
                try
                {
                    appDomain.InvokeSetGameState(gameStateEnum);
                }
                catch (Exception e)
                {
                    MQ2.WriteChatPluginError($"Exception in SetGameState in {appDomain.Name}");
                    MQ2.WriteChatPluginError(e.ToString());
                }
            }
        }
#endregion
    }
}
