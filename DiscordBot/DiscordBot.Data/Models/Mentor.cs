using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Models
{
    public class Mentor : IUser
    {
        public Mentor()
        {
            Languages = new Dictionary<Constants.Languages, Constants.Levels>();    
        }

        public int Id { get; set; }
        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

    }
}
