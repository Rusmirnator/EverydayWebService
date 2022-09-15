using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Data.DataSource;
using Everyday.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                                .FirstOrDefaultAsync(e => e.Item.Id == itemId);
        }

        public async Task<Consumable> GetConsumableByItemCodeAsync(string itemCode)
        {
            return await dbContext.Consumables
                            .Include(e => e.Item)
                                .FirstOrDefaultAsync(e => e.Item.Code.Equals(itemCode));
        }

        public async Task<IEnumerable<Consumable>> GetConsumablesAsync()
        {
            return await dbContext.Consumables
                            .Include(e => e.Item)
                                .ToListAsync();
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> AddConsumableAsync(ConsumableModel newConsumable)
        {
            Consumable consumable = await dbContext.Consumables
                                            .FirstOrDefaultAsync(e => e.Id == newConsumable.Id);

            Item owner = await dbContext.Items
                                .Include(e => e.Consumables)
                                    .FirstOrDefaultAsync(e => e.Id == newConsumable.ItemId.GetValueOrDefault());

            consumable ??= newConsumable.ToEntity();

            if (owner is null || owner?.Consumables.Any() == true)
            {
                return IConveyOperationResult.Create(-1, "Provided item is null or already has consumable!", owner);
            }

            consumable.Item = owner;
            _ = dbContext.Add(consumable);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, "Consumable created successfuly!", consumable);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateConsumableAsync(ConsumableModel updatedItem)
        {
            Consumable consumable = await dbContext.Consumables
                                            .Include(e => e.Item)
                                                .FirstOrDefaultAsync(e => e.Id == updatedItem.Id);

            if (consumable is null)
            {
                return IConveyOperationResult.Create(-1, "Consumable doesn't exist in database!");
            }

            consumable.Sync(updatedItem);

            _ = dbContext.Update(consumable);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, "Consumable updated successfully!", consumable);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteConsumableAsync(int id)
        {
            Consumable entry = await dbContext.Consumables
                                        .FirstOrDefaultAsync(e => e.Id == id);

            if (entry is null)
            {
                return IConveyOperationResult.Create(-1, $"Consumable with id {id} doesn't exist in databse!");
            }

            dbContext.Consumables.Remove(entry);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, $"{id} has been deleted successfuly!", entry);
        }

        public async Task<IConveyOperationResult> DeleteConsumableAsync(string itemCode)
        {
            Consumable entry = await dbContext.Consumables
                                        .Include(e => e.Item)
                                            .FirstOrDefaultAsync(e => e.Item.Code.Equals(itemCode));
            if (entry is null)
            {
                return IConveyOperationResult.Create(-1, $"Consumable with item code {itemCode} doesn't exist in database!");
            }

            dbContext.Consumables.Remove(entry);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, $"{itemCode}'s consumable has been deleted successfuly!", entry);
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            int result = await dbContext.SaveChangesAsync();

            return result != 0;
        }
    }
}