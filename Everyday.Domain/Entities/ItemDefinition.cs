using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Domain.Entities
{
    [Table("itemdefinitions")]
    public partial class ItemDefinition
    {
        public ItemDefinition()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Column("dimensionsmeasureunitid")]
        public int DimensionsMeasureUnitId { get; set; }
        [Column("weightmeasureunitid")]
        public int WeightMeasureUnitId { get; set; }
        [Column("itemcategorytypeid")]
        public int ItemCategoryTypeId { get; set; }
        [Column("containerid")]
        public int? ContainerId { get; set; }

        [InverseProperty(nameof(Item.ItemDefinition))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
