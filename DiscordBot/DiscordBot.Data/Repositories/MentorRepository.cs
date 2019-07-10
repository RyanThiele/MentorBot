using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;
using static DiscordBot.Data.Constants;

namespace DiscordBot.Data.Repositories
{
    public class MentorRepository : RepositoryBase<MentorContext, Mentor>, IMentorRepository
    {
        private readonly MentorContext _context;

        public MentorRepository()
        {
            _context = new MentorContext();
        }

        public int GetCount() => Count();

        /// <summary>
        /// Returns mentors from begin to end index
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Mentor>> GetMentorsSliceAsync(int begin, int end) => await Slice(begin, end).ToListAsync();
        
        public async Task<IEnumerable<Mentor>> GetMentorsAsync() => await GetAll().ToListAsync();

        public async Task<Mentor> GetMentorAsync(ulong id) =>
            await Find(m => m.Id == id).SingleOrDefaultAsync();

        public async Task InsertMentorAsync(Mentor Mentor)
        {
            Insert(Mentor);
            await SaveAsync();
        }

        public async Task DeleteMentorAsync(ulong id)
        {
            var Mentor = await GetMentorAsync(id);
            Delete(Mentor);
            await SaveAsync();
        }

        public async Task UpdateMentorAsync(Mentor Mentor)
        {
            Update(Mentor);
            await SaveAsync();
        }

        public async Task<IEnumerable<Programmer>> SearchLanguage(Languages language) =>
            await Find(m => m.Languages.ContainsKey(language)).ToListAsync();

        public async Task<IEnumerable<Programmer>> SearchLevel(Levels level) =>
            await Find(m => m.Languages.ContainsValue(level)).ToListAsync();

    }
}
