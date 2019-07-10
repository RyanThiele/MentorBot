using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        //private readonly CourseContext _context;

        public CourseRepository()
        {
           // _context = new CourseContext();
        }

        public  Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return null;
            //return await _context.Courses.ToListAsync();
        }

        public Task<Course> GetCourseAsync(ulong id)
        {
            return null;
            //return await _context.Courses.FindAsync(id);
        }

        public async Task InsertCourseAsync(Course course)
        {
            //await _context.Courses.AddAsync(course);
            await SaveAsync();
        }

        public async Task DeleteCourseAsync(ulong id)
        {
            //var course = await _context.Courses.FindAsync(id);
            //if (course == null) return;
            //_context.Courses.Remove(course);
            await SaveAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            //_context.Courses.Update(course);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            //await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            //if (!this._disposed)
            //{
            //    if (disposing)
            //    {
            //        _context.Dispose();
            //    }
            //}
            //this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
