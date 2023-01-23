using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("containers")]
    public class Container
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Column("trashtypeid")]
        public int TrashTypeId { get; set; }
        [Column("isreusable")]
        public bool IsReusable { get; set; }
        [Column("itemid")]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("Containers")]
        public virtual Item? Item { get; set; }
    }
}
