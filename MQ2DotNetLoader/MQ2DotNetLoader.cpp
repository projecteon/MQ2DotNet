#define TEST
#include "../../MQ2Plugin.h"
#include <strsafe.h>
#include <metahost.h>
#import <mscorlib.tlb> raw_interfaces_only				\
	auto_rename											\
    high_property_prefixes("_get","_put","_putref")		\
    rename("ReportEvent", "InteropServices_ReportEvent")

#pragma comment(lib, "mscoree.lib")

//using namespace mscorlib;

PLUGIN_VERSION(0.1);
PreSetup("MQ2DotNetLoader");

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
extern "C" __declspec(dllexport) PCHAR __stdcall GetIniPath() { return gszINIPath; }

// Exported MQ2Type functions
extern "C" __declspec(dllexport) bool MQ2Type__FromData(MQ2Type * pThis, MQ2VARPTR &VarPtr, MQ2TYPEVAR &Source) { return pThis->FromData(VarPtr, Source); }
extern "C" __declspec(dllexport) bool MQ2Type__FromString(MQ2Type * pThis, MQ2VARPTR &VarPtr, PCHAR Source) { return pThis->FromString(VarPtr, Source); }
extern "C" __declspec(dllexport) void MQ2Type__InitVariable(MQ2Type * pThis, MQ2VARPTR &VarPtr) { pThis->InitVariable(VarPtr); }
extern "C" __declspec(dllexport) void MQ2Type__FreeVariable(MQ2Type * pThis, MQ2VARPTR &VarPtr) { pThis->FreeVariable(VarPtr); }
extern "C" __declspec(dllexport) bool MQ2Type__GetMember(MQ2Type * pThis, MQ2VARPTR VarPtr, PCHAR Member, PCHAR Index, MQ2TYPEVAR &Dest) { return pThis->GetMember(VarPtr, Member, Index, Dest); }
extern "C" __declspec(dllexport) bool MQ2Type__ToString(MQ2Type * pThis, MQ2VARPTR VarPtr, PCHAR Destination) { return pThis->ToString(VarPtr, Destination); }

PLUGIN_API VOID InitializePlugin(VOID)
{
	if (gszINIPath[0])
		StringCbPrintfW(g_wzStubPath, MAX_PATH, L"%hs\\%ws", gszINIPath, L"MQ2DotNet.dll");
	else // If loaded by the test program, INIPath won't be set
		StringCbPrintfW(g_wzStubPath, MAX_PATH, L"%ws", L"MQ2DotNet.dll");

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

// The rest of the PLUGIN_API functions just call the callback (which will be set to the managed version of the function) if they're set and the CLR is loaded

PLUGIN_API VOID ShutdownPlugin(VOID)
{
	// Unfortunately, no way to fully unload. The default appdomain stays, as does any assembly loaded in it, e.g. MQ2DotNet.
	// The only side effect of this is the inability to patch this dll while a game instance is open.
	// Other assemblies are loaded in their own AppDomain, and can be unloaded any time
	if (g_bLoaded && g_pfShutdownPlugin)
		g_pfShutdownPlugin();
}

PLUGIN_API VOID OnCleanUI(VOID)
{
	if (g_bLoaded && g_pfOnCleanUI)
		g_pfOnCleanUI();
}

PLUGIN_API VOID OnReloadUI(VOID)
{
	if (g_bLoaded && g_pfOnReloadUI)
		g_pfOnReloadUI();
}

PLUGIN_API VOID OnDrawHUD(VOID)
{
	if (g_bLoaded && g_pfOnDrawHUD)
		g_pfOnDrawHUD();
}

PLUGIN_API VOID SetGameState(DWORD GameState)
{
	if (g_bLoaded && g_pfSetGameState)
		g_pfSetGameState(GameState);
}

PLUGIN_API VOID OnPulse(VOID)
{
	if (g_bLoaded && g_pfOnPulse)
		g_pfOnPulse();
}

PLUGIN_API DWORD OnWriteChatColor(PCHAR Line, DWORD Color, DWORD Filter)
{
	if (g_bLoaded && g_pfOnWriteChatColor)
		return g_pfOnWriteChatColor(Line, Color, Filter);
	return 0;
}

PLUGIN_API DWORD OnIncomingChat(PCHAR Line, DWORD Color)
{
	if (g_bLoaded && g_pfOnIncomingChat)
		return g_pfOnIncomingChat(Line, Color);
	return 0;
}

PLUGIN_API VOID OnAddSpawn(PSPAWNINFO pNewSpawn)
{
	if (g_bLoaded && g_pfOnAddSpawn)
		g_pfOnAddSpawn(pNewSpawn);
}

PLUGIN_API VOID OnRemoveSpawn(PSPAWNINFO pSpawn)
{
	if (g_bLoaded && g_pfOnRemoveSpawn)
		g_pfOnRemoveSpawn(pSpawn);
}

PLUGIN_API VOID OnAddGroundItem(PGROUNDITEM pNewGroundItem)
{
	if (g_bLoaded && g_pfOnAddGroundItem)
		g_pfOnAddGroundItem(pNewGroundItem);
}

PLUGIN_API VOID OnRemoveGroundItem(PGROUNDITEM pGroundItem)
{
	if (g_bLoaded && g_pfOnRemoveGroundItem)
		g_pfOnRemoveGroundItem(pGroundItem);
}

PLUGIN_API VOID BeginZone(VOID)
{
	if (g_bLoaded && g_pfBeginZone)
		g_pfBeginZone();
}

PLUGIN_API VOID EndZone(VOID)
{
	if (g_bLoaded && g_pfEndZone)
		g_pfEndZone();
}

PLUGIN_API VOID OnZoned(VOID)
{
	if (g_bLoaded && g_pfOnZoned)
		g_pfOnZoned();
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