using System;

namespace DiscordBot.Data
{
    public enum ProgrammingLanguages
    {
        Python,
        JavaScript,
        Java,
        Csharp,
        CPlusPlus,
        C
    }

    public enum CompetenceLevels
    {
        Experienced,
        Intermediate,
        Beginner
    }

    [Flags]
    public enum Roles
    {
        Mentor = 1,
        Mentee = 2,
        Admin = 4
    }
}
