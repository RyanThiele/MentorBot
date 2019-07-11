using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot
{
    static class Program
    {
        // add the client to the DI container.
        // after that we can inject the repositories into the client.
        

        public static readonly Client Client = new Client();

        static async Task Main(            string[] args) => await Client.RunAsync();


    }
}
