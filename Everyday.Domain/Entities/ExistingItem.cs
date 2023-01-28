using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("existingitems")]
    public class ExistingItem : EntityBase
    {
        [Column("itemid")]
        public int ItemId { get; set; }
        [Column("qty")]
        public double Qty { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ExistingItems")]
        public virtual Item? Item { get; set; }
    }
}
