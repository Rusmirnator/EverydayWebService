using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataProvider userDataProvider;
        private readonly ICryptographyService cryptographyService;
        private readonly ILogger<UserService> logger;

        public UserService(IUserDataProvider userDataProvider, ICryptographyService cryptographyService, ILogger<UserService> logger)
        {
            this.userDataProvider = userDataProvider;
            this.cryptographyService = cryptographyService;
            this.logger = logger;
        }
        public async Task<UserModel> GetUserAsync(string login, string password)
        {
            User entry = await userDataProvider.GetUserAsync(cryptographyService.Decrypt(login), 
                cryptographyService.GetSHA256Digest(string.Concat(cryptographyService.Decrypt(password), Constants.SUFFIX, Constants.SALT)));

            if (entry is not null)
            {
                logger.LogDebug($"User {entry.Login} logging in...");

                UserModel user = new(entry);

                var query = await userDataProvider.GetUserRolesAsync(entry.Id);

                user.Roles = query?.Select(r => r.Name).ToHashSet();

                return await Task.FromResult(user);
            }
            return await Task.FromResult(null as UserModel);
        }
    }
}
