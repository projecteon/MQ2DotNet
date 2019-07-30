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
                var hDll = NativeMethods.LoadLibrary("MQ2Main.dll");
                var ppSpawnManager = Marshal.ReadIntPtr(NativeMethods.GetProcAddress(hDll, "ppSpawnManager"));
                var pSpawnManager = Marshal.ReadIntPtr(ppSpawnManager);
                var pSpawn = Marshal.ReadIntPtr(pSpawnManager + 8);

                while (pSpawn != IntPtr.Zero)
                {
                    yield return new SpawnType(_mq2TypeFactory, pSpawn);
                    pSpawn = Marshal.ReadIntPtr(pSpawn + 8);
                }
            }
        }
        
        /// <summary>
        /// All ground spawns in the current zone
        /// </summary>
        public IEnumerable<GroundType> AllGround
        {
            get
            {
                var pGroundItemListManager = GetItemList();
                var pGroundItem = Marshal.ReadIntPtr(pGroundItemListManager);

                while (pGroundItem != IntPtr.Zero)
                {
                    yield return new GroundType(_mq2TypeFactory, pGroundItem);
                    pGroundItem = Marshal.ReadIntPtr(pGroundItem + 4);
                }
            }
        }

        #region Unmanaged imports
        [DllImport("MQ2Main.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetItemList();
        #endregion
    }
}