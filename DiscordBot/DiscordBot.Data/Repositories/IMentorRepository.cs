using System;
using System.Collections.Generic;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMentorRepository : IDisposable
    {
        IEnumerable<Mentor> GetMentors();
        Mentor GetMentor(ulong id);
        void InsertMentor(Mentor mentor);
        void DeleteMentor(ulong id);
        void UpdateMentor(Mentor mentor);
        void Save();
    }
}