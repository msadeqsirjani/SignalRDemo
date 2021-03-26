using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            System.Console.WriteLine("Background Changer App!");

            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5001/hubs/background")
                .WithAutomaticReconnect()
                .AddMessagePackProtocol()
                .Build();

            await connection.StartAsync();

            System.Console.WriteLine("[R]ed | [G]reen | [B]lue | E[x]it");

            connection.On<string>("ChangeBackgroundColor", OnChangeBackgroundColor);

            var keepGoing = true;
            do
            {
                ChangeConsoleBackgroundColor();
                var key = System.Console.ReadKey();
                System.Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        await connection.InvokeAsync("NotifyChangingBackgroundColor", "red");
                        break;
                    case ConsoleKey.G:
                        await connection.InvokeAsync("NotifyChangingBackgroundColor", "green");
                        break;
                    case ConsoleKey.B:
                        await connection.InvokeAsync("NotifyChangingBackgroundColor", "blue");
                        break;
                    case ConsoleKey.X:
                        keepGoing = false;
                        break;
                    default:
                        System.Console.WriteLine("No ...");
                        break;
                }
            } while (keepGoing);

            await connection.StopAsync();

            System.Console.ReadLine();
        }

        public static void OnChangeBackgroundColor(string color)
        {
            ChangeConsoleBackgroundColor(color);

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"Changed color to {color}");
        }

        private static void ChangeConsoleBackgroundColor(string color = "Black")
        {
            System.Console.BackgroundColor = color.ToUpper() switch
            {
                "RED" => ConsoleColor.Red,
                "GREEN" => ConsoleColor.Green,
                "BLUE" => ConsoleColor.Blue,
                _ => ConsoleColor.Black
            };
        }
    }
}
