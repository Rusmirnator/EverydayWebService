using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("userroles")]
    public class UserRole : EntityBase
    {
        [Column("userid")]
        public int UserId { get; set; }
        [Column("roleid")]
        public int RoleId { get; set; }
    }
}
