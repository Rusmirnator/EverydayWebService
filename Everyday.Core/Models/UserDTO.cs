using Everyday.Core.Entities;
using System.Collections.Generic;

namespace Everyday.Core.Models
{
    public class UserDTO
    {
        public UserDTO(User userEntry)
        {
            Login = userEntry.Login;
            Roles = new();
        }
        public string Login { get; set; }
        public HashSet<string> Roles { get; set; }
    }
}
