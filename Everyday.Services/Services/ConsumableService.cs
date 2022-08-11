using Everyday.Core.Models;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class ConsumableService : IConsumableService
    {
        #region Fields & Properties
        private readonly IConsumableDataProvider dataProvider;
        #endregion

        #region CTOR
        public ConsumableService(IConsumableDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        #endregion

        #region READ
        public Task<ConsumableDTO> GetConsumableByItemIdAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CREATE
        public Task<bool> CreateConsumableAsync(ConsumableDTO newItem)
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
