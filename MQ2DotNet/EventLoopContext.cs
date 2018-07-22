using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;

namespace MQ2DotNet
{
    /// <summary>
    /// Synchronization context that will run all continuations when DoEvents is called, intended for use with an event loop
    /// Not threadsafe, except for Post
    /// </summary>
    public class EventLoopContext : SynchronizationContext
    {
        private readonly ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>> _queue = new ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>>();

        public override void Post(SendOrPostCallback d, object state)
        {
            _queue.Enqueue(new KeyValuePair<SendOrPostCallback, object>(d, state));
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException();
        }

        public void DoEvents()
        {
            // Any continuations currently in the queue get removed and inserted into a list
            var continuations = new List<KeyValuePair<SendOrPostCallback, object>>();
            while (_queue.TryDequeue(out var continuation))
                continuations.Add(continuation);

            // Now all the continuations in the list get executed
            // Any further continuations posted as a result of one of the existing ones will go in the queue to get executed next iteration of the loop
            foreach (var continuation in continuations)
                continuation.Key(continuation.Value);
        }

        /// <summary>
        /// Helper method to invoke an action on the sync context, restoring the original context after completion or on exception
        /// </summary>
        /// <param name="action"></param>
        public void SetExecuteRestore(Action action)
        {
            var oldContext = Current;
            try
            {
                SetSynchronizationContext(this);
                action();
            }
            finally
            {
                SetSynchronizationContext(oldContext);
            }
        }

        /// <summary>
        /// Helper method to invoke an action on the sync context, restoring the original context after completion or on exception
        /// </summary>
        public T SetExecuteRestore<T>(Func<T> func)
        {
            var oldContext = Current;
            try
            {
                SetSynchronizationContext(this);
                return func();
            }
            finally
            {
                SetSynchronizationContext(oldContext);
            }
        }

        public static EventLoopContext Instance { get; } = new EventLoopContext();

        public int RemoveAll()
        {
            var count = 0;

            while (_queue.TryDequeue(out var continuation))
                count++;

            return count;
        }
    }
}
