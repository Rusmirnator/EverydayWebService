using Everyday.Core.EntitiesPg;
using Everyday.Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Everyday.Data.DataSource;

namespace Everyday.Data.DataProviders
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly EverydayContext dbContext;

        public UserDataProvider(EverydayContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> GetUserAsync(string login, string password)
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(e => e.Login.Equals(login)
                                        && e.Password.Equals(password));
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(int userId)
        {
            return await dbContext.UserRoles
                .Where(e => e.UserId == userId)
                .Join(dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r)
                    .ToListAsync();
        }
    }
}
