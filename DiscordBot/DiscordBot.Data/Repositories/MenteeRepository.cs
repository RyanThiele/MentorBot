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
        private MenteeContext _context;

        public MenteeRepository()
        {
            _context = new MenteeContext();
        }

        public IEnumerable<Mentee> GetMentees()
        {
            return _context.Mentees.ToList();
        }

        public Mentee GetMentee(int id)
        {
            return _context.Mentees.Find(id);
        }

        public void InsertMentee(Mentee mentee)
        {
            _context.Mentees.Add(mentee);
        }

        public void DeleteMentee(int id)
        {
            var mentee = _context.Mentees.Find(id);
            _context.Mentees.Remove(mentee);
        }

        public void UpdateMentee(Mentee mentee)
        {
            _context.Entry(mentee).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
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
