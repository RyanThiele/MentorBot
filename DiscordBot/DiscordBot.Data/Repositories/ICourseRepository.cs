using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseAsync(ulong id);
        Task InsertCourseAsync(Course mentor);
        Task DeleteCourseAsync(ulong id);
        Task UpdateCourseAsync(Course mentor);
        Task SaveAsync();
    }
}