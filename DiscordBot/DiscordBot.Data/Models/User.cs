using System.Collections.Generic;

namespace DiscordBot.Data.Models
{
    public class User
    {
        public User()
        {

        }

        public ulong UserId { get; set; }
        public virtual IList<UserLanguages> UserLanguages { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
