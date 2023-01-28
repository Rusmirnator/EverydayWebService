using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("items")]
    [Index(nameof(Code), Name = "uq_items_code", IsUnique = true)]
    public class Item : EntityBase
    {
        public Item()
        {
            Consumables = new HashSet<Consumable>();
            Containers = new HashSet<Container>();
            ExistingItems = new HashSet<ExistingItem>();
        }

        [Column("code")]
        [StringLength(254)]
        public string? Code { get; set; }
        [Required]
        [Column("name")]
        [StringLength(254)]
        public string? Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string? Description { get; set; }
        [Column("width")]
        public double? Width { get; set; }
        [Column("height")]
        public double? Height { get; set; }
        [Column("depth")]
        public double? Depth { get; set; }
        [Column("weight")]
        public double? Weight { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("itemdefinitionid")]
        public int ItemDefinitionId { get; set; }
        [Column("manufacturerid")]
        public int? ManufacturerId { get; set; }

        [ForeignKey(nameof(ItemDefinitionId))]
        [InverseProperty("Items")]
        public virtual ItemDefinition? ItemDefinition { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("Items")]
        public virtual Manufacturer? Manufacturer { get; set; }
        [InverseProperty(nameof(Consumable.Item))]
        public virtual ICollection<Consumable> Consumables { get; set; }
        [InverseProperty(nameof(Container.Item))]
        public virtual ICollection<Container> Containers { get; set; }
        [InverseProperty(nameof(ExistingItem.Item))]
        public virtual ICollection<ExistingItem> ExistingItems { get; set; }
    }
}
