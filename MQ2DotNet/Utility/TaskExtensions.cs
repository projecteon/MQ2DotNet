using System;
using System.Threading;
using System.Threading.Tasks;

namespace MQ2DotNet.Utility
{
    // Based on https://stackoverflow.com/questions/4238345/asynchronously-wait-for-taskt-to-complete-with-timeout
    /// <summary>
    /// Extension methods for <see cref="Task"/> and <see cref="Task{TResult}"/>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Wait for the task to complete with a timeout. If the timeout elapses, the task is cancelled and a <see cref="TimeoutException"/> thrown
        /// </summary>
        /// <param name="task">The task to wait for</param>
        /// <param name="timeout">The time to timeout after</param>
        /// <param name="cts">A CancellationTokenSource that can be used to cancel <paramref name="task"/></param>
        /// <returns>The returned task will complete when either the supplied task completes, or the timeout elapses</returns>
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout, CancellationTokenSource cts)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    try
                    {
                        // Task timed out, cancel it and wait for it to join. An OperationCanceledException should be thrown, which we catch and throw TimeoutException instead
                        // If a different exception is thrown, it won't be caught
                        cts.Cancel();
                        await task;
                    }
                    catch (OperationCanceledException)
                    {
                        throw new TimeoutException("The operation has timed out.");
                    }
                }
            }
        }

        /// <summary>
        /// Wait for the task to complete with a timeout. If the timeout elapses, the task is cancelled and a <see cref="TimeoutException"/> thrown
        /// </summary>
        /// <param name="task">The task to wait for</param>
        /// <param name="timeout">The time to timeout after</param>
        /// <param name="cts">A CancellationTokenSource that can be used to cancel <paramref name="task"/></param>
        /// <returns>The returned task will complete when either the supplied task completes, or the timeout elapses</returns>
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout, CancellationTokenSource cts)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    try
                    {
                        // Task timed out, cancel it and wait for it to join. An OperationCanceledException should be thrown, which we catch and throw TimeoutException instead
                        // If a different exception is thrown, it won't be caught
                        cts.Cancel();
                        return await task;
                    }
                    catch (OperationCanceledException)
                    {
                        throw new TimeoutException("The operation has timed out.");
                    }
                }
            }
        }

        /// <summary>
        /// Wait for the task to complete with a timeout. If the timeout elapses, the task is cancelled and a <see cref="TimeoutException"/> thrown
        /// </summary>
        /// <param name="task">The task to wait for</param>
        /// <param name="timeout">The time to timeout after</param>
        /// <returns>The returned task will complete when either the supplied task completes, or the timeout elapses</returns>
        /// <remarks><paramref name="task"/> will not be cancelled or awaited if the timeout elapsed, so will be left dangling. Using <see cref="TimeoutAfter{TResult}(Task{TResult}, TimeSpan, CancellationTokenSource)"/> is preferred</remarks>
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
            }
        }

        /// <summary>
        /// Wait for the task to complete with a timeout. If the timeout elapses, the task is cancelled and a <see cref="TimeoutException"/> thrown
        /// </summary>
        /// <param name="task">The task to wait for</param>
        /// <param name="timeout">The time to timeout after</param>
        /// <returns>The returned task will complete when either the supplied task completes, or the timeout elapses</returns>
        /// <remarks><paramref name="task"/> will not be cancelled or awaited if the timeout elapsed, so will be left dangling. Using <see cref="TimeoutAfter(Task, TimeSpan, CancellationTokenSource)"/> is preferred</remarks>
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
            }
        }
    }
}