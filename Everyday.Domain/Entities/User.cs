using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("users")]
    [Index(nameof(Login), Name = "users_login_key", IsUnique = true)]
    public class User : EntityBase
    {
        [Required]
        [Column("login")]
        [StringLength(50)]
        public string? Login { get; set; }
        [Required]
        [Column("password")]
        [StringLength(254)]
        public string? Password { get; set; }
    }
}
