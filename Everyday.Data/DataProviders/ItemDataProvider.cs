using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Data.DataSource;
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

        public async Task<Item> GetItemByCodeAsync(string code)
        {
            return await dbContext.Items
                            .Include(i => i.ItemDefinition)
                            .Include(i => i.Containers)
                            .Include(i => i.Manufacturer)
                                .FirstOrDefaultAsync(e => e.Code.Equals(code));
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
        public async Task<IConveyOperationResult> AddItemAsync(ItemModel newItem)
        {
            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(newItem.Code));

            if (item is not null)
            {
                return IConveyOperationResult.Create(1, $"Item already exists! - {item.Id}", item);
            }

            item ??= newItem.ToEntity();

            _ = dbContext.Add(item);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!", item);
            }

            return IConveyOperationResult.Create(0, $"Item has been created successfuly!", item);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateItemAsync(ItemModel updatedItem)
        {
            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(updatedItem.Code));

            if (item is null)
            {
                return IConveyOperationResult.Create(-1, $"There is no such item! - {updatedItem.Code}");
            }

            item.Sync(updatedItem);

            _ = dbContext.Update(item);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!", item);
            }

            return IConveyOperationResult.Create(0, "Item changes have been saved successfuly!", item);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteItemAsync(int id)
        {
            Item entry = await GetItemByIdAsync(id);

            if (entry is null)
            {
                return IConveyOperationResult.Create(-1, $"There is no such item! - {id}");
            }

            dbContext.Items.Remove(entry);
            dbContext.Entry(entry.ItemDefinition).State = EntityState.Deleted;

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!", entry);
            }

            return IConveyOperationResult.Create(0, $"{id} has been deleted successfuly!", entry);
        }

        public async Task<IConveyOperationResult> DeleteItemAsync(string code)
        {
            Item entry = await GetItemByCodeAsync(code);

            if (entry is null)
            {
                return IConveyOperationResult.Create(-1, $"There is no such item! - {code}");
            }

            dbContext.Items.Remove(entry);
            dbContext.Entry(entry.ItemDefinition).State = EntityState.Deleted;

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!", entry);
            }

            return IConveyOperationResult.Create(0, $"{code} has been deleted successfuly!", entry);
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            int result = await dbContext.SaveChangesAsync();

            return result != 0;
        }
    }
}
