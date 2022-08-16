using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Core.EntitiesPg
{
    [Table("userroles")]
    public partial class UserRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
        [Column("roleid")]
        public int RoleId { get; set; }
    }
}
