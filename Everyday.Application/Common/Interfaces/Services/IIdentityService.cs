using Everyday.Application.Common.Models;

namespace Everyday.Application.Common.Interfaces.Services
{
    public interface IIdentityService
    {
        public Task<UserResponseModel?> LoginAsync(LoginRequestModel loginData);
    }
}
