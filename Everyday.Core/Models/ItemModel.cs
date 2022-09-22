using Everyday.Core.EntitiesPg;
using Everyday.Core.Shared;
using System.ComponentModel.DataAnnotations;

namespace Everyday.Core.Models
{
    public class ItemModel : DataTransferObject
    {
        #region Fields & Properties
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public ItemDefinitionModel ItemDefinition { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
        #endregion

        #region CTOR
        public ItemModel()
        {

        }

        public ItemModel(Item entry) : base()
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
            ItemDefinition = new ItemDefinitionModel(entry.ItemDefinition);
            Manufacturer = InitializeManufacturer(entry.Manufacturer);
        }
        #endregion

        private static ManufacturerModel InitializeManufacturer(Manufacturer entry)
        {
            if (entry is null)
            {
                return null;
            }
            return new ManufacturerModel(entry);
        }
    }
}
