using DiscordBot.Data.Ef;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseAsync(ulong id);
        Task AddCourseAsync(Course mentor);
        Task DeleteCourseAsync(ulong id);
        Task UpdateCourseAsync(Course mentor);
    }
}