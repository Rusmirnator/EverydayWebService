using Everyday.Core.EntitiesPg;
using System.Collections.Generic;
using System.Linq;

namespace Everyday.Core.Models
{
    public class ItemDTO
    {
        #region Fields & Properties
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public ItemDefinitionDTO ItemDefinition { get; set; }
        public ContainerDTO Container { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }
        #endregion

        #region CTOR
        public ItemDTO()
        {

        }

        public ItemDTO(Item entry)
        {
            Id = entry.Id;
            Code = entry.Code;
            Name = entry.Name;
            Description = entry.Description;
            Width = entry.Width;
            Height = entry.Height;
            Depth = entry.Depth;
            Weight = entry.Weight;
            Price = entry.Price;
            ItemDefinition = new ItemDefinitionDTO(entry.ItemDefinition);
            Container = InitializeContainer(entry.Containers);
            Manufacturer = InitializeManufacturer(entry.Manufacturer);
        }
        #endregion

        private static ContainerDTO InitializeContainer(ICollection<Container> containers)
        {
            Container entry = containers.FirstOrDefault();

            if (entry is null)
            {
                return null;
            }

            return new ContainerDTO(entry);
        }

        private static ManufacturerDTO InitializeManufacturer(Manufacturer entry)
        {
            if (entry is null)
            {
                return null;
            }
            return new ManufacturerDTO(entry);
        }
    }
}
