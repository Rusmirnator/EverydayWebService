using Everyday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser();
    }
}
