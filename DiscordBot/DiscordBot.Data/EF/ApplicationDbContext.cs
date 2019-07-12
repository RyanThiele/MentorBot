using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data.Ef
{
    /// <summary>
    /// An overall context to deal with SqlServer database access
    /// </summary>
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _connnectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = DiscordDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(string connectionString)
        {
            _connnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
    }
}
