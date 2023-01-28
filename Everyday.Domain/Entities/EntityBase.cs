using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Everyday.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        [Column("id")]
        public virtual int Id { get; set; }
        [Column("createdat")]
        public virtual DateTime CreatedAt { get; set; }
    }
}
