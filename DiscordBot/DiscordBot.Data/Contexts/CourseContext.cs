using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;

namespace DiscordBot.Data
{
    public class CourseContext : DbContext
    {
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
                builder.Property(course => course.Name).IsRequired();

                builder.Property(course => course.Teacher)
                    .HasConversion(
                    value => JsonConvert.SerializeObject(value, Formatting.None),
                    serializedValue => JsonConvert.DeserializeObject<Mentor>(serializedValue))
                    .IsRequired();

                builder.Property(course => course.Students)
                    .HasConversion(
                        value => JsonConvert.SerializeObject(value, Formatting.None),
                        serializedValue => JsonConvert.DeserializeObject<List<ulong>>(serializedValue)
                    )
                    .IsRequired();

                builder.Property(course => course.CourseDetails)
                    .HasConversion(
                        value => JsonConvert.SerializeObject(value, Formatting.None),
                        serializedValue => JsonConvert.DeserializeObject<Tuple<Constants.Languages, Constants.Levels>>(serializedValue)
                    )
                    .IsRequired();
            });
        }
    }
}
