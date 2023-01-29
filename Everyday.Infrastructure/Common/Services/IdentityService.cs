using Everyday.Application.Common.Interfaces.DataAccess;
using Everyday.Application.Common.Interfaces.Services;
using Everyday.Application.Common.Mappings;
using Everyday.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Everyday.Infrastructure.Common.Services
{
    public class IdentityService : IIdentityService
    {
        #region Fields & Properties
        private readonly IEverydayDbContext context;
        private readonly ITokenService tokenService;
        #endregion

        #region CTOR
        public IdentityService(IEverydayDbContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }
        #endregion

        #region Public API
        public async Task<UserResponseModel?> LoginAsync(LoginRequestModel loginData)
        {
            UserResponseModel? validUser =
                await GetUserByCredentialsAsync(loginData.UserUniqueIdentifier!, loginData.EncodedPassword!);

            if (validUser is null)
            {
                return default;
            }

            string generatedToken = tokenService.BuildToken(validUser);

            if (!string.IsNullOrEmpty(generatedToken) && tokenService.ValidateToken(generatedToken))
            {
                validUser.EncodedToken = generatedToken;
            }

            return validUser;
        }
        #endregion

        #region Private API
        private async Task<UserResponseModel?> GetUserByCredentialsAsync(string login, string password)
        {
            return (await context.Users
                            .FirstOrDefaultAsync(u => u.Login!.Equals(login)
                                                    && u.Password!.Equals(password))).ToResponse();
        }
        #endregion
    }
}
