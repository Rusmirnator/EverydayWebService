using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Core.EntitiesPg
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
