using System;
using System.IO;
using System.Threading.Tasks;

namespace MQ2DotNet.Program
{
    internal class ProgramAppDomain : AppDomainBase
    {
        private LoadedProgramAppDomain LoadedProgram => (LoadedProgramAppDomain) LoadedAppDomain;

        private ProgramAppDomain(AppDomain appDomain, LoadedProgramAppDomain loadedProgram)
            : base(appDomain, loadedProgram)
        {
        }

        /// <summary>
        /// Loads a new .NET program from the specified assembly file, in a new app domain
        /// </summary>
        /// <param name="assemblyFilePath"></param>
        /// <param name="appDomainName"></param>
        public static ProgramAppDomain Load(string assemblyFilePath, string appDomainName)
        {
            var programAppDomain = Load<ProgramAppDomain, LoadedProgramAppDomain>(
                appDomainName,
                (appDomain, loadedProgram) => new ProgramAppDomain(appDomain, loadedProgram),
                new[] { Path.GetDirectoryName(assemblyFilePath) },
                assemblyFilePath);
            
            return programAppDomain;
        }

        public void Start(string[] args) => LoadedProgram.Start(args);

        public void Cancel() => LoadedProgram.Cancel();

        public TaskStatus Status => LoadedProgram.Status;

        public Exception Exception => LoadedProgram.Exception;
    }
}