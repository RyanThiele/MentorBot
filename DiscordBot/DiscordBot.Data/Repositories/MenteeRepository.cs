using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;
using static DiscordBot.Data.Constants;

namespace DiscordBot.Data.Repositories
{
    public class MenteeRepository : RepositoryBase<MenteeContext, Mentee>, IMenteeRepository
    {

        public MenteeRepository() : base()
        {
        }

        public int GetCount() => Count();

        /// <summary>
        /// Returns mentees from begin to end index
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Mentee>> GetMenteesSliceAsync(int begin, int end) => await Slice(begin, end).ToListAsync();

        public async Task<IEnumerable<Mentee>> GetMenteesAsync() => await GetAll().ToListAsync();

        public async Task<Mentee> GetMenteeAsync(ulong id) =>
            await Find(m => m.Id == id).SingleOrDefaultAsync();


        public async Task InsertMenteeAsync(Mentee mentee)
        {
            Insert(mentee);
            await SaveAsync();
        }

        public async Task DeleteMenteeAsync(ulong id)
        {
            var mentee = await GetMenteeAsync(id);
            Delete(mentee);
            await SaveAsync();
        }

        public async Task UpdateMenteeAsync(Mentee mentee)
        {
            Update(mentee);
            await SaveAsync();
        }

        public async Task<IEnumerable<Programmer>> SearchLanguage(Languages language) =>
            await Find(m => m.Languages.ContainsKey(language)).ToListAsync();

        public async Task<IEnumerable<Programmer>> SearchLevel(Levels level) =>
            await Find(m => m.Languages.ContainsValue(level)).ToListAsync();

    }
}
