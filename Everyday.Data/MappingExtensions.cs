using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;

namespace Everyday.Data
{
    public static class MappingExtensions
    {
        public static Item ToEntity(this ItemDTO dto)
        {
            return new Item
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                Width = dto.Width,
                Height = dto.Height,
                Depth = dto.Depth,
                Weight = dto.Weight,
                Price = dto.Price,
                ItemDefinition = dto.ItemDefinition.ToEntity(),
                Manufacturer = dto.Manufacturer.ToEntity()
            };
        }

        public static ItemDefinition ToEntity(this ItemDefinitionDTO dto)
        {
            return new ItemDefinition
            {
                Id = dto.Id,
                DimensionsMeasureUnitId = dto.DimensionsMeasureUnitId,
                WeightMeasureUnitId = dto.WeightMeasureUnitId,
                ItemCategoryTypeId = dto.ItemCategoryTypeId,
                ContainerId = dto.ContainerId
            };
        }

        public static Manufacturer ToEntity(this ManufacturerDTO dto)
        {
            return new Manufacturer
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
