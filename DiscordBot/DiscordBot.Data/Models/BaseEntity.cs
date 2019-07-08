using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public ulong Id { get; set; }
    }
}
