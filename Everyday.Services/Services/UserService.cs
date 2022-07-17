using Everyday.Core.Entities;
using Everyday.Core.Models;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataProvider userDataProvider;

        public UserService(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }
        public async Task<UserDTO> GetUserAsync(string login, string password)
        {
            User entry = await userDataProvider.GetUserAsync(login, password);

            if (entry is not null)
            {
                UserDTO user = new(entry);

                var query = await userDataProvider.GetUserRolesAsync(entry.Id);

                user.Roles = query?.Select(r => r.Name).ToHashSet();

                return await Task.FromResult(user);
            }
            return await Task.FromResult(null as UserDTO);
        }
    }
}
