﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Everyday.Domain.Entities
{
    [Table("consumables")]
    public class Consumable : EntityBase
    {
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
        public virtual Item? Item { get; set; }
    }
}
