using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
