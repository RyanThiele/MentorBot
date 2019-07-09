using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data.Repositories
{
    public class MentorRepository : IDisposable, IMentorRepository
    {
        private readonly MentorContext _context;

        public MentorRepository()
        {
            _context = new MentorContext();
        }

        public async Task<IEnumerable<Mentor>> GetMentorsAsync()
        {
            return await _context.Mentors.ToListAsync();
        }

        public async Task<Mentor> GetMentorAsync(ulong id)
        {
            return await _context.Mentors.FindAsync(id);
        }

        public async Task InsertMentorAsync(Mentor mentor)
        {
            await _context.Mentors.AddAsync(mentor);
        }

        public async Task DeleteMentorAsync(ulong id)
        {
            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor is null) return;
            _context.Mentors.Remove(mentor);
        }

        public void UpdateMentor(Mentor mentor)
        {
            _context.Mentors.Update(mentor);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
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
