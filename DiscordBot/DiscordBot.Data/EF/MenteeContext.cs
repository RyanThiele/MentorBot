using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data
{
    public class MenteeContext : DbContext
    {
        public DbSet<Mentee> Mentees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DiscordDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Mentee>(builder =>
            //{
            //    builder.Property(mentee => mentee.Id).IsRequired();

            //    builder.Property(mentee => mentee.Languages)
            //        .HasConversion(
            //            value => JsonConvert.SerializeObject(value, Formatting.None),
            //            serializedValue => JsonConvert.DeserializeObject<Dictionary<Constants.Languages, Constants.Levels>>(serializedValue)
            //        )
            //        .IsRequired();
            //});
        }
    }
}
