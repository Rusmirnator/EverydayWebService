using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;

namespace Everyday.Data
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Creates new instance of entity from calling data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates new instance of entity from calling data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates new instance of entity from calling data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Manufacturer ToEntity(this ManufacturerDTO dto)
        {
            return new Manufacturer
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
        }

        /// <summary>
        /// Creates new instance of entity from calling data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Consumable ToEntity(this ConsumableDTO dto)
        {
            return new Consumable
            {
                Id = dto.Id,
                Protein = dto.Protein,
                Carbohydrates = dto.Carbohydrates,
                Sugars = dto.Sugars,
                Fat = dto.Fat,
                SaturatedFat = dto.SaturatedFat,
                Fiber = dto.Fiber,
                Salt = dto.Salt,
                Energy = dto.Energy
            };
        }

        /// <summary>
        /// Updates calling entity using passed data transfer object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Manufacturer ToEntity(this Manufacturer source, ManufacturerDTO dto)
        {
            source.Id = dto.Id;
            source.Name = dto.Name;
            source.Description = dto.Description;

            return source;
        }

        /// <summary>
        /// Updates calling entity using passed data transfer object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ItemDefinition ToEntity(this ItemDefinition source, ItemDefinitionDTO dto)
        {
            source.Id = dto.Id;
            source.DimensionsMeasureUnitId = dto.DimensionsMeasureUnitId;
            source.WeightMeasureUnitId = dto.WeightMeasureUnitId;
            source.ItemCategoryTypeId = dto.ItemCategoryTypeId;
            source.ContainerId = dto.ContainerId;

            return source;
        }

        /// <summary>
        /// Updates calling entity using passed data transfer object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Item ToEntity(this Item source, ItemDTO dto)
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
            source.ItemDefinition.ToEntity(dto.ItemDefinition);
            source.Manufacturer.ToEntity(dto.Manufacturer);

            return source;
        }
        
        /// <summary>
        /// Updates calling entity using passed data transfer object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Consumable ToEntity(this Consumable source, ConsumableDTO dto)
        {
            source.Id = dto.Id;
            source.Protein = dto.Protein;
            source.Carbohydrates = dto.Carbohydrates;
            source.Sugars = dto.Sugars;
            source.Fat = dto.Fat;
            source.SaturatedFat = dto.SaturatedFat;
            source.Fiber = dto.Fiber;
            source.Salt = dto.Salt;
            source.Energy = dto.Energy;

            return source;
        }
    }
}
