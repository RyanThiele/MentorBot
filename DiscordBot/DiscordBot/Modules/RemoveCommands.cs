using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    [Group("Del")]
    [Alias("Remove")]
    public class RemoveCommands : CommandsBase
    {


        [Command("test")]
        public async Task Test()
        {
            await ReplyAsync("test");
        }

        [Command("language")]
        public async Task DeleteLanguage([Remainder] string arg)
        {
            if (arg.Split(' ').Length < MIN_ARG_COUNT_ADVANCED_CMDS) return;

            string type = arg.Split(' ')[0];
            string lang = arg.Split(' ')[1];

            Constants.UserTypes userType;
            Constants.Languages language;

            try
            {
                userType = (Constants.UserTypes)Enum.Parse(typeof(Constants.UserTypes), type, true);
                language = (Constants.Languages)Enum.Parse(typeof(Constants.Languages), lang, true);
            }
            catch
            {
                await ReplyAsync($"{type}, {lang} is not spelled correctly. Or both of them lol.");
                return;
            }

            ulong userId = Context.User.Id;

            if (userType == Constants.UserTypes.Mentor)
            {

            }
            else
            {

            }
        }
    }

}
