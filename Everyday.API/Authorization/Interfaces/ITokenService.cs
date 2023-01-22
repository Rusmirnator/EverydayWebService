namespace Everyday.API.Authorization.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, object user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
