using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {

        [Command("test")]
        public async Task Test([Remainder]int amount=0)
        {
            await ReplyAsync("Test is successful: " + amount);
        }
    }
}
