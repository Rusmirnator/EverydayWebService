using Everyday.Core.EntitiesPg;

namespace Everyday.Core.Models
{
    public class ItemDefinitionDTO
    {
        #region Fields & Properties
        public int Id { get; set; }
        public int DimensionsMeasureUnitId { get; set; }
        public int WeightMeasureUnitId { get; set; }
        public int ItemCategoryTypeId { get; set; }
        public int? ContainerId { get; set; }
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
            ContainerId = entry.ContainerId;
        }
        #endregion
    }
}
