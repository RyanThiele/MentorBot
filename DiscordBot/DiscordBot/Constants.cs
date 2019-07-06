using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot
{
    public static class Constants
    {
        public const string TOKEN = "NTk3MTU2NzA5NTE2OTY3OTM2.XSEF9w.A-m5HMu1BAXnbomJAFm7kUTOX1E";

        public const string MENTEE_FILE_PATH = "C:/Workspace/Mentees";
        public const string MENTOR_FILE_PATH = "C:/Workspace/Mentors";


        public enum Languages
        {
            Python,
            JavaScript,
            Java,
            Csharp,
            CPlusPlus,
            C
        }

        public enum Levels
        {
            Experienced,
            Intermediate,
            Beginner
        }
    }
}
