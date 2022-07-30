using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Consumable
    {
        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public double? Protein { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Sugars { get; set; }
        public double? Fat { get; set; }
        public double? SaturatedFat { get; set; }
        public double? Fiber { get; set; }
        public double? Salt { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
