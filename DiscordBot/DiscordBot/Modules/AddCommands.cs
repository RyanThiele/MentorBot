using DiscordBot.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Data;

namespace DiscordBot.Modules
{
    [Group("Add")]
    public class AddCommands : CommandsBase
    {
        [Command("test")]
        public async Task Test([Remainder]int amount = 0)
        {
            await ReplyAsync($"Test is successful: {amount}");
        }

        [Command("Language")]
        public async Task AddLanguage([Remainder] string arg)
        {
            if (arg.Split(' ').Length < 3) return;

            string type = arg.Split(' ')[0];
            string lang = arg.Split(' ')[1];
            string xp = arg.Split(' ')[2];
            
            Constants.UserTypes userType;
            Constants.Languages language;
            Constants.Levels xpLevel;

            try
            {
                userType = (Constants.UserTypes) Enum.Parse(typeof(Constants.UserTypes), type, true);
                language = (Constants.Languages) Enum.Parse(typeof(Constants.Languages), lang, true);
                xpLevel = (Constants.Levels) Enum.Parse(typeof(Constants.Levels), xp, true);
            }
            catch
            {
                await ReplyAsync($"{type}, {lang} or {xp} is not spelled correctly. Or all of them lol.");
                return;
            }

            if(await SetLanguage(userType, language, xpLevel))
                await ReplyAsync($"You have successfully added {language} to your {userType} languages. ");
        }

        private async Task<bool> SetLanguage(Constants.UserTypes type, Constants.Languages lang, Constants.Levels xp)
        {
            ulong userId = Context.User.Id;

            if (type == Constants.UserTypes.Mentor)
            {
                var mentor = await MentorRepo.GetMentorAsync(userId);

                if (mentor == null)
                {
                    await ReplyAsync("You are not a mentor yet. Type ``$Subscribe mentor`` to subscribe from the mentor role.");
                    return false;
                }
                if(mentor.Languages.ContainsKey(lang))
                {
                    await ReplyAsync("You have already added this language to your arsenal. " +
                                     "Please use the $set command to change its experience level or $del to delete it.");
                    return false;
                }

                mentor.Languages.Add(lang, xp);
                await MentorRepo.UpdateMentorAsync(mentor);
            }
            else
            {
                var mentee = await MenteeRepo.GetMenteeAsync(userId);

                if (mentee == null)
                {
                    await ReplyAsync("You are not a mentee yet. Type ``$Subscribe mentee`` to subscribe from the mentee role.");
                }
                else if (mentee.Languages.ContainsKey(lang))
                {
                    await ReplyAsync("You have already added this language to your arsenal. " +
                                     "Please use the $set command to change its experience level or $del to delete it.");
                    return false;
                }

                mentee.Languages.Add(lang, xp);
                await MenteeRepo.UpdateMenteeAsync(mentee);
                await MenteeRepo.SaveAsync();
            }

            return true;
        }
    }
}
