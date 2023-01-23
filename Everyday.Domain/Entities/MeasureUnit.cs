using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("measureunits")]
    public partial class MeasureUnit
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Required]
        [Column("signature")]
        [StringLength(5)]
        public string? Signature { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
