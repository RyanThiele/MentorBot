using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBot.Data.Ef
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ulong UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumEnrolled { get; set; }
        public ProgrammingLanguages ProgrammingLanguage { get; set; }
        public CompetenceLevels CompetenceLevels { get; set; }


        // Navigation
        public virtual IList<User> Users { get; set; }

        //public Tuple<Constants.Languages, Constants.Levels> CourseDetails { get; set; }



    }
}