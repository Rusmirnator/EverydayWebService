using Everyday.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IUserDataProvider
    {
        Task<User> GetUserAsync(string login, string password);
        Task<IEnumerable<Role>> GetUserRolesAsync(int userId);
    }
}
