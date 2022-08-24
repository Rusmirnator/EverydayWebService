﻿using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Data.Interfaces
{
    public interface IManufacturerDataProvider
    {
        public Task<Manufacturer> GetManufacturerByNameAsync(string name);
        public Task<IEnumerable<Manufacturer>> GetManufacturersAsync();
        public Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerDTO newManufacturer);
        public Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerDTO updatedManufacturer);
        public Task<IConveyOperationResult> DeleteManufacturerAsync(int id);
    }
}
