using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace MQ2DotNet.Utility
{
    /// <summary>
    /// Synchronization context that will run all continuations when DoEvents is called, intended for use with an event loop
    /// Not threadsafe, except for Post
    /// </summary>
    public class EventLoopContext : SynchronizationContext
    {
        private readonly ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>> _queue = new ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>>();

        /// <inheritdoc />
        public override void Post(SendOrPostCallback d, object state)
        {
            _queue.Enqueue(new KeyValuePair<SendOrPostCallback, object>(d, state));
        }

        /// <inheritdoc />
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Invoke all queued continuations
        /// </summary>
        /// <param name="setSyncContext">
        /// If true, continuations will be invoked on this synchronization context. If false, they will be invoked on SynchronizationContext.Current
        /// </param>
        public void DoEvents(bool setSyncContext)
        {
            void Action()
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

            if (setSyncContext)
                SetExecuteRestore(Action);
            else
                Action();
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

        /// <summary>
        /// Remove all queued continuations
        /// </summary>
        /// <returns></returns>
        public int RemoveAll()
        {
            var count = 0;

            while (_queue.TryDequeue(out var continuation))
                count++;

            return count;
        }
    }
}
