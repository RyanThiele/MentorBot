using DiscordBot.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        Task<IEnumerable<Course>> GetAllCoursesAsync();
    }
}