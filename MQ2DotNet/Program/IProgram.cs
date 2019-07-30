using System.Threading.Tasks;

namespace MQ2DotNet.Program
{
    /// <summary>
    /// Interface which a program must implement
    /// </summary>
    public interface IProgram
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="token"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task Main(System.Threading.CancellationToken token, string[] args);
    }
}
