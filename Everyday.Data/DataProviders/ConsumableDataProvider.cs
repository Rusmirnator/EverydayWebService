using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using Everyday.Data.Interfaces;
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
        public Task<Item> GetConsumableByItemIdAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consumable>> GetConsumablesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CREATE
        public Task<bool> AddConsumableAsync(ConsumableDTO newItem)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UPDATE
        public Task<bool> UpdateConsumableAsync(ConsumableDTO updatedItem)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DELETE
        public Task<bool> DeleteConsumableAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}