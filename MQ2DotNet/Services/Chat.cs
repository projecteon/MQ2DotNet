using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQ2DotNet.Utility;

namespace MQ2DotNet.Services
{
    /// <summary>
    /// Contains utility methods and properties relating to ingame chat (messages in a chat window, from EQ or MQ2)
    /// </summary>
    [PublicAPI]
    public class Chat
    {
        private readonly Events _events;

        internal Chat(Events events)
        {
            _events = events;
        }

        /// <summary>
        /// Wait indefinitely for a line of chat from either EQ or MQ2 matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WaitFor(Predicate<string> predicate, CancellationToken cancellationToken)
        {
            await WaitForInternal(predicate, cancellationToken, handler => _events.OnChat += handler, handler => _events.OnChat -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from either EQ or MQ2 matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitFor(Predicate<string> predicate, int timeout, CancellationToken cancellationToken)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), cancellationToken, handler => _events.OnChat += handler, handler => _events.OnChat -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from either EQ or MQ2 matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitFor(Predicate<string> predicate, int timeout)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), CancellationToken.None, handler => _events.OnChat += handler, handler => _events.OnChat -= handler);
        }

        /// <summary>
        /// Wait indefinitely for a line of chat from EQ (and not MQ2) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WaitForEQ(Predicate<string> predicate, CancellationToken cancellationToken)
        {
            await WaitForInternal(predicate, cancellationToken, handler => _events.OnChatEQ += handler, handler => _events.OnChatEQ -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from EQ (and not MQ2) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitForEQ(Predicate<string> predicate, int timeout, CancellationToken cancellationToken)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), cancellationToken, handler => _events.OnChatEQ += handler, handler => _events.OnChatEQ -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from EQ (and not MQ2) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitForEQ(Predicate<string> predicate, int timeout)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), CancellationToken.None, handler => _events.OnChatEQ += handler, handler => _events.OnChatEQ -= handler);
        }

        /// <summary>
        /// Wait indefinitely for a line of chat from MQ2 (and not EQ) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WaitForMQ2(Predicate<string> predicate, CancellationToken cancellationToken)
        {
            await WaitForInternal(predicate, cancellationToken, handler => _events.OnChatMQ2 += handler, handler => _events.OnChatMQ2 -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from MQ2 (and not EQ) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitForMQ2(Predicate<string> predicate, int timeout, CancellationToken cancellationToken)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), cancellationToken, handler => _events.OnChatMQ2 += handler, handler => _events.OnChatMQ2 -= handler);
        }

        /// <summary>
        /// Wait for up to <paramref name="timeout"/> milliseconds for a line of chat from MQ2 (and not EQ) matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Function that returns true if a line matches</param>
        /// <param name="timeout">Number of milliseconds to wait before timing out</param>
        /// <returns>Returns true if a match was found or false if the timeout elapsed</returns>
        /// <exception cref="TaskCanceledException" />
        public async Task<bool> WaitForMQ2(Predicate<string> predicate, int timeout)
        {
            return await WaitForInternal(predicate, TimeSpan.FromMilliseconds(timeout), CancellationToken.None, handler => _events.OnChatMQ2 += handler, handler => _events.OnChatMQ2 -= handler);
        }

        private async Task WaitForInternal(Predicate<string> predicate, CancellationToken cancellationToken, Action<EventHandler<string>> subscribe, Action<EventHandler<string>> unsubscribe)
        {
            // Since all the WaitFor* methods are the same, just using a different event, this reduces the need for a lot of boilerplate code
            var found = false;
            void OnChat(object _, string line) { if (predicate(line)) found = true; }
            subscribe(OnChat);
            try
            {
                while (!found)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Yield();
                }
            }
            finally
            {
                unsubscribe(OnChat);
            }
        }

        private async Task<bool> WaitForInternal(Predicate<string> predicate, TimeSpan timeout,
            CancellationToken cancellationToken, Action<EventHandler<string>> subscribe,
            Action<EventHandler<string>> unsubscribe)
        {
            try
            {
                // Create a token to cancel the indefinite WaitFor if the timeout elapses
                var timeoutCts = new CancellationTokenSource();
                // The indefinite WaitFor needs to be cancelled if either the timeout elapses, or if this task itself is cancelled
                var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);
                await WaitForInternal(predicate, cts.Token, subscribe, unsubscribe).TimeoutAfter(timeout, timeoutCts);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
    }
}