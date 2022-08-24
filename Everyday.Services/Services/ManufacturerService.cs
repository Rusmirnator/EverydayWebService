using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Services.Services
{
    public class ManufacturerService : IManufacturerService
    {
        #region Fields & Properties
        private readonly IManufacturerDataProvider dataProvider;
        #endregion

        #region CTOR
        public ManufacturerService(IManufacturerDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        #endregion

        #region READ
        public async Task<ManufacturerDTO> GetManufacturerByNameAsync(string name)
        {
            Manufacturer res = await dataProvider.GetManufacturerByNameAsync(name);

            if (res is null)
            {
                return null;
            }

            return new ManufacturerDTO(res);
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturersAsync()
        {
            IEnumerable<Manufacturer> data = await dataProvider.GetManufacturersAsync();

            if (!data.Any())
            {
                return Enumerable.Empty<ManufacturerDTO>();
            }

            return data.Select(e => new ManufacturerDTO(e));
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerDTO newManufacturer)
        {
            IConveyOperationResult res = await dataProvider.CreateManufacturerAsync(newManufacturer);

            return new ManufacturerDTO(res.Result as Manufacturer);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerDTO updatedManufacturer)
        {
            IConveyOperationResult res = await dataProvider.UpdateManufacturerAsync(updatedManufacturer);

            return new ManufacturerDTO(res.Result as Manufacturer);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteManufacturerAsync(int id)
        {
            IConveyOperationResult res = await dataProvider.DeleteManufacturerAsync(id);

            return new ManufacturerDTO(res.Result as Manufacturer);
        }
        #endregion
    }
}
