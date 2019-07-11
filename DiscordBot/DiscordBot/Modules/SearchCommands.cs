using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.Data.Commnds;
using DiscordBot.Data.Commnds.Search;
using DiscordBot.Data.Models;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    [Group("Search")]
    public class SearchCommands : CommandsBase
    {
        private const int PAGE_LENGTH = 20;

        [Command("Mentors")]
        public async Task SearchMentors([Remainder] string arg = null)
        {
            if (arg == null)
            {
                IEnumerable<Programmer> list = await MentorRepo.GetMentorsSliceAsync(0, PAGE_LENGTH);
                int page = 1;
                int totalPages = (MentorRepo.GetCount() / 20) + 1;
                var embed = GetSearchEmbed($"Results Mentors", list, page, totalPages);
                await Context.Channel.SendMessageAsync("", false, embed);
                return;
            }

            string reply = await GetSearchReply(MentorRepo, arg);

            await ReplyAsync(reply);
        }

        [Command("Mentees")]
        [Alias("Students")]
        public async Task SearchMentees([Remainder] string arg = null)
        {
            if(arg == null)
            {
                IEnumerable<Programmer> list = await MenteeRepo.GetMenteesSliceAsync(0, 20);
                int page = 1;
                int totalPages = (MenteeRepo.GetCount() / 20) + 1;
                var embed = GetSearchEmbed($"Results Mentees", list, page, totalPages);
                await Context.Channel.SendMessageAsync("", false, embed);
                return;
            }

            string reply = await GetSearchReply(MenteeRepo, arg);

            await ReplyAsync(reply);
        }

        private async Task<string> GetSearchReply(IProgrammerSearch programmerSearch, string arg)
        {
            string reply = string.Empty;
            try
            {

                ProgrammerSearchCommand command = new ProgrammerSearchCommand(programmerSearch);
                IEnumerable<Programmer> results = await command.Search(arg);
                reply = string.Join(',', results.Select(r => $"{r.Id} {r.LanguagesToString()}"));
            }
            catch (Exception ex)
            {
                reply = ex.Message;
            }

            return reply;

        }

        private static Embed GetSearchEmbed(string header, IEnumerable<Programmer> results, int currentPage, int lastPage)
        {
            var builder = new EmbedBuilder();
            builder.WithTitle(header);

            var sb = new StringBuilder();

            foreach (Programmer user in results)
            {
                sb.AppendLine($"{user.Id}, {user.LanguagesToString()}");
            }

            builder.WithDescription(sb.ToString());
            builder.WithFooter($"Page {currentPage}/{lastPage}");

            return builder.Build();
        }

    }
}
