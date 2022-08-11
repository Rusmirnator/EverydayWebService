using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using Everyday.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.DataProviders
{
    public class ConsumableDataProvider : IConsumableDataProvider
    {
        #region Fields & Properties
        private readonly EverydayContext dbContext;
        #endregion

        #region CTOR 
        public ConsumableDataProvider(EverydayContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region READ
        public async Task<Consumable> GetConsumableByItemIdAsync(int itemId)
        {
            return await dbContext.Consumables
                            .Include(e => e.Item)
                                .FirstOrDefaultAsync(e => e.ItemId == itemId);
        }

        public async Task<IEnumerable<Consumable>> GetConsumablesAsync()
        {
            return await dbContext.Consumables
                            .Include(e => e.Item)
                                .ToListAsync();
        }
        #endregion

        #region CREATE
        public async Task<bool> AddConsumableAsync(ConsumableDTO newConsumable)
        {
            Consumable consumable = await dbContext.Consumables
                                            .FirstOrDefaultAsync(e => e.Id == newConsumable.Id);

            consumable ??= newConsumable.ToEntity();

            _ = dbContext.Add(consumable);

            return await SaveChangesAsync();
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateConsumableAsync(ConsumableDTO updatedItem)
        {
            Consumable consumable = await dbContext.Consumables
                                            .Include(e => e.Item)
                                                .FirstOrDefaultAsync(e => e.Id == updatedItem.Id);

            if (consumable is null)
            {
                return await Task.FromResult(false);
            }

            consumable.ToEntity(updatedItem);

            _ = dbContext.Update(consumable);

            return await SaveChangesAsync();
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteConsumableAsync(int id)
        {
            Consumable entry = await dbContext.Consumables
                                        .FirstOrDefaultAsync(e => e.Id == id);

            if (entry is null)
            {
                return false;
            }

            dbContext.Consumables.Remove(entry);

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