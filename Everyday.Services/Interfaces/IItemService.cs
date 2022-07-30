using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemDTO>> GetItemsAsync();
        public Task<ItemDTO> GetItemByIdAsync(int id);
        public Task<bool> CreateItemAsync(ItemDTO newItem);
        public Task<bool> UpdateItemAsync(ItemDTO updatedItem);
        public Task<bool> DeleteItemAsync(int id);
    }
}
