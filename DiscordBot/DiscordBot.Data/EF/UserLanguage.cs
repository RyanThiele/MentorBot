namespace DiscordBot.Data.Ef
{
    public class UserLanguage
    {
        public int UserLanguageId { get; set; }
        public ulong UserId { get; set; }
        public ProgrammingLanguages ProgrammingLanguage { get; set; }
        public Roles Role { get; set; }
        public CompetenceLevels CompetenceLevel { get; set; }

        // Navigation
        public User User { get; set; }
    }
}
