using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Core.EntitiesPg
{
    [Table("consumables")]
    public partial class Consumable
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createdt")]
        public DateTime CreateDT { get; set; }
        [Column("protein")]
        public double? Protein { get; set; }
        [Column("carbohydrates")]
        public double? Carbohydrates { get; set; }
        [Column("sugars")]
        public double? Sugars { get; set; }
        [Column("fat")]
        public double? Fat { get; set; }
        [Column("saturatedfat")]
        public double? SaturatedFat { get; set; }
        [Column("fiber")]
        public double? Fiber { get; set; }
        [Column("salt")]
        public double? Salt { get; set; }
        [Column("energy")]
        public double? Energy { get; set; }
        [Column("itemid")]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("Consumables")]
        public virtual Item Item { get; set; }
    }
}
