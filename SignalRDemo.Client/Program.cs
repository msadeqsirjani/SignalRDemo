using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using SignalRDemo.Client.Logger;
using SignalRDemo.Client.RetryPolicy;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var connection = new HubConnectionBuilder()
                    .WithUrl(new Uri("http://localhost:5000/hubs/watch"),
                        HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents)
                    .WithAutomaticReconnect(new CactusRetryPolicy())
                    .ConfigureLogging(logging => { logging.AddProvider(new ConsoleLoggerProvider()); })
                    .Build();

                connection.Reconnecting += exception =>
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;

                    return Task.CompletedTask;
                };

                connection.Reconnected += s =>
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                    return Task.CompletedTask;
                };

                connection.Closed += exception =>
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;

                    return Task.CompletedTask;
                };

                connection.StartAsync().Wait();

                SuccessToConnectToHub();

                await NotifyWatchingMembers(connection);
            }
            catch
            {
                FailureToConnectToHub();
            }

            Console.ReadLine();
        }

        private static async Task NotifyWatchingMembers(HubConnection connection)
        {
            ListenToUpdateWatchingMembers(connection);

            while (true)
            {
                await CallNotifyWatchingMembers(connection);
            }
        }
        private static void ListenToUpdateWatchingMembers(HubConnection connection) =>
            connection.On<int>(HubEventHandlerConstant.WatchHubClientUpdate, Console.WriteLine);
        private static async Task CallNotifyWatchingMembers(HubConnection connection) =>
            await connection.InvokeAsync(HubEventHandlerConstant.WatchHubServerWatch);
        private static void SuccessToConnectToHub() => Console.WriteLine("Successfully connect to hub");
        private static void FailureToConnectToHub() => Console.WriteLine("Unfortunately disconnect from hub");
    }
}
