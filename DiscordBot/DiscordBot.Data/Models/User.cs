using System.Collections.Generic;

namespace DiscordBot.Data.Models
{
    public class User
    {
        public User()
        {

        }

        public ulong UserId { get; set; }
        public UserTypes UserType { get; set; }
        public virtual IList<UserLanguage> UserLanguages { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
