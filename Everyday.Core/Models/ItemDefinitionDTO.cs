﻿using Everyday.Core.EntitiesPg;
using Everyday.Core.Shared;

namespace Everyday.Core.Models
{
    public class ItemDefinitionDTO : DataTransferObject
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
        public ItemDefinitionDTO(ItemDefinition entry) : base()
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
