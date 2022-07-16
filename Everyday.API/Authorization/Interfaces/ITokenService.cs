namespace Everyday.API.Authorization.Interfaces
{
    public interface ITokenService
    {
        string BuildToken();
        bool IsTokenValid();
    }
}
