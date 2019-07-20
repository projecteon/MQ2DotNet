using System;
using System.Threading.Tasks;

namespace MQ2DotNet
{
    internal abstract class Program : MarshalByRefObject
    {
        public virtual void Start(string[] args)
        {
        }

        public virtual void Stop()
        {
        }

        // Returns true if still running
        public virtual TaskStatus OnPulse()
        {
            return TaskStatus.Faulted;
        }
    }
}
