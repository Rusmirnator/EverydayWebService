using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Core.EntitiesPg
{
    [Table("containers")]
    public partial class Container
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Column("trashtypeid")]
        public int TrashTypeId { get; set; }
        [Column("isreusable")]
        public bool IsReusable { get; set; }
        [Column("itemid")]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("Containers")]
        public virtual Item Item { get; set; }
    }
}
