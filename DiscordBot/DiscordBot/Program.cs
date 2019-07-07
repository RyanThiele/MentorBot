using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot.Domain;

namespace DiscordBot
{
    static class Program
    {

        public static readonly Client Client = new Client();

        static async Task Main(string[] args) => await Client.RunAsync();
    }
}
