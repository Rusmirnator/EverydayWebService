using Everyday.Application.Common.Models;

namespace Everyday.Application.Common.Interfaces.Services
{
    public interface ITokenService
    {
        public string BuildToken(string key, string issuer, string audience, UserResponseModel user);
        public bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
