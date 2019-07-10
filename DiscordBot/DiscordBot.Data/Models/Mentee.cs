using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Models
{
    public class Mentee : Programmer
    {

        public Mentee(ulong id) : base(id)
        {
            Languages = new Dictionary<Constants.Languages, Constants.Levels>();
        }
        
    }
}
