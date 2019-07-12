using System.Collections.Generic;

namespace DiscordBot.Data.Ef
{
    public class User
    {
        public ulong UserId { get; set; }
        public Roles Role { get; set; }
        public virtual IList<UserLanguage> UserLanguages { get; set; }

    }
}
