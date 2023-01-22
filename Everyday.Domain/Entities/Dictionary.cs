using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Everyday.Domain.Entities
{
    [Table("dictionaries")]
    public partial class Dictionary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("categoryid")]
        public int CategoryId { get; set; }
        [Column("description")]
        [StringLength(254)]
        public string Description { get; set; }
        [Column("value")]
        public int Value { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(DictionaryCategory.Dictionaries))]
        public virtual DictionaryCategory Category { get; set; }
    }
}
