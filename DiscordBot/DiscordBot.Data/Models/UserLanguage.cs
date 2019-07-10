namespace DiscordBot.Data.Models
{
    public class UserLanguage
    {
        public int UserLanguageId { get; set; }
        public ulong UserId { get; set; }
        public ProgrammingLanguages ProgrammingLanguages { get; set; }
        public UserLanguageRoles UserLanguageRole { get; set; }
        public CompetenceLevels CompetenceLevel { get; set; }

        // Navigation
        public User User { get; set; }
    }
}
