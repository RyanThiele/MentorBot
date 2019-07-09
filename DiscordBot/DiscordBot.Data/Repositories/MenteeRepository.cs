using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data.Repositories
{
    public class MenteeRepository : IMenteeRepository
    {
        private readonly MenteeContext _context;

        public MenteeRepository()
        {
            _context = new MenteeContext();
        }

        public async Task<IEnumerable<Mentee>> GetMenteesAsync()
        {
            return await _context.Mentees.ToListAsync();
        }

        public async Task<Mentee> GetMenteeAsync(ulong id)
        {
            return await _context.Mentees.FindAsync(id);
        }

        public async Task InsertMenteeAsync(Mentee mentee)
        {
            await _context.Mentees.AddAsync(mentee);
        }

        public async Task DeleteMenteeAsync(ulong id)
        {
            var mentee = await _context.Mentees.FindAsync(id);
            if (mentee is null) return;
            _context.Mentees.Remove(mentee);
        }

        public void UpdateMentee(Mentee mentee)
        {
            _context.Mentees.Update(mentee);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
