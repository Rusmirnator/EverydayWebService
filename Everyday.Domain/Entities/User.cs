using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Domain.Entities
{
    [Table("users")]
    [Index(nameof(Login), Name = "users_login_key", IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Required]
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [Column("password")]
        [StringLength(254)]
        public string Password { get; set; }
    }
}
