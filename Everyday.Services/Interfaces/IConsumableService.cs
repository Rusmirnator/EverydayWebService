using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IConsumableService
    {
        public Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync();
        public Task<ConsumableDTO> GetConsumableByItemIdAsync(int itemId);
        public Task<ConsumableDTO> GetConsumableByItemCodeAsync(string itemCode);
        public Task<IConveyOperationResult> CreateConsumableAsync(ConsumableDTO newConsumable);
        public Task<IConveyOperationResult> UpdateConsumableAsync(ConsumableDTO updatedConsumable);
        public Task<IConveyOperationResult> DeleteConsumableAsync(int id);
        public Task<IConveyOperationResult> DeleteConsumableAsync(string itemCode);
    }
}
