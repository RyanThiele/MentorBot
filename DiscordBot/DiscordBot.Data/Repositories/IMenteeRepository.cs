using System;
using System.Collections.Generic;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMenteeRepository : IDisposable
    {
        IEnumerable<Mentee> GetMentees();
        Mentee GetMentee(ulong id);
        void InsertMentee(Mentee mentee);
        void DeleteMentee(ulong id);
        void UpdateMentee(Mentee mentee);
        void Save();
    }
}