using DiscordBot.Data.Ef;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public async Task AddUserAsync(User user)
        {
            User existingUser = await db.Users.SingleOrDefaultAsync(x => x.UserId == user.UserId);
            if (existingUser != null)
            {
                db.Remove(existingUser);
                await db.SaveChangesAsync();
            }

            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task<User> GetUserAndUserLanguagesByUserId(ulong userId)
        {
            return await db.Users.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<User> GetUserByUserIdAsync(ulong userId)
        {
            return await db.Users.FindAsync(userId);
        }

        public async Task<Roles> GetUserLanguageRoleByUserIdAndProgrammingLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage)
        {
            return await db.UserLanguages
                .Where(x => x.UserId == userId)
                .Where(x => x.ProgrammingLanguage == programmingLanguage)
                .Select(x => x.Role)
                .SingleOrDefaultAsync();
        }

        public async Task<ProgrammingLanguages> GetUserProgrammingLanguageByUserIdAndProgrammingLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage)
        {
            return await db.UserLanguages
                .Where(x => x.UserId == userId)
                .Where(x => x.ProgrammingLanguage == programmingLanguage)
                .Select(x => x.ProgrammingLanguage)
                .SingleOrDefaultAsync();

        }

        public async Task<Roles> GetUserRoleByUserIdAsync(ulong userId)
        {
            return await db.Users
                .Select(x => x.Role)
                .SingleOrDefaultAsync();
        }

        public async Task RemoveUserLanguageAsync(ulong userId, ProgrammingLanguages programmingLanguage)
        {
            UserLanguage userLanguage = await db.UserLanguages
                           .Where(x => x.UserId == userId)
                           .Where(x => x.ProgrammingLanguage == programmingLanguage)
                           .SingleOrDefaultAsync();

            if (userLanguage != null)
            {
                db.Remove(userLanguage);
                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveUserRoleAsync(ulong userId)
        {
            User user = await db.Users.FindAsync(userId);
            if (user != null) user.Role = Roles.Mentee;
            await db.SaveChangesAsync();
        }

        public async Task SetProgrammingLanguageAndUserLanguageRoleAsync(ulong userId, ProgrammingLanguages programmingLanguage, Roles role)
        {
            UserLanguage userLanguage = await db.UserLanguages
                   .Where(x => x.UserId == userId)
                   .Where(x => x.Role == role)
                   .SingleOrDefaultAsync();

            if (userLanguage != null)
            {
                userLanguage.Role = role;
                userLanguage.ProgrammingLanguage = programmingLanguage;
            }
            else
            {
                await db.UserLanguages.AddAsync(userLanguage);
            }

            await db.SaveChangesAsync();
        }
    }
}
