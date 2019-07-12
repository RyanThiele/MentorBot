using Discord.Commands;
using DiscordBot.Data;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    public class CommandsBase : ModuleBase<SocketCommandContext>
    {
        protected readonly IMenteeRepository _menteeRepository;
        protected readonly IMentorRepository _mentorRepository;
        protected readonly ICourseRepository _courseRepository;

        public CommandsBase(IMenteeRepository menteeRepository, IMentorRepository mentorRepository, ICourseRepository courseRepository)
        {
            _menteeRepository = menteeRepository;
            _mentorRepository = mentorRepository;
            _courseRepository = courseRepository;

        }
    }
}
