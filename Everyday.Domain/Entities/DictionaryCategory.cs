using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Domain.Entities
{
    [Table("dictionarycategories")]
    [Index(nameof(Name), Name = "dictionarycategories_name_key", IsUnique = true)]
    public partial class DictionaryCategory
    {
        public DictionaryCategory()
        {
            Dictionaries = new HashSet<Dictionary>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string Description { get; set; }

        [InverseProperty(nameof(Dictionary.Category))]
        public virtual ICollection<Dictionary> Dictionaries { get; set; }
    }
}
