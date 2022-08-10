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

        public static Manufacturer UpdateFrom(this Manufacturer source, ManufacturerDTO dto)
        {
            source.Id = dto.Id;
            source.Name = dto.Name;
            source.Description = dto.Description;

            return source;
        }

        public static ItemDefinition UpdateFrom(this ItemDefinition source, ItemDefinitionDTO dto)
        {
            source.Id = dto.Id;
            source.DimensionsMeasureUnitId = dto.DimensionsMeasureUnitId;
            source.WeightMeasureUnitId = dto.WeightMeasureUnitId;
            source.ItemCategoryTypeId = dto.ItemCategoryTypeId;
            source.ContainerId = dto.ContainerId;

            return source;
        }

        public static Item UpdateFrom(this Item source, ItemDTO dto)
        {
            source.Id = dto.Id;
            source.Code = dto.Code;
            source.Name = dto.Name;
            source.Description = dto.Description;
            source.Width = dto.Width;
            source.Height = dto.Height;
            source.Depth = dto.Depth;
            source.Weight = dto.Weight;
            source.Price = dto.Price;
            source.ItemDefinition.UpdateFrom(dto.ItemDefinition);
            source.Manufacturer.UpdateFrom(dto.Manufacturer);

            return source;
        }
    }
}
