using Everyday.Core.Entities;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataProvider userDataProvider;
        private readonly ICryptographyService cryptographyService;

        public UserService(IUserDataProvider userDataProvider, ICryptographyService cryptographyService)
        {
            this.userDataProvider = userDataProvider;
            this.cryptographyService = cryptographyService;
        }
        public async Task<UserDTO> GetUserAsync(string login, string password)
        {
            User entry = await userDataProvider.GetUserAsync(login, 
                cryptographyService.GetSHA256Digest(string.Concat(password, Constants.SUFFIX, Constants.SALT)));

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
