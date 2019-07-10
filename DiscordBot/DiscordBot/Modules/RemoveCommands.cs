using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Models;
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
            if (arg.Split(' ').Length < 2) return;

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
                Mentor mentor = await MentorRepo.GetMentorAsync(userId);
                if (mentor == null)
                {
                    await ReplyAsync("You are not subscribed from the mentor role!");
                    return;
                }

                if (!mentor.Languages.ContainsKey(language))
                {
                    await ReplyAsync("You do not have this language in your arsenal yet!");
                    return;
                }

                mentor.Languages.Remove(language);
                await MentorRepo.UpdateMentorAsync(mentor);
                await ReplyAsync($"You have successfully removed {language} from you arsenal!");
            }
            else
            {
                Mentee mentee = await MenteeRepo.GetMenteeAsync(userId);
                if (mentee == null)
                {
                    await ReplyAsync("You are not subscribed from the mentee role!");
                    return;
                }

                if (!mentee.Languages.ContainsKey(language))
                {
                    await ReplyAsync("You do not have this language in your arsenal yet!");
                }

                mentee.Languages.Remove(language);
                await MenteeRepo.UpdateMenteeAsync(mentee);
                await ReplyAsync($"You have successfully removed {language} from you arsenal!");
            }
        }
    }

}
