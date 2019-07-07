using System;
using System.Collections.Generic;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMentorRepository : IDisposable
    {
        IEnumerable<Mentor> GetMentors();
        Mentor GetMentor(int id);
        void InsertMentor(Mentor mentor);
        void DeleteMentor(int id);
        void UpdateMentor(Mentor mentor);
        void Save();
    }
}