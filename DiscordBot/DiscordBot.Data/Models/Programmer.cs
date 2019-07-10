using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordBot.Data.Models
{
    public class Programmer
    {

        public Programmer(ulong id)
        {
            Id = id;
        }
        public ulong Id { get; set; }
        public string LanguagesToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var keyValuePair in Languages)
            {
                sb.Append($" [{keyValuePair.Key}, {keyValuePair.Value}]");
            }

            return sb.ToString();
        }

        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

        public override string ToString()
        {
            return "# User: " + JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
