// MQ2DotNetLoader.cpp : Defines the entry point for the DLL application.
//

// PLUGIN_API is only to be used for callbacks.  All existing callbacks at this time
// are shown below. Remove the ones your plugin does not use.  Always use Initialize
// and Shutdown for setup and cleanup.


#pragma comment(lib, "mscoree.lib")	

#include <mq/Plugin.h>
#include <strsafe.h>
#include <metahost.h>
#import <mscorlib.tlb> raw_interfaces_only				\
	auto_rename											\
    high_property_prefixes("_get","_put","_putref")		\
    rename("ReportEvent", "InteropServices_ReportEvent")


PreSetup("MQ2DotNetLoader");
PLUGIN_VERSION(0.1);

/**
 * Avoid Globals if at all possible, since they persist throughout your program.
 * But if you must have them, here is the place to put them.
 */
// bool ShowMQ2DotNetLoaderWindow = true;

// COM smart pointer typedefs
_COM_SMARTPTR_TYPEDEF(ICLRMetaHost, IID_ICLRMetaHost);
_COM_SMARTPTR_TYPEDEF(ICLRRuntimeInfo, IID_ICLRRuntimeInfo);
_COM_SMARTPTR_TYPEDEF(ICLRRuntimeHost, IID_ICLRRuntimeHost);


// CLR functions & globals
bool LoadCLR();
ICLRMetaHostPtr g_pMetaHost{ nullptr };
ICLRRuntimeInfoPtr g_pRuntimeInfo{ nullptr };
ICLRRuntimeHostPtr g_pRuntimeHost{ nullptr };
bool g_bLoaded{ false };
wchar_t g_wzStubPath[MAX_PATH] = { 0 };

// Functions in the managed dll. All standard plugin callbacks except initialize, since there's no point having that
extern "C" __declspec(dllexport) fMQShutdownPlugin g_pfShutdownPlugin{ nullptr };
extern "C" __declspec(dllexport) fMQCleanUI g_pfOnCleanUI{ nullptr };
extern "C" __declspec(dllexport) fMQReloadUI g_pfOnReloadUI{ nullptr };
extern "C" __declspec(dllexport) fMQDrawHUD g_pfOnDrawHUD{ nullptr };
extern "C" __declspec(dllexport) fMQSetGameState g_pfSetGameState{ nullptr };
extern "C" __declspec(dllexport) fMQPulse g_pfOnPulse{ nullptr };
extern "C" __declspec(dllexport) fMQIncomingChat g_pfOnIncomingChat{ nullptr };
extern "C" __declspec(dllexport) fMQWriteChatColor g_pfOnWriteChatColor{ nullptr };
extern "C" __declspec(dllexport) fMQSpawn g_pfOnAddSpawn{ nullptr };
extern "C" __declspec(dllexport) fMQSpawn g_pfOnRemoveSpawn{ nullptr };
extern "C" __declspec(dllexport) fMQGroundItem g_pfOnAddGroundItem{ nullptr };
extern "C" __declspec(dllexport) fMQGroundItem g_pfOnRemoveGroundItem{ nullptr };
extern "C" __declspec(dllexport) fMQBeginZone g_pfBeginZone{ nullptr };
extern "C" __declspec(dllexport) fMQEndZone g_pfEndZone{ nullptr };
extern "C" __declspec(dllexport) fMQZoned g_pfOnZoned{ nullptr };

// Exported helper functions to make things easier in the managed world
extern "C" __declspec(dllexport) PCHAR __stdcall GetIniPath() { return gPathConfig; }

// Exported MQ2Type functions
extern "C" __declspec(dllexport) bool MQ2Type__FromData(MQ2Type * pThis, MQ2VARPTR &VarPtr, MQ2TYPEVAR &Source) { return pThis->FromData(VarPtr, Source); }
extern "C" __declspec(dllexport) bool MQ2Type__FromString(MQ2Type * pThis, MQ2VARPTR &VarPtr, PCHAR Source) { return pThis->FromString(VarPtr, Source); }
extern "C" __declspec(dllexport) void MQ2Type__InitVariable(MQ2Type * pThis, MQ2VARPTR &VarPtr) { pThis->InitVariable(VarPtr); }
extern "C" __declspec(dllexport) void MQ2Type__FreeVariable(MQ2Type * pThis, MQ2VARPTR &VarPtr) { pThis->FreeVariable(VarPtr); }
extern "C" __declspec(dllexport) bool MQ2Type__GetMember(MQ2Type * pThis, MQ2VARPTR VarPtr, PCHAR Member, PCHAR Index, MQ2TYPEVAR &Dest) { return pThis->GetMember(VarPtr, Member, Index, Dest); }
extern "C" __declspec(dllexport) bool MQ2Type__ToString(MQ2Type * pThis, MQ2VARPTR VarPtr, PCHAR Destination) { return pThis->ToString(VarPtr, Destination); }


//extern "C" __declspec(dllexport) bool MQ2Type__FromData(MQ2Type * pThis, MQVarPtr & VarPtr, const MQTypeVar & Source) { return pThis->FromData(VarPtr, Source); }
//extern "C" __declspec(dllexport) bool MQ2Type__FromString(MQ2Type * pThis, MQVarPtr & VarPtr, const char* Source) { return pThis->FromString(VarPtr, Source); }
//extern "C" __declspec(dllexport) void MQ2Type__InitVariable(MQ2Type * pThis, MQVarPtr & VarPtr) { pThis->InitVariable(VarPtr); }
//extern "C" __declspec(dllexport) void MQ2Type__FreeVariable(MQ2Type * pThis, MQVarPtr & VarPtr) { pThis->FreeVariable(VarPtr); }
//extern "C" __declspec(dllexport) bool MQ2Type__GetMember(MQ2Type * pThis, MQVarPtr VarPtr, const char* Member, char* Index, MQTypeVar & Dest) { return pThis->GetMember(VarPtr, Member, Index, Dest); }
//extern "C" __declspec(dllexport) bool MQ2Type__ToString(MQ2Type * pThis, MQVarPtr VarPtr, char* Destination) { return pThis->ToString(VarPtr, Destination); }

/**
 * @fn InitializePlugin
 *
 * This is called once on plugin initialization and can be considered the startup
 * routine for the plugin.
 */
PLUGIN_API void InitializePlugin()
{
	DebugSpewAlways("MQ2DotNetLoader::Initializing version %f", MQ2Version);

	//StringCbPrintfW(g_wzStubPath, MAX_PATH, L"%hs\\MQ2DotNet\\%ws", gPathResources, L"MQ2DotNet.dll");
	StringCbPrintfW(g_wzStubPath, MAX_PATH, L"%hs\\%ws", gPathMQRoot, L"MQ2DotNet.dll");
	WriteChatf("[MQ2DotNetLoader] Attemping to load CLR <%ls>", g_wzStubPath);

	if (g_bLoaded = LoadCLR())
	{
		// Once the CLR is loaded, call the managed method version of this function
		DWORD returnValue;
		DWORD hr = g_pRuntimeHost->ExecuteInDefaultAppDomain(g_wzStubPath, L"MQ2DotNet.PluginStub", L"InitializePlugin", L"", &returnValue);
		if (FAILED(hr))
			WriteChatf("[MQ2DotNetLoader] RegisterCallbacks failed, HRESULT 0x%08lx", hr);
		else
			if (FAILED(returnValue))
				WriteChatf("[MQ2DotNetLoader] Failed to register callbacks");
			else
				WriteChatf("[MQ2DotNetLoader] CLR loaded successfully");
	}
	else
	{
		WriteChatf("[MQ2DotNetLoader] CLR failed to load");
	}
}

/**
 * @fn ShutdownPlugin
 *
 * This is called once when the plugin has been asked to shutdown.  The plugin has
 * not actually shut down until this completes.
 */
PLUGIN_API void ShutdownPlugin()
{
	DebugSpewAlways("MQ2DotNetLoader::Shutting down");

	// Unfortunately, no way to fully unload. The default appdomain stays, as does any assembly loaded in it, e.g. MQ2DotNet.
	// The only side effect of this is the inability to patch this dll while a game instance is open.
	// Other assemblies are loaded in their own AppDomain, and can be unloaded any time
	if (g_bLoaded && g_pfShutdownPlugin)
		g_pfShutdownPlugin();
}

/**
 * @fn OnCleanUI
 *
 * This is called once just before the shutdown of the UI system and each time the
 * game requests that the UI be cleaned.  Most commonly this happens when a
 * /loadskin command is issued, but it also occurs when reaching the character
 * select screen and when first entering the game.
 *
 * One purpose of this function is to allow you to destroy any custom windows that
 * you have created and cleanup any UI items that need to be removed.
 */
PLUGIN_API void OnCleanUI()
{
	if (g_bLoaded && g_pfOnCleanUI)
		g_pfOnCleanUI();
}

/**
 * @fn OnReloadUI
 *
 * This is called once just after the UI system is loaded. Most commonly this
 * happens when a /loadskin command is issued, but it also occurs when first
 * entering the game.
 *
 * One purpose of this function is to allow you to recreate any custom windows
 * that you have setup.
 */
PLUGIN_API void OnReloadUI()
{
	if (g_bLoaded && g_pfOnReloadUI)
		g_pfOnReloadUI();
}

/**
 * @fn OnDrawHUD
 *
 * This is called each time the Heads Up Display (HUD) is drawn.  The HUD is
 * responsible for the net status and packet loss bar.
 *
 * Note that this is not called at all if the HUD is not shown (default F11 to
 * toggle).
 *
 * Because the net status is updated frequently, it is recommended to have a
 * timer or counter at the start of this call to limit the amount of times the
 * code in this section is executed.
 */
PLUGIN_API void OnDrawHUD()
{
	if (g_bLoaded && g_pfOnDrawHUD)
		g_pfOnDrawHUD();
}

/**
 * @fn SetGameState
 *
 * This is called when the GameState changes.  It is also called once after the
 * plugin is initialized.
 *
 * For a list of known GameState values, see the constants that begin with
 * GAMESTATE_.  The most commonly used of these is GAMESTATE_INGAME.
 *
 * When zoning, this is called once after @ref OnBeginZone @ref OnRemoveSpawn
 * and @ref OnRemoveGroundItem are all done and then called once again after
 * @ref OnEndZone and @ref OnAddSpawn are done but prior to @ref OnAddGroundItem
 * and @ref OnZoned
 *
 * @param GameState int - The value of GameState at the time of the call
 */
PLUGIN_API void SetGameState(int GameState)
{
	if (g_bLoaded && g_pfSetGameState)
		g_pfSetGameState(GameState);
}


/**
 * @fn OnPulse
 *
 * This is called each time MQ2 goes through its heartbeat (pulse) function.
 *
 * Because this happens very frequently, it is recommended to have a timer or
 * counter at the start of this call to limit the amount of times the code in
 * this section is executed.
 */
PLUGIN_API void OnPulse()
{
	if (g_bLoaded && g_pfOnPulse)
		g_pfOnPulse();
}

/**
 * @fn OnWriteChatColor
 *
 * This is called each time WriteChatColor is called (whether by MQ2Main or by any
 * plugin).  This can be considered the "when outputting text from MQ" callback.
 *
 * This ignores filters on display, so if they are needed either implement them in
 * this section or see @ref OnIncomingChat where filters are already handled.
 *
 * If CEverQuest::dsp_chat is not called, and events are required, they'll need to
 * be implemented here as well.  Otherwise, see @ref OnIncomingChat where that is
 * already handled.
 *
 * For a list of Color values, see the constants for USERCOLOR_.  The default is
 * USERCOLOR_DEFAULT.
 *
 * @param Line const char* - The line that was passed to WriteChatColor
 * @param Color int - The type of chat text this is to be sent as
 * @param Filter int - (default 0)
 */
PLUGIN_API DWORD OnWriteChatColor(const char* Line, int Color, int Filter)
{
	if (g_bLoaded && g_pfOnWriteChatColor)
		return g_pfOnWriteChatColor(Line, Color, Filter);
	return 0;
}

/**
 * @fn OnIncomingChat
 *
 * This is called each time a line of chat is shown.  It occurs after MQ filters
 * and chat events have been handled.  If you need to know when MQ2 has sent chat,
 * consider using @ref OnWriteChatColor instead.
 *
 * For a list of Color values, see the constants for USERCOLOR_. The default is
 * USERCOLOR_DEFAULT.
 *
 * @param Line const char* - The line of text that was shown
 * @param Color int - The type of chat text this was sent as
 *
 * @return bool - Whether to filter this chat from display
 */
PLUGIN_API bool OnIncomingChat(const char* Line, DWORD Color)
{
	if (g_bLoaded && g_pfOnIncomingChat)
		return g_pfOnIncomingChat(Line, Color);
	return false;
}

/**
 * @fn OnAddSpawn
 *
 * This is called each time a spawn is added to a zone (ie, something spawns). It is
 * also called for each existing spawn when a plugin first initializes.
 *
 * When zoning, this is called for all spawns in the zone after @ref OnEndZone is
 * called and before @ref OnZoned is called.
 *
 * @param pNewSpawn PSPAWNINFO - The spawn that was added
 */
PLUGIN_API void OnAddSpawn(PSPAWNINFO pNewSpawn)
{
	if (g_bLoaded && g_pfOnAddSpawn)
		g_pfOnAddSpawn(pNewSpawn);
}

/**
 * @fn OnRemoveSpawn
 *
 * This is called each time a spawn is removed from a zone (ie, something despawns
 * or is killed).  It is NOT called when a plugin shuts down.
 *
 * When zoning, this is called for all spawns in the zone after @ref OnBeginZone is
 * called.
 *
 * @param pSpawn PSPAWNINFO - The spawn that was removed
 */
PLUGIN_API void OnRemoveSpawn(PSPAWNINFO pSpawn)
{
	if (g_bLoaded && g_pfOnRemoveSpawn)
		g_pfOnRemoveSpawn(pSpawn);
}

/**
 * @fn OnAddGroundItem
 *
 * This is called each time a ground item is added to a zone (ie, something spawns).
 * It is also called for each existing ground item when a plugin first initializes.
 *
 * When zoning, this is called for all ground items in the zone after @ref OnEndZone
 * is called and before @ref OnZoned is called.
 *
 * @param pNewGroundItem PGROUNDITEM - The ground item that was added
 */
PLUGIN_API void OnAddGroundItem(PGROUNDITEM pNewGroundItem)
{
	if (g_bLoaded && g_pfOnAddGroundItem)
		g_pfOnAddGroundItem(pNewGroundItem);
}

/**
 * @fn OnRemoveGroundItem
 *
 * This is called each time a ground item is removed from a zone (ie, something
 * despawns or is picked up).  It is NOT called when a plugin shuts down.
 *
 * When zoning, this is called for all ground items in the zone after
 * @ref OnBeginZone is called.
 *
 * @param pGroundItem PGROUNDITEM - The ground item that was removed
 */
PLUGIN_API void OnRemoveGroundItem(PGROUNDITEM pGroundItem)
{
	if (g_bLoaded && g_pfOnRemoveGroundItem)
		g_pfOnRemoveGroundItem(pGroundItem);
}

/**
 * @fn OnBeginZone
 *
 * This is called just after entering a zone line and as the loading screen appears.
 */
PLUGIN_API void OnBeginZone()
{
	if (g_bLoaded && g_pfBeginZone)
		g_pfBeginZone();
}

/**
 * @fn OnEndZone
 *
 * This is called just after the loading screen, but prior to the zone being fully
 * loaded.
 *
 * This should occur before @ref OnAddSpawn and @ref OnAddGroundItem are called. It
 * always occurs before @ref OnZoned is called.
 */
PLUGIN_API void OnEndZone()
{
	if (g_bLoaded && g_pfEndZone)
		g_pfEndZone();
}

/**
 * @fn OnZoned
 *
 * This is called after entering a new zone and the zone is considered "loaded."
 *
 * It occurs after @ref OnEndZone @ref OnAddSpawn and @ref OnAddGroundItem have
 * been called.
 */
PLUGIN_API void OnZoned()
{
	if (g_bLoaded && g_pfOnZoned)
		g_pfOnZoned();
}

/**
 * @fn OnUpdateImGui
 *
 * This is called each time that the ImGui Overlay is rendered. Use this to render
 * and update plugin specific widgets.
 *
 * Because this happens extremely frequently, it is recommended to move any actual
 * work to a separate call and use this only for updating the display.
 */
PLUGIN_API void OnUpdateImGui()
{
/*
	if (GetGameState() == GAMESTATE_INGAME)
	{
		if (ShowMQ2DotNetLoaderWindow)
		{
			if (ImGui::Begin("MQ2DotNetLoader", &ShowMQ2DotNetLoaderWindow, ImGuiWindowFlags_MenuBar))
			{
				if (ImGui::BeginMenuBar())
				{
					ImGui::Text("MQ2DotNetLoader is loaded!");
					ImGui::EndMenuBar();
				}
			}
			ImGui::End();
		}
	}
*/
}

/**
 * @fn OnMacroStart
 *
 * This is called each time a macro starts (ex: /mac somemacro.mac), prior to
 * launching the macro.
 *
 * @param Name const char* - The name of the macro that was launched
 */
PLUGIN_API void OnMacroStart(const char* Name)
{
	// DebugSpewAlways("MQ2DotNetLoader::OnMacroStart(%s)", Name);
}

/**
 * @fn OnMacroStop
 *
 * This is called each time a macro stops (ex: /endmac), after the macro has ended.
 *
 * @param Name const char* - The name of the macro that was stopped.
 */
PLUGIN_API void OnMacroStop(const char* Name)
{
	// DebugSpewAlways("MQ2DotNetLoader::OnMacroStop(%s)", Name);
}

/**
 * @fn OnLoadPlugin
 *
 * This is called each time a plugin is loaded (ex: /plugin someplugin), after the
 * plugin has been loaded and any associated -AutoExec.cfg file has been launched.
 * This means it will be executed after the plugin's @ref InitializePlugin callback.
 *
 * This is also called when THIS plugin is loaded, but initialization tasks should
 * still be done in @ref InitializePlugin.
 *
 * @param Name const char* - The name of the plugin that was loaded
 */
PLUGIN_API void OnLoadPlugin(const char* Name)
{
	// DebugSpewAlways("MQ2DotNetLoader::OnLoadPlugin(%s)", Name);
}

/**
 * @fn OnUnloadPlugin
 *
 * This is called each time a plugin is unloaded (ex: /plugin someplugin unload),
 * just prior to the plugin unloading.  This means it will be executed prior to that
 * plugin's @ref ShutdownPlugin callback.
 *
 * This is also called when THIS plugin is unloaded, but shutdown tasks should still
 * be done in @ref ShutdownPlugin.
 *
 * @param Name const char* - The name of the plugin that is to be unloaded
 */
PLUGIN_API void OnUnloadPlugin(const char* Name)
{
	// DebugSpewAlways("MQ2DotNetLoader::OnUnloadPlugin(%s)", Name);
}

bool LoadCLR()
{
	HRESULT hr;

	// Load and start the .NET runtime.
	hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_PPV_ARGS(&g_pMetaHost));
	if (FAILED(hr))
	{
		WriteChatf("CLRCreateInstance failed w/hr 0x%08lx", hr);
		return false;
	}

	// Get the ICLRRuntimeInfo corresponding to a particular CLR version
	hr = g_pMetaHost->GetRuntime(L"v4.0.30319", IID_PPV_ARGS(&g_pRuntimeInfo));
	if (FAILED(hr))
	{
		WriteChatf("ICLRMetaHost::GetRuntime failed w/hr 0x%08lx", hr);
		return false;
	}

	// Check if the specified runtime can be loaded into the process. This 
	// method will take into account other runtimes that may already be 
	// loaded into the process and set pbLoadable to TRUE if this runtime can 
	// be loaded in an in-process side-by-side fashion. 
	BOOL fLoadable;
	hr = g_pRuntimeInfo->IsLoadable(&fLoadable);
	if (FAILED(hr))
	{
		WriteChatf("ICLRRuntimeInfo::IsLoadable failed w/hr 0x%08lx", hr);
		return false;
	}

	if (!fLoadable)
	{
		WriteChatf(".NET runtime cannot be loaded");
		return false;
	}

	// Load the CLR into the current process
	hr = g_pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_PPV_ARGS(&g_pRuntimeHost));
	if (FAILED(hr))
	{
		WriteChatf("ICLRRuntimeInfo::GetInterface failed w/hr 0x%08lx", hr);
		return false;
	}

	// Start the CLR.
	hr = g_pRuntimeHost->Start();
	if (FAILED(hr))
	{
		WriteChatf("CLR failed to start w/hr 0x%08lx", hr);
		return false;
	}

	return true;
}