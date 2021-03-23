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

                connection.StartAsync().Wait();

                SuccessToConnectToHub();

                await NotifyMemberName(connection);
            }
            catch
            {
                FailureToConnectToHub();
            }

            Console.ReadLine();
        }

        private static async Task NotifyWatchingMembers(HubConnection connection)
        {
            while (true)
            {
                await CallNotifyWatchingMembers(connection);

                Console.WriteLine("Do you want to see the watching members? <Y,N>");

                var canContinue = Console.ReadLine();

                if (!canContinue!.ToUpper().Equals("Y"))
                    break;

                ListenToUpdateWatchingMembers(connection);
            }
        }

        private static async Task NotifyMemberName(HubConnection connection)
        {
            while (true)
            {
                Console.WriteLine("Continue? <Y,N>");

                var canContinue = Console.ReadLine();

                if (!canContinue!.ToUpper().Equals("Y"))
                    break;

                Console.WriteLine("Introduce yourself?");

                Console.Write("Forename: ");
                var forename = Console.ReadLine();

                Console.Write("Surname: ");
                var surname = Console.ReadLine();


                await CallNotifyMemberName(connection, forename, surname);

                ListenToIntroduceHimself(connection);
            }
        }

        private static void ListenToUpdateWatchingMembers(HubConnection connection) =>
            connection.On<int>(HubEventHandlerConstant.WatchHubClientUpdate, Console.WriteLine);

        private static void ListenToIntroduceHimself(HubConnection connection) =>
            connection.On<string>(HubEventHandlerConstant.AccountHubClientIntroduce, Console.WriteLine);

        private static async Task CallNotifyWatchingMembers(HubConnection connection) =>
            await connection.InvokeAsync(HubEventHandlerConstant.WatchHubServerWatch);

        private static async Task CallNotifyMemberName(HubConnection connection, string forename, string surname) =>
            await connection.InvokeAsync(HubEventHandlerConstant.AccountHubServerJoinUser, forename, surname);

        private static void SuccessToConnectToHub() => Console.WriteLine("Successfully connnect to hub");
        private static void FailureToConnectToHub() => Console.WriteLine("Unforetunalty disconnect from hub");
    }
}
