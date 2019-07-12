using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    [Group("Del")]
    [Alias("Remove")]
    public class RemoveCommands : ModuleBase<SocketCommandContext>
    {
        private readonly IUserRepository _userRepository;

        public RemoveCommands(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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

            Roles role;
            ProgrammingLanguages programmingLanguage;

            try
            {
                role = (Roles)Enum.Parse(typeof(Roles), type, true);
                programmingLanguage = (ProgrammingLanguages)Enum.Parse(typeof(ProgrammingLanguages), lang, true);
            }
            catch
            {
                await ReplyAsync($"{type}, {lang} is not spelled correctly. Or both of them lol.");
                return;
            }

            ulong userId = Context.User.Id;

            Roles? existingRole = await _userRepository.GetUserRoleByUserIdAsync(userId);
            if (!existingRole.HasValue)
            {
                await ReplyAsync("You are not subscribed to the mentor role!");
                return;
            }

            ProgrammingLanguages? existingProgrammingLanguage = await _userRepository.GetUserProgrammingLanguageByUserIdAndProgrammingLanguageAsync(userId, programmingLanguage);
            if (!existingProgrammingLanguage.HasValue)
            {
                await ReplyAsync("You do not have this language in your arsenal yet!");
                return;
            }

            // remove the language from the user
            try
            {
                await _userRepository.RemoveUserLanguageAsync(userId, programmingLanguage);
                await ReplyAsync($"You have successfully removed {programmingLanguage} from you arsenal!");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"There was an error processing your request: {ex.Message}.");
            }

        }
    }

}
