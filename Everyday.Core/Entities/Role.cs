using System;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Role
    {
        public int Id { get; set; }
        public DateTime CreateDt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
