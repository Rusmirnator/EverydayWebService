using System.Collections.Generic;

namespace Everyday.Core.Models
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public HashSet<string> Roles { get; set; }
    }
}
