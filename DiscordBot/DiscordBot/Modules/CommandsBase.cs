using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    public class CommandsBase : ModuleBase<SocketCommandContext>
    {
        protected readonly IMenteeRepository MenteeRepo = new MenteeRepository();
        protected readonly IMentorRepository MentorRepo = new MentorRepository();
        protected readonly ICourseRepository CourseRepo = new CourseRepository();
    }
}
