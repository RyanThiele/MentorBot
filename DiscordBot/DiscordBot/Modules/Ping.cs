using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.Data.Models;
using DiscordBot.Data.Repositories;

namespace DiscordBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {

        private readonly IMenteeRepository _menteeRepo = new MenteeRepository();
        private readonly IMentorRepository _mentorRepo = new MentorRepository();
        private readonly ICourseRepository _courseRepo = new CourseRepository();

        [Command("test")]
        public async Task Test([Remainder]int amount=0)
        {
            await ReplyAsync($"Test is successful: {amount}");
        }


        [Command("Subscribe")]
        public async Task Subscribe([Remainder] string type)
        {
            Task task;
            if (type.ToLower() == "mentor")
            {
                Mentor mentor = _mentorRepo.GetMentor(Context.User.Id);
                if (mentor != null)
                {
                    await ReplyAsync($"You are already subscribed as {type}");
                    return;
                }

                mentor = new Mentor(Context.User.Id);
                _mentorRepo.InsertMentor(mentor);
            }
            else if (type.ToLower() == "mentee")
            {
                Mentee mentee = _menteeRepo.GetMentee(Context.User.Id);

                if (mentee != null)
                {
                    await ReplyAsync($"You are already subscribed as {type}");
                    return;
                }

                mentee = new Mentee(Context.User.Id);
                _menteeRepo.InsertMentee(mentee);
            }

            await Context.User.SendMessageAsync($"You have been successfully subscribed as {type.ToLower()}");
        }

        [Command("Unsubscribe")]
        public async Task Unsubscribe([Remainder] string type)
        {
            Task task;
            switch (type.ToLower())
            {
                case "mentor":
                    Mentor mentor = _mentorRepo.GetMentor(Context.User.Id);
                    if (mentor is null)
                    {
                        await ReplyAsync($"You are not subscribed as {type}");
                        return;
                    }

                    mentor = new Mentor(Context.User.Id);
                    _mentorRepo.InsertMentor(mentor);
                    break;

                case "mentee":
                    Mentee mentee = _menteeRepo.GetMentee(Context.User.Id);
                    if (mentee != null)
                    {
                        await ReplyAsync($"You are already subscribed as {type}");
                        return;
                    }

                    mentee = new Mentee(Context.User.Id);
                    _menteeRepo.InsertMentee(mentee);
                    break;
            }
            await Context.User.SendMessageAsync($"You have been successfully subscribed as {type.ToLower()}");
        }

        /*
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
