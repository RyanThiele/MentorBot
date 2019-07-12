using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Client
    {
        public DiscordSocketClient SocketClient { get; }

        private CommandService _commands;
        private IServiceProvider _services;
        private const string TOKEN = "NTgzNjM4OTk0ODQ4NTc5NjM3.XO_Sdg.QmhxjqUZthztos6oWi2dWNsJORg";

        public Client()
        {
            SocketClient = new DiscordSocketClient();
        }

        public async Task RunAsync()
        {
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(SocketClient)
                .AddSingleton(_commands)
                .AddTransient<DiscordBot.Data.Ef.ApplicationDbContext>()
                .AddSingleton<IUserRepository, UserRepository>()
                .BuildServiceProvider();

            SocketClient.Log += Log;
            await RegisterCommandsAsync();
            await SocketClient.LoginAsync(Discord.TokenType.Bot, TOKEN);
            await SocketClient.StartAsync();

            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            SocketClient.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            int argPos = 0;

            if (msg is null || msg.Author.IsBot || !msg.HasCharPrefix('$', ref argPos))
                return;

            var context = new SocketCommandContext(SocketClient, msg);
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync($"Command was not successful: {result.ErrorReason}");
                return;
            }
            var options = new RequestOptions { RetryMode = RetryMode.AlwaysRetry };
            //await msg.DeleteAsync(options);

        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}
