using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface IMenteeRepository : IDisposable
    {
        Task<IEnumerable<Mentee>> GetMenteesAsync();
        Task<Mentee> GetMenteeAsync(ulong id);
        Task InsertMenteeAsync(Mentee mentee);
        Task DeleteMenteeAsync(ulong id);
        void UpdateMentee(Mentee mentee);
        Task SaveAsync();
    }
}