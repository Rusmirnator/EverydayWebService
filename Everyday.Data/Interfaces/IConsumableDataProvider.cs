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
        public Task<Item> GetConsumableByItemIdAsync(int itemId);
        public Task<bool> AddConsumableAsync(ConsumableDTO newItem);
        public Task<bool> UpdateConsumableAsync(ConsumableDTO updatedItem);
        public Task<bool> DeleteConsumableAsync(int id);
    }
}
