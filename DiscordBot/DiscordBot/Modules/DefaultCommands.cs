using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Models;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    public class DefaultCommands : CommandsBase
    {
        [Command("test")]
        public async Task Test([Remainder]int amount = 0)
        {
            await ReplyAsync($"Test is successful: {amount}");
        }


        [Command("Subscribe")]
        public async Task Subscribe([Remainder] string type)
        {
            Constants.UserTypes userType;
            try
            {
                userType = (Constants.UserTypes)Enum.Parse(typeof(Constants.UserTypes), type, true);
            }
            catch { return; }

            switch (userType)
            {
                case Constants.UserTypes.Mentor:
                    Mentor mentor = await MentorRepo.GetMentorAsync(Context.User.Id);
                    if (mentor != null)
                    {
                        await ReplyAsync($"You are already subscribed from the {type} role");
                        return;
                    }

                    mentor = new Mentor(Context.User.Id);
                    await MentorRepo.InsertMentorAsync(mentor);
                    break;
                case Constants.UserTypes.Mentee:
                    Mentee mentee = await MenteeRepo.GetMenteeAsync(Context.User.Id);

                    if (mentee != null)
                    {
                        await ReplyAsync($"You are already subscribed from the {type} role");
                        return;
                    }

                    mentee = new Mentee(Context.User.Id);
                    await MenteeRepo.InsertMenteeAsync(mentee);
                    break;
            }
            await ReplyAsync($"You have been successfully subscribed from the {type.ToLower()} role.");
        }

        [Command("Unsubscribe")]
        public async Task Unsubscribe([Remainder] string type)
        {
            Constants.UserTypes userType;
            try
            {
                userType = (Constants.UserTypes) Enum.Parse(typeof(Constants.UserTypes), type, true);
            }
            catch { return; }

            switch (userType)
            {
                case Constants.UserTypes.Mentor:
                    await MentorRepo.DeleteMentorAsync(Context.User.Id);
                    break;

                case Constants.UserTypes.Mentee:
                    await MenteeRepo.DeleteMenteeAsync(Context.User.Id);
                    break;
            }

            await ReplyAsync($"You have been successfully unsubscribed from the {type.ToLower()} role");
        }

        [Command("SendMsg")]
        [Alias("Send", "SendMessage")]
        public async Task SendMsg([Remainder] string arg)
        {
            string[] arguments = arg.Split(' ');
            if (arguments.Length < 2)
            {
                await ReplyAsync("No messsage detected. Message could not be sent.");
                return;
            }

            arguments[arguments.Length - 1] +=
                $"{Environment.NewLine}Reply usage: ``$SendMsg {Context.User.Id} [Message]``";

            ulong userId = 0;

            ulong.TryParse(arguments[0], out userId);
            if (userId == 0)
            {
                await ReplyAsync("This is not a valid userId!");
            }

            arguments[0] = $"{Context.User.Id} says: ";

            IUser user = Context.Client.GetUser(userId);
            var channel = await user.GetOrCreateDMChannelAsync();
            await channel.SendMessageAsync(string.Join(' ', arguments));
        }

        [Command("Userinfo")]
        [Alias("User", "Info")]
        public async Task UserInfo([Remainder] ulong userId)
        {
            var mentee = await MenteeRepo.GetMenteeAsync(userId);
            var mentor = await MentorRepo.GetMentorAsync(userId);

            if (mentee == null && mentor == null)
            {
                await ReplyAsync("User does not exist or did not unsubscribe from a mentor or mentee role yet.");
                return;
            }


            await Context.Channel.SendMessageAsync("", false,
                GetEmbed(Context.User.Username, Context.User.GetAvatarUrl(), mentee, mentor));
        }


        private static Embed GetEmbed(string name, string url, Mentee mentee, Mentor mentor)
        {
            EmbedBuilder embed = new EmbedBuilder();
            embed.WithAuthor(name, url);
            embed.WithTitle($"User Information {name}");
            embed.WithThumbnailUrl(url);
            StringBuilder sb = new StringBuilder();

            if (mentee != null)
            {
                sb.AppendLine("Mentee in:");
                foreach (var pair in mentee.Languages)
                {
                    sb.AppendLine($"Language: {pair.Key}, Level: {pair.Value}");
                }
            }

            if (mentor != null)
            {
                sb.AppendLine("Mentor in:");

                foreach (var pair in mentor.Languages)
                {
                    sb.AppendLine($"Language: {pair.Key}, Level: {pair.Value}");
                }
            }

            embed.WithDescription(sb.ToString());
            return embed.Build();
        }

        [Command("help")]
        public async Task GetHelp()
        {
            await ReplyAsync("$create course Language LevelOfExperienceRequired MaxStudents Description");
        }
    }
}
