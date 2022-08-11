using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IConsumableService
    {
        public Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync();
        public Task<ConsumableDTO> GetConsumableByItemIdAsync(int itemId);
        public Task<bool> CreateConsumableAsync(ConsumableDTO newConsumable);
        public Task<bool> UpdateConsumableAsync(ConsumableDTO updatedConsumable);
        public Task<bool> DeleteConsumableAsync(int id);
    }
}
