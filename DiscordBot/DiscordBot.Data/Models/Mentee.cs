using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Models
{
    public class Mentee : BaseEntity, IUser
    {

        public Mentee(ulong id) : base(id)
        {
            Languages = new Dictionary<Constants.Languages, Constants.Levels>();
        }
        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

        public override string ToString()
        {
            return "# User: " + JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
