using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.EQ
{
    public class Spawns
    {
        internal Spawns()
        {

        }
        
        public static IEnumerable<SpawnType> All
        {
            get
            {
                var hDll = NativeMethods.LoadLibrary("MQ2Main.dll");
                var ppSpawnManager = Marshal.ReadIntPtr(NativeMethods.GetProcAddress(hDll, "ppSpawnManager"));
                var pSpawnManager = Marshal.ReadIntPtr(ppSpawnManager);
                var pSpawn = Marshal.ReadIntPtr(pSpawnManager + 8);

                while (pSpawn != IntPtr.Zero)
                {
                    yield return new SpawnType(pSpawn);
                    pSpawn = Marshal.ReadIntPtr(pSpawn + 8);
                }
            }
        }

    }
}