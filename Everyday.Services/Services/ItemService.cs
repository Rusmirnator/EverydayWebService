using Everyday.Core.EntitiesPg;
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

        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            IEnumerable<Item> entries = await itemDataProvider.GetItemsAsync();

            if (entries is null)
            {
                return Enumerable.Empty<ItemDTO>();
            }

            List<ItemDTO> result = new();

            _ = await entries.MapAsync((e) => result.Add(new ItemDTO(e)));

            return await Task.FromResult(result);
        }
        #endregion

        #region CREATE
        public async Task<bool> CreateItemAsync(ItemDTO newItem)
        {
            return await itemDataProvider.AddItemAsync(newItem);
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateItemAsync(ItemDTO updatedItem)
        {
            return await itemDataProvider.UpdateItemAsync(updatedItem);
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteItemAsync(int id)
        {
            return await itemDataProvider.DeleteItemAsync(id);
        }
        #endregion
    }
}
