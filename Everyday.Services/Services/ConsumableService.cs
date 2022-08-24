using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ConsumableDTO> GetConsumableByItemCodeAsync(string itemCode)
        {
            Consumable entry = await dataProvider.GetConsumableByItemCodeAsync(itemCode);

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
        public async Task<IConveyOperationResult> CreateConsumableAsync(ConsumableDTO newConsumable)
        {
            IConveyOperationResult res = await dataProvider.AddConsumableAsync(newConsumable);

            return new ConsumableDTO(res.Result as Consumable);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateConsumableAsync(ConsumableDTO updatedConsumable)
        {
            IConveyOperationResult res = await dataProvider.UpdateConsumableAsync(updatedConsumable);

            return new ConsumableDTO(res.Result as Consumable);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteConsumableAsync(int id)
        {
            IConveyOperationResult res = await dataProvider.DeleteConsumableAsync(id);

            return new ConsumableDTO(res.Result as Consumable);
        }

        public async Task<IConveyOperationResult> DeleteConsumableAsync(string itemCode)
        {
            IConveyOperationResult res = await dataProvider.DeleteConsumableAsync(itemCode);

            return new ConsumableDTO(res.Result as Consumable);
        }
        #endregion
    }
}
