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
        public Task<ManufacturerDTO> GetManufacturerByNameAsync(string name);
        public Task<IEnumerable<ManufacturerDTO>> GetManufacturersAsync();
        public Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerDTO newManufacturer);
        public Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerDTO updatedManufacturer);
        public Task<IConveyOperationResult> DeleteManufacturerAsync(int id);
    }
}
