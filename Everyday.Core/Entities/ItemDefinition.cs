using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class ItemDefinition
    {
        public ItemDefinition()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public int DimensionsMeasureUnitId { get; set; }
        public int WeightMeasureUnitId { get; set; }
        public int ItemCategoryTypeId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
