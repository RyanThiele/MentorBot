using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Registry
{
    [Serializable]
    public abstract class User
    { 
        public Guid Id { get; }
        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

        public User(Guid id)
        {
            Id = id;
        }

        public abstract void Subscribe();
        public abstract void UnSubscribe();
    }
}
