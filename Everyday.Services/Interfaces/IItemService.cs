using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemModel>> GetItemsAsync();
        public Task<ItemModel> GetItemByIdAsync(int id);
        public Task<ItemModel> GetItemByCodeAsync(string code);
        public Task<IConveyOperationResult> CreateItemAsync(ItemModel newItem);
        public Task<IConveyOperationResult> UpdateItemAsync(ItemModel updatedItem);
        public Task<IConveyOperationResult> DeleteItemAsync(int id);
        public Task<IConveyOperationResult> DeleteItemAsync(string code);
    }
}
