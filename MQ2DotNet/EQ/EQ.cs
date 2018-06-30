using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.EQ
{
    /// <summary>
    /// Static class through which all EQ data and methods are exposed
    /// </summary>
    public static class EQ
    {
        public static Spawns Spawns { get; } = new Spawns();
    }
}
