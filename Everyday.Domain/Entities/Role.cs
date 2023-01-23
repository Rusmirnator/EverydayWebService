using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("roles")]
    [Index(nameof(Name), Name = "roles_name_key", IsUnique = true)]
    public partial class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string? Description { get; set; }
    }
}
