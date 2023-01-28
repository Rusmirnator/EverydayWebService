using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("roles")]
    [Index(nameof(Name), Name = "roles_name_key", IsUnique = true)]
    public class Role : EntityBase
    {
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string? Description { get; set; }
    }
}
