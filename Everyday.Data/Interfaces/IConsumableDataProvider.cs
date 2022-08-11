using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IConsumableDataProvider
    {
        public Task<IEnumerable<Consumable>> GetConsumablesAsync();
        public Task<Consumable> GetConsumableByItemIdAsync(int itemId);
        public Task<bool> AddConsumableAsync(ConsumableDTO newConsumable);
        public Task<bool> UpdateConsumableAsync(ConsumableDTO updatedConsumable);
        public Task<bool> DeleteConsumableAsync(int id);
    }
}
