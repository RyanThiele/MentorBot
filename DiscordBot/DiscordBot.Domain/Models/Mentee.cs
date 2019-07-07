﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Domain.Models
{
    public class Mentee : IUser
    {

        public Mentee()
        {
            Languages = new Dictionary<Constants.Languages, Constants.Levels>();
        }

        public int Id { get; set; }
        public Dictionary<Constants.Languages, Constants.Levels> Languages { get; set; }

        public override string ToString()
        {
            return "# User: " + JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
