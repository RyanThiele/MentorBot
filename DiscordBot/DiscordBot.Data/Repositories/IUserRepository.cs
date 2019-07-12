using DiscordBot.Data.Ef;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public interface IUserRepository
    {
        // Create
        Task AddUserAsync(Ef.User user);

        // Read
        Task<Roles> GetUserRoleByUserIdAsync(ulong userId);
        Task<User> GetUserByUserIdAsync(ulong userId);
        Task<User> GetUserAndUserLanguagesByUserId(ulong userId);
        Task<Roles> GetUserLanguageRoleByUserIdAndProgrammingLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage);
        Task<ProgrammingLanguages> GetUserProgrammingLanguageByUserIdAndProgrammingLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage);

        // Update
        Task SetProgrammingLanguageAndUserLanguageRoleAsync(ulong userId, ProgrammingLanguages programmingLanguage, Roles role);

        // Delete
        Task RemoveUserRoleAsync(ulong userId);
        Task RemoveUserLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage);
    }
}
