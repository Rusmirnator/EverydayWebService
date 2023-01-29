using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Application.Common.Models;

namespace Everyday.Application.Common.Interfaces.Services
{
    public interface ITokenService
    {
        public ITokenOptions? Options { get; set; }
        public string BuildToken(UserResponseModel user);
        public bool ValidateToken(string encodedToken);
    }
}
