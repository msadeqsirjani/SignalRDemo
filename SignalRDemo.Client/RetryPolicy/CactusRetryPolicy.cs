using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRDemo.Client.RetryPolicy
{
    public class CactusRetryPolicy : IRetryPolicy
    {
        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            Console.WriteLine($"Retry: {retryContext.RetryReason}");

            if (retryContext.PreviousRetryCount == 10)
                return null;

            var nextRetry = retryContext.PreviousRetryCount == 0 ? 1000 : retryContext.PreviousRetryCount * 1000;

            Console.WriteLine($"Retry in {nextRetry} milliseconds");

            return nextRetry.Milliseconds();
        }
    }
}
