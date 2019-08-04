using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MQ2DotNet.Script
{
    internal class ScriptAppDomain : AppDomainBase
    {
        private LoadedScriptAppDomain LoadedScript => (LoadedScriptAppDomain)LoadedAppDomain;

        private ScriptAppDomain(AppDomain appDomain, LoadedScriptAppDomain loadedScript)
            : base(appDomain, loadedScript)
        {
        }

        /// <summary>
        /// Loads a new .NET program from the specified assembly file, in a new app domain
        /// </summary>
        /// <param name="scriptFilePath"></param>
        /// <param name="appDomainName"></param>
        public static ScriptAppDomain Load(string appDomainName)
        {
            var scriptAppDomain = Load<ScriptAppDomain, LoadedScriptAppDomain>(
                appDomainName,
                (appDomain, loadedScript) => new ScriptAppDomain(appDomain, loadedScript),
                Enumerable.Empty<string>());
            
            return scriptAppDomain;
        }

        public void Start(string scriptFilePath, string[] args) => LoadedScript.Start(scriptFilePath, args);

        public void Cancel() => LoadedScript.Cancel();

        public TaskStatus Status => LoadedScript.Status;

        public bool Active => LoadedScript.Active;
    }
}