using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscordBot.Domain.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Mentor Teacher { get; set; }

        public Dictionary<int, Mentee> Students { get; set; }

        public KeyValuePair<Constants.Languages, Constants.Levels> CourseDetails { get; set; }

        public void Enroll(Mentee mentee)
        { 
            Students.Add(mentee.Id, mentee);
        }

        public void DisEnroll(Mentee mentee)
        {
            Students.Remove(mentee.Id);
        }
    }
}