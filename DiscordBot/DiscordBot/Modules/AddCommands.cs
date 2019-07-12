using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Ef;
using DiscordBot.Data.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    [Group("Add")]
    [Alias("Create")]
    public class AddCommands : ModuleBase<SocketCommandContext>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public AddCommands(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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

            Roles userLanguageRole;
            ProgrammingLanguages programmingLanguage;
            CompetenceLevels competenceLevel;
            ulong userId = Context.User.Id;

            // do we need a try/catch here? we can use try parse.
            try
            {
                userLanguageRole = (Roles)Enum.Parse(typeof(Roles), type, true);
                programmingLanguage = (ProgrammingLanguages)Enum.Parse(typeof(ProgrammingLanguages), lang, true);
                competenceLevel = (CompetenceLevels)Enum.Parse(typeof(CompetenceLevels), xp, true);

            }
            catch
            {
                await ReplyAsync($"{type}, {lang} or {xp} is not spelled correctly. Or all of them lol.");
                return;
            }

            // get the roles for the user (if they exist)
            Roles role = await _userRepository.GetUserRoleByUserIdAsync(userId);
            if (role != 0)
            {
                await ReplyAsync("You are not a mentor yet. Type ``$Subscribe mentor`` to subscribe from the mentor role.");
                return;
            }

            // we have our variables 
            if (userLanguageRole == Roles.Mentor)
            {
                // user is requesting a mentor spot on a language. Do they have a mentor user role?
                if (role != Roles.Mentor)
                {
                    await ReplyAsync("You are not a mentor yet. Type ``$Subscribe mentor`` to subscribe from the mentor role.");
                    return;
                }
            }



            // get the user's roles by language
            // bool isUserInLanguageRole = await _userRepository.GetIsUserInUserLanguageRoleByProgramingLanguagesAsync(userId, userLanguageRole, programmingLanguage);
            Roles existingUserLanguageRole = await _userRepository.GetUserLanguageRoleByUserIdAndProgrammingLanguageAsync(userId, programmingLanguage);

            if (existingUserLanguageRole == userLanguageRole)
            {
                await ReplyAsync($"You have already added this language to your arsenal. It is currently set to {existingUserLanguageRole}." +
                    $" Please use the *$set* command to change its experience level or *$del* to delete it.");

                return;
            }


            // add the language role to the user.
            try
            {
                await _userRepository.SetProgrammingLanguageAndUserLanguageRoleAsync(userId, programmingLanguage, userLanguageRole);
                await ReplyAsync($"You have successfully added {programmingLanguage} to your {userLanguageRole} languages. ");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"There was an error processing your request: {ex.Message}.");
            }


        }



        [Command("Course")]
        public async Task AddCourse([Remainder] string arg)
        {
            string[] arguments = arg.Split(' ');

            if (arguments.Length < 4)
            {
                await ReplyAsync("Invalid argument count (at least 4)! Usage: " +
                                 "``$create course [Language] [LevelOfExperienceRequired] [MaxStudents] [Description]``");
                return;
            }


            ProgrammingLanguages language;
            CompetenceLevels level;
            int maxStudents;
            try
            {
                language = (ProgrammingLanguages)Enum.Parse(typeof(ProgrammingLanguages), arguments[0], true);
                level = (CompetenceLevels)Enum.Parse(typeof(CompetenceLevels), arguments[1], true);
                maxStudents = Int32.Parse(arguments[2]);
            }
            catch
            {
                await ReplyAsync("Invalid language or level of experience! Usage: " +
                                 "``$create course [Language] [LevelOfExperienceRequired] [MaxStudents] [Description]``");
                return;
            }

            string description = string.Join(' ', arguments.Skip(3));
            Course course = new Course()
            {
                MaximumEnrolled = maxStudents,
                CompetenceLevels = level,
                ProgrammingLanguage = language,
                Description = description,
            };

            try
            {
                await _courseRepository.AddCourseAsync(course);
                await ReplyAsync($"You have successfully added the course with ID {course.Id}");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"There was an error processing your request: {ex.Message}.");
            }


        }
    }
}
