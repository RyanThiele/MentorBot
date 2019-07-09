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

        public IEnumerable<Mentor> GetMentors()
        {
            return _context.Mentors.ToList();
        }

        public Mentor GetMentor(ulong id)
        {
            return _context.Mentors.Find(id);
        }

        public void InsertMentor(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
        }

        public void DeleteMentor(ulong id)
        {
            var mentor = _context.Mentors.Find(id);
            _context.Mentors.Remove(mentor);
        }

        public void UpdateMentor(Mentor mentor)
        {
            _context.Entry(mentor).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
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
