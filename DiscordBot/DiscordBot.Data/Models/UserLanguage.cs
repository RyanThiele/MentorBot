namespace DiscordBot.Data.Models
{
    public class UserLanguage
    {
        public int UserLanguageId { get; set; }
        public ulong UserId { get; set; }
        public Languages Language { get; set; }
        public Levels Level { get; set; }

        // Navigaiton
        public User User { get; set; }
    }
}
