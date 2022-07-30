using Everyday.Core.Entities;
using Everyday.Core.Models;
using Everyday.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.DataProviders
{
    public class ItemDataProvider : IItemDataProvider
    {
        #region Fields & Properties
        private readonly EverydayContext dbContext;
        #endregion

        #region CTOR
        public ItemDataProvider(EverydayContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region READ
        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await dbContext.Items
                            .Include(i => i.ItemDefinition)
                            .Include(i => i.Containers)
                            .Include(i => i.Manufacturer)
                                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await dbContext.Items
                            .Include(i => i.ItemDefinition)
                            .Include(i => i.Containers)
                            .Include(i => i.Manufacturer)
                                .ToListAsync();
        }
        #endregion

        #region CREATE
        public async Task<bool> AddItemAsync(ItemDTO newItem)
        {
            Item createdItem = new();
            ItemDefinition createdDefinition = new();
            Container createdContainer = new();
            Manufacturer createdManufacturer = new();

            createdDefinition.DimensionsMeasureUnitId = newItem.ItemDefinition.DimensionsMeasureUnitId;
            createdDefinition.WeightMeasureUnitId = newItem.ItemDefinition.WeightMeasureUnitId;
            createdDefinition.ItemCategoryTypeId = newItem.ItemDefinition.ItemCategoryTypeId;

            createdItem.Name = newItem.Name;
            createdItem.Description = newItem.Description;
            createdItem.Code = newItem.Code;
            createdItem.Width = newItem.Width;
            createdItem.Height = newItem.Height;
            createdItem.Depth = newItem.Depth;
            createdItem.Weight = newItem.Weight;
            createdItem.Price = newItem.Price;

            createdItem.ItemDefinition = createdDefinition;

            if (newItem.Container is not null)
            {
                createdContainer.Id = newItem.Container.Id;
                createdContainer.TrashTypeId = newItem.Container.TrashTypeId;
                createdContainer.IsReusable = newItem.Container.IsReusable;
                createdItem.Containers.Add(createdContainer);
            }

            if (newItem.Manufacturer is not null)
            {
                createdManufacturer.Id = newItem.Manufacturer.Id;
                createdManufacturer.Name = newItem.Manufacturer.Name;
                createdManufacturer.Description = newItem.Manufacturer.Description;
                createdItem.Manufacturer = createdManufacturer;
            }

            _ = await dbContext.Items.AddAsync(createdItem);

            return await SaveChangesAsync();
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateItemAsync(ItemDTO updatedItem)
        {
            Item existingItem = await GetItemByIdAsync(updatedItem.Id);

            if (existingItem is null)
            {
                return false;
            }

            ItemDefinition existingDefinition = existingItem.ItemDefinition;
            Container existingContainer = await dbContext.Containers
                                                    .FirstOrDefaultAsync(e => e.ItemId == existingItem.Id);

            Manufacturer existingManufacturer = await dbContext.Manufacturers
                                                        .FirstOrDefaultAsync(e => e.Items.Contains(existingItem));

            existingDefinition.DimensionsMeasureUnitId = updatedItem.ItemDefinition.DimensionsMeasureUnitId;
            existingDefinition.WeightMeasureUnitId = updatedItem.ItemDefinition.WeightMeasureUnitId;
            existingDefinition.ItemCategoryTypeId = updatedItem.ItemDefinition.ItemCategoryTypeId;

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.Code = updatedItem.Code;
            existingItem.Width = updatedItem.Width;
            existingItem.Height = updatedItem.Height;
            existingItem.Depth = updatedItem.Depth;
            existingItem.Weight = updatedItem.Weight;
            existingItem.Price = updatedItem.Price;

            existingItem.ItemDefinition = existingDefinition;

            if (updatedItem.Container is not null)
            {
                if(existingContainer is null)
                {
                    existingContainer = new();
                }

                existingContainer.Id = updatedItem.Container.Id;
                existingContainer.TrashTypeId = updatedItem.Container.TrashTypeId;
                existingContainer.IsReusable = updatedItem.Container.IsReusable;
            }

            if (updatedItem.Manufacturer is not null)
            {
                if(existingManufacturer is null)
                {
                    existingManufacturer = new();
                }

                existingManufacturer.Id = updatedItem.Manufacturer.Id;
                existingManufacturer.Name = updatedItem.Manufacturer.Name;
                existingManufacturer.Description = updatedItem.Manufacturer.Description;
            }

            return await SaveChangesAsync();
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteItemAsync(int id)
        {
            Item entry = await GetItemByIdAsync(id);

            if (entry is null)
            {
                return false;
            }

            dbContext.Items.Remove(entry);
            dbContext.Entry(entry.ItemDefinition).State = EntityState.Deleted;

            return await SaveChangesAsync();
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            int result = await dbContext.SaveChangesAsync();

            return result != 0;
        }
    }
}
