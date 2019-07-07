using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBot.Data.Models
{
    public class Course
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public Mentor Teacher { get; set; }

        [ForeignKey("")] public Dictionary<int, Mentee> Students { get; set; }

        public Tuple<Constants.Languages, Constants.Levels> CourseDetails { get; set; }

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