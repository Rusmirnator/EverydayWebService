using Everyday.Core.EntitiesPg;
using Everyday.Core.Shared;
using System.Collections.Generic;

namespace Everyday.Core.Models
{
    public class UserDTO : DataTransferObject
    {
        public UserDTO(User userEntry) : base()
        {
            Login = userEntry.Login;
            Roles = new();
        }
        public string Login { get; set; }
        public HashSet<string> Roles { get; set; }
    }
}
