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
        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            Item entry = await itemDataProvider.GetItemByIdAsync(id);

            if (entry is null)
            {
                return null;
            }
            return new ItemModel(entry);
        }

        public async Task<ItemModel> GetItemByCodeAsync(string code)
        {
            Item entry = await itemDataProvider.GetItemByCodeAsync(code);

            if (entry is null)
            {
                return null;
            }
            return new ItemModel(entry);
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync()
        {
            IEnumerable<Item> entries = await itemDataProvider.GetItemsAsync();

            if (!entries.Any())
            {
                return Enumerable.Empty<ItemModel>();
            }

            return await Task.FromResult(entries.Select(e => new ItemModel(e)));
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> CreateItemAsync(ItemModel newItem)
        {
            IConveyOperationResult response = await itemDataProvider.AddItemAsync(newItem);

            if (response?.Result is not null)
            {
                return new ItemModel(response.Result as Item);
            }

            return response;
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateItemAsync(ItemModel updatedItem)
        {
            IConveyOperationResult response = await itemDataProvider.UpdateItemAsync(updatedItem);

            if (response?.Result is not null)
            {
                return new ItemModel(response.Result as Item);
            }

            return response;
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteItemAsync(int id)
        {
            IConveyOperationResult response = await itemDataProvider.DeleteItemAsync(id);

            if (response?.Result is not null)
            {
                return new ItemModel(response.Result as Item);
            }

            return response;
        }

        public async Task<IConveyOperationResult> DeleteItemAsync(string code)
        {
            IConveyOperationResult response = await itemDataProvider.DeleteItemAsync(code);

            if (response?.Result is not null)
            {
                return new ItemModel(response.Result as Item);
            }

            return response;
        }
        #endregion
    }
}
