using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Core.EntitiesPg
{
    [Table("existingitems")]
    public partial class ExistingItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Column("itemid")]
        public int ItemId { get; set; }
        [Column("qty")]
        public double Qty { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ExistingItems")]
        public virtual Item Item { get; set; }
    }
}
