using System;

namespace MQ2DotNet
{
    public abstract class Plugin : MarshalByRefObject
    {
        public virtual void InitializePlugin()
        {
        }

        public virtual void ShutdownPlugin()
        {
        }

        public virtual void OnZoned()
        {
        }

        public virtual void OnCleanUI()
        {
        }

        public virtual void OnReloadUI()
        {
        }

        public virtual void OnDrawHUD()
        {
        }

        public virtual void SetGameState(uint GameState)
        {
        }

        public virtual void OnPulse()
        {
        }

        public virtual uint OnWriteChatColor(string Line, uint Color, uint Filter)
        {
            return 0;
        }

        public virtual uint OnIncomingChat(string Line, uint Color)
        {
            return 0;
        }

        public virtual void OnAddSpawn(IntPtr /*PSPAWN*/ pNewSpawn)
        {
        }

        public virtual void OnRemoveSpawn(IntPtr /*PSPAWN*/ pSpawn)
        {
        }

        public virtual void OnAddGroundItem(IntPtr /*PGROUNDITEM*/ pNewGroundItem)
        {
        }

        public virtual void OnRemoveGroundItem(IntPtr /*PGROUNDITEM*/ pGroundItem)
        {
        }

        public virtual void BeginZone()
        {
        }

        public virtual void EndZone()
        {
        }

        public virtual void Zoned()
        {
        }
    }
}
