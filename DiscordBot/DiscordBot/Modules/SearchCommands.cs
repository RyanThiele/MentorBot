using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    [Group("Search")]
    public class SearchCommands : ModuleBase<SocketCommandContext>
    {
        private const int PAGE_LENGTH = 20;

        [Command("Mentors")]
        public async Task SearchMentors([Remainder] string arg = null)
        {
            //if (arg == null)
            //{
            //    IList<Programmer> list = MentorRepo.GetMentors(0, PAGE_LENGTH);
            //    int page = 1;
            //    int totalPages = (MentorRepo.GetCount() / 20) + 1;
            //    var embed = GetSearchEmbed($"Results Mentors", list, page, totalPages);
            //    await Context.Channel.SendMessageAsync("", false, embed);
            //    return;
            //}

            string[] arguments = arg.Split(' ');

            switch (arguments.Length)
            {
                case 1:

                    break;
                case 2:
                    break;
                default:
                    await ReplyAsync("Dude, way too many arguments. I don't know that sheeet.");
                    break;
            }


        }

        [Command("Mentees")]
        [Alias("Students")]
        public async Task SearchMentees([Remainder] string arg = null)
        {
            //if(arg == null)
            //{
            //    IList<Programmer> list = MenteeRepo.GetMentees(0, 20);
            //    int page = 1;
            //    int totalPages = (MenteeRepo.GetCount() / 20) + 1;
            //    var embed = GetSearchEmbed($"Results Mentees", list, page, totalPages);
            //    await Context.Channel.SendMessageAsync("", false, embed);
            //    return;
            //}
        }

        //private static Embed GetSearchEmbed(string header, IList<Programmer> results, int currentPage, int lastPage)
        //{
        //    var builder = new EmbedBuilder();
        //    builder.WithTitle(header);

        //    var sb = new StringBuilder();

        //    foreach (Programmer user in results)
        //    {
        //        sb.AppendLine($"{user.Id}, {user.LanguagesToString()}");
        //    }

        //    builder.WithDescription(sb.ToString());
        //    builder.WithFooter($"Page {currentPage}/{lastPage}");

        //    return builder.Build();
        //}

    }
}
