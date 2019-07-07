using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Domain.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {

        private IMenteeRepository menteeRepository = new MenteeRepository();
        [Command("test")]
        public async Task Test([Remainder]int amount=0)
        {
            await ReplyAsync($"Test is successful: {amount}");
        }
        /*
        [Command("Subscribe")]
        public async Task Subscribe([Remainder] string type)
        {
            Task task;
            switch (type.ToLower())
            {
                case "mentor":
                    if (IsMentor(Context.User.Id))
                    {
                        await ReplyAsync($"You are already subscribed as {type}");
                        return;
                    }

                    var mentor = new Mentor(Context.User.Id);
                    Program.Client.Mentors.Add(Context.User.Id, mentor);
                    Program.Client.Database.SaveMentor(mentor);
                    break;
                case "mentee":
                    if (IsMentee(Context.User.Id))
                    {
                        await ReplyAsync($"You are already subscribed as {type}");
                        return;
                    }

                    var mentee = new User(Context.User.Id);
                    Program.Client.Mentees.Add(Context.User.Id, mentee);
                    Program.Client.Database.SaveMentee(mentee);
                    break;
            }
            await Context.User.SendMessageAsync($"You have been successfully subscribed as {type}");
        }
        
        private static bool IsMentor(ulong id)
        {
            return Program.Client.Mentors.ContainsKey(id);
        }
        /*
        private static bool IsMentee(ulong id)
        {
            return Program.Client.Mentees.ContainsKey(id);
        }*/
    }
}
