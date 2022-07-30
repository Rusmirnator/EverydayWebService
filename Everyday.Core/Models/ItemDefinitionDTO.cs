using Everyday.Core.Entities;

namespace Everyday.Core.Models
{
    public class ItemDefinitionDTO
    {
        #region Fields & Properties
        public int Id { get; set; }
        public int DimensionsMeasureUnitId { get; set; }
        public int WeightMeasureUnitId { get; set; }
        public int ItemCategoryTypeId { get; set; }
        #endregion

        #region CTOR
        public ItemDefinitionDTO()
        {

        }
        public ItemDefinitionDTO(ItemDefinition entry)
        {
            Id = entry.Id;
            DimensionsMeasureUnitId = entry.DimensionsMeasureUnitId;
            WeightMeasureUnitId = entry.WeightMeasureUnitId;
            ItemCategoryTypeId = entry.ItemCategoryTypeId;
        }
        #endregion
    }
}
