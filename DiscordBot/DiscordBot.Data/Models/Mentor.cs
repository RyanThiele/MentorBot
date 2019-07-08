﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiscordBot.Data.Models
{
    public class Mentor : BaseEntity, IUser
    {
        public Mentor()
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
