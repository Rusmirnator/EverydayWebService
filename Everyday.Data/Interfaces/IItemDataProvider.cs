﻿using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IItemDataProvider
    {
        public Task<IEnumerable<Item>> GetItemsAsync();
        public Task<Item> GetItemByIdAsync(int id);
        public Task<Item> GetItemByCodeAsync(string code);
        public Task<IConveyOperationResult> AddItemAsync(ItemDTO newItem);
        public Task<IConveyOperationResult> DeleteItemAsync(int id);
        public Task<IConveyOperationResult> DeleteItemAsync(string code);
        public Task<IConveyOperationResult> UpdateItemAsync(ItemDTO updatedItem);
    }
}
