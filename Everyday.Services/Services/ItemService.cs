using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Core.Shared;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class ItemService : IItemService
    {
        #region Fields & Properties
        private readonly IItemDataProvider itemDataProvider;
        private readonly ILogger<ItemService> logger;

        #endregion

        #region CTOR
        public ItemService(IItemDataProvider itemDataProvider, ILogger<ItemService> logger)
        {
            this.itemDataProvider = itemDataProvider;
            this.logger = logger;
        }
        #endregion

        #region READ
        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            try
            {
                Item entry = await itemDataProvider.GetItemByIdAsync(id);

                if (entry is null)
                {
                    return null;
                }
                return new ItemDTO(entry);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ItemDTO> GetItemByCodeAsync(string code)
        {
            try
            {
                Item entry = await itemDataProvider.GetItemByCodeAsync(code);

                if (entry is null)
                {
                    return null;
                }
                return new ItemDTO(entry);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            try
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
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return Enumerable.Empty<ItemDTO>();
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
