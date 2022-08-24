using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class ItemService : IItemService
    {
        #region Fields & Properties
        private readonly IItemDataProvider itemDataProvider;

        #endregion

        #region CTOR
        public ItemService(IItemDataProvider itemDataProvider)
        {
            this.itemDataProvider = itemDataProvider;
        }
        #endregion

        #region READ
        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            Item entry = await itemDataProvider.GetItemByIdAsync(id);

            if (entry is null)
            {
                return null;
            }
            return new ItemDTO(entry);
        }

        public async Task<ItemDTO> GetItemByCodeAsync(string code)
        {
            Item entry = await itemDataProvider.GetItemByCodeAsync(code);

            if (entry is null)
            {
                return null;
            }
            return new ItemDTO(entry);
        }

        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            IEnumerable<Item> entries = await itemDataProvider.GetItemsAsync();

            if (!entries.Any())
            {
                return Enumerable.Empty<ItemDTO>();
            }

            return await Task.FromResult(entries.Select(e => new ItemDTO(e)));
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> CreateItemAsync(ItemDTO newItem)
        {
            IConveyOperationResult response = await itemDataProvider.AddItemAsync(newItem);

            response.Result = new ItemDTO(response.Result as Item);

            return response;
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateItemAsync(ItemDTO updatedItem)
        {
            IConveyOperationResult response = await itemDataProvider.UpdateItemAsync(updatedItem);

            response.Result = new ItemDTO(response.Result as Item);

            return response;
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteItemAsync(int id)
        {
            IConveyOperationResult response = await itemDataProvider.DeleteItemAsync(id);

            response.Result = new ItemDTO(response.Result as Item);

            return response;
        }

        public async Task<IConveyOperationResult> DeleteItemAsync(string code)
        {
            IConveyOperationResult response = await itemDataProvider.DeleteItemAsync(code);

            response.Result = new ItemDTO(response.Result as Item);

            return response;
        }
        #endregion
    }
}
