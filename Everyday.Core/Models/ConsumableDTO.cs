using Everyday.Core.EntitiesPg;
using System;
using System.ComponentModel.DataAnnotations;

namespace Everyday.Core.Models
{
    public class ConsumableDTO
    {
        #region Fields & Properties
        public int Id { get; set; }
        public double? Protein { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Sugars { get; set; }
        public double? Fat { get; set; }
        public double? SaturatedFat { get; set; }
        public double? Fiber { get; set; }
        public double? Salt { get; set; }
        public double? Energy { get; set; }
        public int? ItemId { get; set; }
        #endregion

        #region CTOR
        public ConsumableDTO()
        {

        }
        public ConsumableDTO(Consumable entry)
        {
            Id = entry.Id;
            Protein = entry.Protein;
            Carbohydrates = entry.Carbohydrates;
            Sugars = entry.Sugars;
            Fat = entry.Fat;
            SaturatedFat = entry.SaturatedFat;
            Fiber = entry.Fiber;
            Salt = entry.Salt;
            Energy = entry.Energy;
            ItemId = entry.ItemId;
        }
        #endregion
    }
}
