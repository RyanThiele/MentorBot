using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public class MentorRepository : IDisposable, IMentorRepository
    {
        private readonly MentorContext _context;

        public MentorRepository()
        {
            _context = new MentorContext();
        }

        public int GetCount()
        {
            return _context.Mentors.Count();
        }

        /// <summary>
        /// Returns mentors from begin to end index
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        //public List<Programmer> GetMentors(int begin, int end)
        //{
        //    return  _context.Mentors.Skip(begin).Take(end).ToList<Programmer>();
        //}

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
            await SaveAsync();
        }

        public async Task DeleteMentorAsync(ulong id)
        {
            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor is null) return;
            _context.Mentors.Remove(mentor);
            await SaveAsync();
        }

        public async Task UpdateMentorAsync(Mentor mentor)
        {
            _context.Mentors.Update(mentor);
            await SaveAsync();
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
