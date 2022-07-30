using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
