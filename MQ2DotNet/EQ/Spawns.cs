using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Utility;

namespace MQ2DotNet.EQ
{
    /// <summary>
    /// Contains utility methods and properties relating to ingame chat (messages in a chat window, from EQ or MQ2)
    /// </summary>
    [PublicAPI]
    public class Spawns
    {
        internal Spawns()
        {
        }
        
        /// <summary>
        /// All spawns in the current zone
        /// </summary>
        public IEnumerable<SpawnType> All
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