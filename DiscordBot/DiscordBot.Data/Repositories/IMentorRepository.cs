using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMentorRepository : IDisposable
    {
        Task<IEnumerable<Mentor>> GetMentorsAsync();
        Task<Mentor> GetMentorAsync(ulong id);
        Task InsertMentorAsync(Mentor mentor);
        Task DeleteMentorAsync(ulong id);
        void UpdateMentor(Mentor mentor);
        Task SaveAsync();
    }
}