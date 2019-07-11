using DiscordBot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiscordBot.Data.Constants;

namespace DiscordBot.Data.Commnds.Search
{
    public interface IProgrammerSearch
    {
        Task<IEnumerable<Programmer>> SearchLanguage(Languages language);
        Task<IEnumerable<Programmer>> SearchLevel(Levels level);
    }
}
