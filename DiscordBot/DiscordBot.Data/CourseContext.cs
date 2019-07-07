using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace DiscordBot.Data
{
    public class CourseContext : DbContext
    {
        // Couldn't find a better way and idgaf to be honest XD
        [Obsolete]
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DiscordDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(builder =>
            {
                builder.Property(course => course.Id).IsRequired();

                builder.Property(course => course.Languages)
                    .HasConversion(
                        value => JsonConvert.SerializeObject(value, Formatting.None),
                        serializedValue => JsonConvert.DeserializeObject<Dictionary<Constants.Languages, Constants.Levels>>(serializedValue)
                    )
                    .IsRequired();
            });
        }
    }
}
