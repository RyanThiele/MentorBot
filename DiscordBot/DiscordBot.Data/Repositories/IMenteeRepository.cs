using DiscordBot.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public interface IMenteeRepository : IDisposable
    {
        int GetCount();
        //List<Programmer> GetMentees(int begin, int end);
        Task<IEnumerable<Mentee>> GetMenteesAsync();
        Task<Mentee> GetMenteeAsync(ulong id);
        Task InsertMenteeAsync(Mentee mentee);
        Task DeleteMenteeAsync(ulong id);
        Task UpdateMenteeAsync(Mentee mentee);
        Task SaveAsync();
    }
}