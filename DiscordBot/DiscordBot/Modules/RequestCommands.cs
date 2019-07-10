using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    [Group("Request")]
    public class RequestCommands : ModuleBase<SocketCommandContext>
    {
        [Command("Course")]
        public async Task RequestCourse([Remainder] string arg)
        {
            string[] arguments = arg.Split(' ');

            //if(arguments.Length < )
        }

    }
}
