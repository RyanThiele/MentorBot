using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiscordBot.Data.Models
{
    public class Mentor : Programmer
    {
        public Mentor(ulong id) : base(id)
        {
            Languages = new Dictionary<Constants.Languages, Constants.Levels>();    
        }
        
    }
}
