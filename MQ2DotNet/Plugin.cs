using System;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet
{
    /// <summary>
    /// Class from which a plugin must derive
    /// </summary>
    public abstract class Plugin : MarshalByRefObject
    {
        /// <summary>
        /// Called once when the plugin is first loaded
        /// </summary>
        public virtual void InitializePlugin()
        {
        }

        /// <summary>
        /// Called once before the plugin is unloaded
        /// </summary>
        public virtual void ShutdownPlugin()
        {
        }

        /// <summary>
        /// Called after entering a new zone
        /// </summary>
        public virtual void OnZoned()
        {
        }

        /// <summary>
        /// Called once directly before shutdown of the new ui system, and also every time the game calls CDisplay::CleanGameUI()
        /// </summary>
        public virtual void OnCleanUI()
        {
        }

        /// <summary>
        /// Called once directly after the game ui is reloaded, after issuing /loadskin
        /// </summary>
        public virtual void OnReloadUI()
        {
        }

        /// <summary>
        /// Called every frame that the "HUD" is drawn -- e.g. net status / packet loss bar
        /// </summary>
        public virtual void OnDrawHUD()
        {
        }

        /// <summary>
        /// Called once directly after initialization, and then every time the gamestate changes
        /// </summary>
        public virtual void SetGameState(uint gameState)
        {
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        public virtual void OnPulse()
        {
        }
        
        /// <summary>
        /// Called whenever MQ2 outputs a line of chat
        /// </summary>
        /// <param name="line"></param>
        /// <param name="color"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual uint OnWriteChatColor(string line, uint color, uint filter)
        {
            return 0;
        }

        /// <summary>
        /// Called whenever EQ outputs a line of chat
        /// </summary>
        /// <param name="line"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public virtual uint OnIncomingChat(string line, uint color)
        {
            return 0;
        }

        /// <summary>
        /// Called when a new spawn is added. Will be called once for each spawn in the zone when entering a new zone
        /// </summary>
        public virtual void OnAddSpawn(SpawnType pNewSpawn)
        {
        }

        /// <summary>
        /// Called when a spawn is removed. Will be called once for each spawn in the zone when exiting a zone
        /// </summary>
        public virtual void OnRemoveSpawn(SpawnType pSpawn)
        {
        }

        /// <summary>
        /// Called when a new ground item is added. Will be called once for each ground item in the zone when entering a new zone
        /// </summary>
        public virtual void OnAddGroundItem(GroundType pNewGroundItem)
        {
        }

        /// <summary>
        /// Called when a ground item is removed. Will be called once for each ground item in the zone when exiting a zone
        /// </summary>
        public virtual void OnRemoveGroundItem(GroundType pGroundItem)
        {
        }

        /// <summary>
        /// This is called when we receive the EQ_BEGIN_ZONE packet
        /// </summary>
        public virtual void BeginZone()
        {
        }

        /// <summary>
        /// This is called when we receive the EQ_END_ZONE packet
        /// </summary>
        public virtual void EndZone()
        {
        }

        /// <summary>
        /// Similar/same as EndZone ?
        /// </summary>
        public virtual void Zoned()
        {
        }
    }
}
