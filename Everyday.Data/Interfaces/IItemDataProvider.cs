using Everyday.Core.EntitiesPg;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IItemDataProvider
    {
        public Task<IEnumerable<Item>> GetItemsAsync();
        public Task<Item> GetItemByIdAsync(int id);
        public Task<bool> AddItemAsync(ItemDTO newItem);
        public Task<bool> DeleteItemAsync(int id);
        public Task<bool> UpdateItemAsync(ItemDTO updatedItem);
    }
}
