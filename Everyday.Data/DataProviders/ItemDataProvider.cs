using Everyday.Core.EntitiesPg;
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
            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(newItem.Code));

            if (item is null)
            {
                item = newItem.ToEntity();
            }

            _ = dbContext.Add(item);

            return await SaveChangesAsync();
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateItemAsync(ItemDTO updatedItem)
        {
            Item item = await dbContext.Items
                .Include(e => e.ItemDefinition)
                .Include(e => e.Manufacturer)
                    .FirstOrDefaultAsync(e => e.Code.Equals(updatedItem.Code));

            if (item is null)
            {
                return await Task.FromResult(false);
            }

            item.UpdateFrom(updatedItem);

            _ = dbContext.Update(item);

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
