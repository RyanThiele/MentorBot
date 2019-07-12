using Discord;
using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Ef;
using DiscordBot.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class DefaultCommands : ModuleBase<SocketCommandContext>
    {
        private readonly IUserRepository _userRepository;

        public DefaultCommands(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [Command("test")]
        public async Task Test([Remainder]int amount = 0)
        {
            await ReplyAsync($"Test is successful: {amount}");
        }


        [Command("Subscribe")]
        public async Task Subscribe([Remainder] string type)
        {
            Roles role;
            try
            {
                role = (Roles)Enum.Parse(typeof(Roles), type, true);
            }
            catch { return; }

            // get the user role.
            Roles existingRole = await _userRepository.GetUserRoleByUserIdAsync(Context.User.Id);


            switch (role)
            {
                case Roles.Mentor:
                    if (existingRole != 0)
                    {
                        await ReplyAsync($"You are already subscribed from the {type} role");
                        return;
                    }
                    break;
                case Roles.Mentee:
                    if (existingRole != 0)
                    {
                        await ReplyAsync($"You are already subscribed from the {type} role");
                        return;
                    }
                    break;

            }

            // if we get to here, all conditions have been met.
            User user = new User()
            {
                UserId = Context.User.Id,
                Role = Roles.Mentor
            };

            await _userRepository.AddUserAsync(user);
            await ReplyAsync($"You have been successfully subscribed from the {type.ToLower()} role.");
        }

        [Command("Unsubscribe")]
        public async Task Unsubscribe([Remainder] string type)
        {
            Roles role;
            try
            {
                role = (Roles)Enum.Parse(typeof(Roles), type, true);
            }
            catch { return; }

            await _userRepository.RemoveUserRoleAsync(Context.User.Id);
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
            User user = await _userRepository.GetUserByUserIdAsync(userId);

            if (user == null)
            {
                await ReplyAsync("User does not exist or did not unsubscribe from a mentor or mentee role yet.");
                return;
            }

            await Context.Channel.SendMessageAsync("", false,
                GetEmbed(Context.User.Username, Context.User.GetAvatarUrl(), user));
        }


        private static Embed GetEmbed(string name, string url, User user)
        {
            EmbedBuilder embed = new EmbedBuilder();
            embed.WithAuthor(name, url);
            embed.WithTitle($"User Information {name}");
            embed.WithThumbnailUrl(url);
            StringBuilder sb = new StringBuilder();

            IEnumerable<UserLanguage> mentrorUserLanguages = user.UserLanguages.Where(x => x.Role == Roles.Mentor);
            IEnumerable<UserLanguage> menteeUserLanguages = user.UserLanguages.Where(x => x.Role == Roles.Mentee);

            if (menteeUserLanguages != null && menteeUserLanguages.Count() > 0)
            {
                sb.AppendLine("Mentee in:");
                foreach (var userLanguage in user.UserLanguages)
                {
                    sb.AppendLine($"Language: {userLanguage.ProgrammingLanguage}, Level: {userLanguage.CompetenceLevel}");
                }
            }

            if (mentrorUserLanguages != null && menteeUserLanguages.Count() > 0)
            {
                sb.AppendLine("Mentor in:");

                foreach (var userLanguage in user.UserLanguages)
                {
                    sb.AppendLine($"Language: {userLanguage.ProgrammingLanguage}, Level: {userLanguage.CompetenceLevel}");
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
