using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public DateTime CreateDt { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
