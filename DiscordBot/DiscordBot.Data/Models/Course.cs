using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBot.Data.Models
{
    public class Course : BaseEntity
    {

        public Course(ulong id) : base(id){ }

        public string Name { get; set; }

        public ulong TeacherId { get; set; }

        public IList<ulong> Students { get; set; }

        public Tuple<Constants.Languages, Constants.Levels> CourseDetails { get; set; }

        public void Enroll(Mentee mentee)
        {
            Students.Add(mentee.Id);
        }

        public void Enroll(ulong id)
        {
            Students.Add(id);
        }

        public void DisEnroll(Mentee mentee)
        {
            Students.Remove(mentee.Id);
        }

        public void DisEnroll(ulong id)
        {
            Students.Remove(id);
        }
    }
}