using Everyday.Core.Models;

namespace Everyday.API.Authorization.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, UserDTO user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
