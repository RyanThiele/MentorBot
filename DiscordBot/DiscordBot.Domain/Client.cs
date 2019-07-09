using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Domain
{
    public class Client
    {
        public DiscordSocketClient SocketClient { get; }

        private CommandService _commands;
        private IServiceProvider _services;

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
                .BuildServiceProvider();

            SocketClient.Log += Log;
            await RegisterCommandsAsync();
            await SocketClient.LoginAsync(Discord.TokenType.Bot, "" );
            await SocketClient.StartAsync();

            while (true) Console.ReadKey();
        }
        
        public async Task RegisterCommandsAsync()
        {
            SocketClient.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;

            if (msg is null || msg.Author.IsBot)
                return;

            int argPos = 0;

            var context = new SocketCommandContext(SocketClient, msg);
            var result = await _commands.ExecuteAsync(context, argPos, _services);

            if (!result.IsSuccess)
                return;
            
            var options = new RequestOptions { RetryMode = RetryMode.AlwaysRetry };
            await msg.DeleteAsync(options);
            
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}
