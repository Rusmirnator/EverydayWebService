using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Core.Shared;
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
                                .FirstOrDefaultAsync(e => e.Code.Equals(code, System.StringComparison.Ordinal));
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
        public async Task<IConveyOperationResult> AddItemAsync(ItemDTO newItem)
        {
            OperationResult result;

            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(newItem.Code));

            if (item is not null)
            {
                result = new OperationResult(1, $"Item already exists! - {item.Id}", item);
                return result;
            }

            item ??= newItem.ToEntity();

            _ = dbContext.Add(item);

            if (!await SaveChangesAsync())
            {
                result = new OperationResult(1, "Couldn't save changes!", item);
            }

            result = new(0, $"Item has been created successfuly!", item);

            return result;
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateItemAsync(ItemDTO updatedItem)
        {
            OperationResult result;

            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(updatedItem.Code));

            if (item is null)
            {
                result = new OperationResult(-1, $"There is no such item! - {updatedItem.Code}");
                return result;
            }

            item.ToEntity(updatedItem);

            _ = dbContext.Update(item);

            result = new OperationResult(0, "Item changes have been saved successfuly!", item);

            if (!await SaveChangesAsync())
            {
                result = new OperationResult(1, "Couldn't save changes!", item);
            }

            return result;
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteItemAsync(int id)
        {
            Item entry = await GetItemByIdAsync(id);
            OperationResult result = new(0, $"{id} has been deleted successfuly!", entry);

            if (entry is null)
            {
                result = new OperationResult(-1, $"There is no such item! - {id}");
                return result;
            }

            dbContext.Items.Remove(entry);
            dbContext.Entry(entry.ItemDefinition).State = EntityState.Deleted;

            if (!await SaveChangesAsync())
            {
                result = new OperationResult(1, "Couldn't save changes!", entry);
            }

            return result;
        }

        public async Task<IConveyOperationResult> DeleteItemAsync(string code)
        {
            Item entry = await GetItemByCodeAsync(code);
            OperationResult result = new(0, $"{code} has been deleted successfuly!", entry);

            if (entry is null)
            {
                result = new OperationResult(-1, $"There is no such item! - {code}");
                return result;
            }

            dbContext.Items.Remove(entry);
            dbContext.Entry(entry.ItemDefinition).State = EntityState.Deleted;

            if (!await SaveChangesAsync())
            {
                result = new OperationResult(1, "Couldn't save changes!", entry);
            }

            return result;
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            int result = await dbContext.SaveChangesAsync();

            return result != 0;
        }
    }
}
