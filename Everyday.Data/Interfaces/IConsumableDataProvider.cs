using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IConsumableDataProvider
    {
        public Task<IEnumerable<Consumable>> GetConsumablesAsync();
        public Task<Consumable> GetConsumableByItemIdAsync(int itemId);
        public Task<Consumable> GetConsumableByItemCodeAsync(string itemCode);
        public Task<IConveyOperationResult> AddConsumableAsync(ConsumableModel newConsumable);
        public Task<IConveyOperationResult> UpdateConsumableAsync(ConsumableModel updatedConsumable);
        public Task<IConveyOperationResult> DeleteConsumableAsync(int id);
        public Task<IConveyOperationResult> DeleteConsumableAsync(string itemCode);
    }
}
