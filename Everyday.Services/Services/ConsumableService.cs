using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.DataProviders;
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
        public async Task<ConsumableDTO> GetConsumableByItemIdAsync(int itemId)
        {
            Consumable entry = await dataProvider.GetConsumableByItemIdAsync(itemId);

            if (entry is null)
            {
                return null;
            }
            return new ConsumableDTO(entry);
        }

        public async Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync()
        {
            IEnumerable<Consumable> entries = await dataProvider.GetConsumablesAsync();

            if (entries is null)
            {
                return Enumerable.Empty<ConsumableDTO>();
            }

            List<ConsumableDTO> result = new();

            _ = await entries.MapAsync((e) => result.Add(new ConsumableDTO(e)));

            return await Task.FromResult(result);
        }
        #endregion

        #region CREATE
        public async Task<bool> CreateConsumableAsync(ConsumableDTO newConsumable)
        {
            return await dataProvider.AddConsumableAsync(newConsumable);
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateConsumableAsync(ConsumableDTO updatedConsumable)
        {
            return await dataProvider.UpdateConsumableAsync(updatedConsumable);
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteConsumableAsync(int id)
        {
            return await dataProvider.DeleteConsumableAsync(id);
        }
        #endregion
    }
}
