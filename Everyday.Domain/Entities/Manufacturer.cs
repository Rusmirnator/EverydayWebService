using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("manufacturers")]
    [Index(nameof(Name), Name = "manufacturers_name_key", IsUnique = true)]
    public class Manufacturer : EntityBase
    {
        public Manufacturer()
        {
            Items = new HashSet<Item>();
        }

        [Required]
        [Column("name")]
        [StringLength(254)]
        public string? Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string? Description { get; set; }

        [InverseProperty(nameof(Item.Manufacturer))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
