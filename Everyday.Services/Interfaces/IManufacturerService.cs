using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Services.Interfaces
{
    public interface IManufacturerService
    {
        public Task<ManufacturerModel> GetManufacturerByNameAsync(string name);
        public Task<IEnumerable<ManufacturerModel>> GetManufacturersAsync();
        public Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerModel newManufacturer);
        public Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerModel updatedManufacturer);
        public Task<IConveyOperationResult> DeleteManufacturerAsync(int id);
    }
}
