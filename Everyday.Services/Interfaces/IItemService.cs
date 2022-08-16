using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemDTO>> GetItemsAsync();
        public Task<ItemDTO> GetItemByIdAsync(int id);
        public Task<ItemDTO> GetItemByCodeAsync(string code);
        public Task<IConveyOperationResult> CreateItemAsync(ItemDTO newItem);
        public Task<IConveyOperationResult> UpdateItemAsync(ItemDTO updatedItem);
        public Task<IConveyOperationResult> DeleteItemAsync(int id);
        public Task<IConveyOperationResult> DeleteItemAsync(string code);
    }
}
