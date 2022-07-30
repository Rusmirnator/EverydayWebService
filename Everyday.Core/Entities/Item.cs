using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Item
    {
        public Item()
        {
            Consumables = new HashSet<Consumable>();
            Containers = new HashSet<Container>();
        }

        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int ItemDefinitionId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ContainerId { get; set; }

        public virtual ItemDefinition ItemDefinition { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Consumable> Consumables { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
    }
}
