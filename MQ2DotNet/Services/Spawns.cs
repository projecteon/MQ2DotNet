using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Utility;

namespace MQ2DotNet.Services
{
    /// <summary>
    /// Contains utility methods and properties relating to spawns
    /// </summary>
    [PublicAPI]
    public class Spawns
    {
# if WIN64
        private const int NEXT_SPAWN_PTR_SIZE = 16;
# else
        private const int NEXT_SPAWN_PTR_SIZE = 8;
#endif

#if WIN64
        private const int NEXT_GROUND_ITEM_PTR_SIZE = 8;
#else
        private const int NEXT_GROUND_ITEM_PTR_SIZE = 4;
#endif

        private readonly MQ2TypeFactory _mq2TypeFactory;

        internal Spawns(MQ2TypeFactory mq2TypeFactory)
        {
            _mq2TypeFactory = mq2TypeFactory;
        }

        /// <summary>
        /// All spawns in the current zone
        /// </summary>
        public IEnumerable<SpawnType> All
        {
            get
            {
                var hDll = NativeMethods.LoadLibrary("eqlib.dll");
                var ppSpawnManager = Marshal.ReadIntPtr(NativeMethods.GetProcAddress(hDll, "pSpawnManager"));
                var pSpawnManager = Marshal.ReadIntPtr(ppSpawnManager);
                var pSpawn = Marshal.ReadIntPtr(pSpawnManager + NEXT_SPAWN_PTR_SIZE);

                while (pSpawn != IntPtr.Zero)
                {
                    yield return new SpawnType(_mq2TypeFactory, pSpawn);
                    pSpawn = Marshal.ReadIntPtr(pSpawn + NEXT_SPAWN_PTR_SIZE);
                }
            }
        }

        /// <summary>
        /// All ground spawns in the current zone
        /// </summary>
        [Obsolete("Not working correctly with MQ next", true)]
        public IEnumerable<GroundType> AllGround
        {
            get
            {
                var hDll = NativeMethods.LoadLibrary("eqlib.dll");
                var ppGroundItemListManager = Marshal.ReadIntPtr(NativeMethods.GetProcAddress(hDll, "pItemList"));
                var pGroundItemListManager = Marshal.ReadIntPtr(ppGroundItemListManager);
                var pGroundItem = Marshal.ReadIntPtr(pGroundItemListManager + NEXT_GROUND_ITEM_PTR_SIZE);

                while (pGroundItem != IntPtr.Zero)
                {
                    yield return new GroundType(_mq2TypeFactory, pGroundItem);
                    pGroundItem = Marshal.ReadIntPtr(pGroundItem + NEXT_GROUND_ITEM_PTR_SIZE);
                }
            }
        }
    }
}