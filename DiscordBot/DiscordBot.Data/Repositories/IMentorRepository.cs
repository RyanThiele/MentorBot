using DiscordBot.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public interface IMentorRepository : IDisposable
    {
        int GetCount();
        //List<Programmer> GetMentors(int begin, int end);
        Task<IEnumerable<Mentor>> GetMentorsAsync();
        Task<Mentor> GetMentorAsync(ulong id);
        Task InsertMentorAsync(Mentor mentor);
        Task DeleteMentorAsync(ulong id);
        Task UpdateMentorAsync(Mentor mentor);
        Task SaveAsync();
    }
}