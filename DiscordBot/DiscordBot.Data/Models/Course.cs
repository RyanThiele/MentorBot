using System;
using System.Collections.Generic;

namespace DiscordBot.Data.Models
{
    public class Course
    {
        public Course(Guid id = new Guid())
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ulong TeacherId { get; set; }

        public virtual ICollection<User> Students { get; set; }

        //public Tuple<Constants.Languages, Constants.Levels> CourseDetails { get; set; }

        public int MaxMentees { get; set; }

        //public void Enroll(Mentee mentee)
        //{
        //    //Students.Add(mentee.Id);
        //}

        //public void Enroll(ulong id)
        //{
        //   // Students.Add(id);
        //}

        //public void DisEnroll(Mentee mentee)
        //{
        //    //Students.Remove(mentee.Id);
        //}

        //public void DisEnroll(ulong id)
        //{
        //    //Students.Remove(id);
        //}
    }
}