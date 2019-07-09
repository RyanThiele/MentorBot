using System.Collections.Generic;
using DiscordBot.Data.Models;

namespace DiscordBot.Data.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(ulong id);
        void InsertCourse(Course mentor);
        void DeleteCourse(ulong id);
        void UpdateCourse(Course mentor);
        void Save();
    }
}