using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data.Contexts
{
    /// <summary>
    /// An overall context to deal with SqlServer database access
    /// </summary>
    public class MentorBotDbContext : DbContext
    {
        private readonly string _connnectionString;

        public MentorBotDbContext(string connectionString)
        {
            _connnectionString = connectionString;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Mentee> Mentees { get; set; }
    }
}
