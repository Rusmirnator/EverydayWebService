using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Domain.Entities
{
    [Table("manufacturers")]
    [Index(nameof(Name), Name = "manufacturers_name_key", IsUnique = true)]
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Required]
        [Column("name")]
        [StringLength(254)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string Description { get; set; }

        [InverseProperty(nameof(Item.Manufacturer))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
