using System;
using System.Collections.Generic;
using DiscordBot.Domain.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMenteeRepository : IDisposable
    {
        IEnumerable<Mentee> GetMentees();
        Mentee GetMentee(int id);
        void InsertMentee(Mentee mentee);
        void DeleteMentee(int id);
        void UpdateMentee(Mentee mentee);
        void Save();
    }
}