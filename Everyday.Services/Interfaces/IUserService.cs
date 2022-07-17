using Everyday.Core.Models;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(string login, string password);
    }
}
