using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("itemdefinitions")]
    public class ItemDefinition : EntityBase
    {
        public ItemDefinition()
        {
            Items = new HashSet<Item>();
        }

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
