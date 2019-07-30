using JetBrains.Annotations;

namespace MQ2DotNet.Plugin
{
    /// <summary>
    /// Interface which a plugin must implement
    /// </summary>
    [PublicAPI]
    public interface IPlugin
    {
        /// <summary>
        /// Called once when the plugin is first loaded
        /// </summary>
        /// <remarks>
        /// If this method throws an exception, the plugin's AppDomain will be unloaded immediately without <see cref="ShutdownPlugin"/> being called
        /// </remarks>
        void InitializePlugin();

        /// <summary>
        /// Called once before the plugin is unloaded
        /// </summary>
        void ShutdownPlugin();

        /// <summary>
        /// Called once per frame
        /// </summary>
        void OnPulse();
    }
}
