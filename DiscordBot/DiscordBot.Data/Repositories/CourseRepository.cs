using DiscordBot.Data.Ef;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseAsync(ulong id)
        {
            return await db.Courses.FindAsync(id);
        }

        public async Task AddCourseAsync(Course course)
        {
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(ulong id)
        {
            var course = await db.Courses.FindAsync(id);
            if (course == null) return;
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            db.Courses.Update(course);
            await db.SaveChangesAsync();
        }
    }
}
