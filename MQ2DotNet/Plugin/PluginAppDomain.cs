using System;
using System.IO;

namespace MQ2DotNet.Plugin
{
    internal class PluginAppDomain : AppDomainBase
    {
        private PluginAppDomain(AppDomain appDomain, LoadedPluginAppDomain loadedPlugin)
            : base(appDomain, loadedPlugin)
        {
        }

        /// <summary>
        /// Loads a new .NET plugin from the specified assembly file, in a new app domain
        /// </summary>
        /// <param name="assemblyFilePath"></param>
        /// <param name="appDomainName"></param>
        public static PluginAppDomain Load(string assemblyFilePath, string appDomainName)
        {
            var pluginAppDomain = Load<PluginAppDomain, LoadedPluginAppDomain>(
                appDomainName,
                (appDomain, loadedPlugin) => new PluginAppDomain(appDomain, loadedPlugin),
                new[] { Path.GetDirectoryName(assemblyFilePath) },
                assemblyFilePath);
            
            return pluginAppDomain;
        }
    }
}