using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IConsumableService
    {
        public Task<IEnumerable<ConsumableModel>> GetConsumablesAsync();
        public Task<ConsumableModel> GetConsumableByItemIdAsync(int itemId);
        public Task<ConsumableModel> GetConsumableByItemCodeAsync(string itemCode);
        public Task<IConveyOperationResult> CreateConsumableAsync(ConsumableModel newConsumable);
        public Task<IConveyOperationResult> UpdateConsumableAsync(ConsumableModel updatedConsumable);
        public Task<IConveyOperationResult> DeleteConsumableAsync(int id);
        public Task<IConveyOperationResult> DeleteConsumableAsync(string itemCode);
    }
}
