using DiscordBot.Data.Commnds.Search;
using DiscordBot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static DiscordBot.Data.Constants;

namespace DiscordBot.Data.Commnds
{
    public class ProgrammerSearchCommand
    {
        private readonly IProgrammerSearch _search;

        public ProgrammerSearchCommand(IProgrammerSearch search)
        {
            _search = search;
        }

        public async Task<IEnumerable<Programmer>> Search(string query)
        {
            query = query.ToLower();

            string pattern = @"(language|level)\s+(\w+)$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(query);

            if (!match.Success)
                throw new InvalidOperationException($"Unknown search query: {query}");

            string searchType = match.Groups[1].Value;
            string searchValue = match.Groups[2].Value;

            if (searchType == "language" && Enum.TryParse(searchValue, true, out Languages language))
            {
                return await _search.SearchLanguage(language);
            }
            else if (searchType == "level" && Enum.TryParse(searchValue, true, out Levels level))
            {
                return await _search.SearchLevel(level);
            }
            else
            {
                throw new InvalidOperationException($"Invalid search query: {query}");
            }
        }
    }
}
