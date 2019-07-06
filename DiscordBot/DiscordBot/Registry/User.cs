using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Registry
{
    [Serializable]
    public class User
    {
        public ulong Id { get; }

        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

        public User(ulong id)
        {
            Id = id;
        }
    }
}
