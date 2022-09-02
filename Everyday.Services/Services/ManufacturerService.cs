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
        public async Task<ManufacturerModel> GetManufacturerByNameAsync(string name)
        {
            Manufacturer res = await dataProvider.GetManufacturerByNameAsync(name);

            if (res is null)
            {
                return null;
            }

            return new ManufacturerModel(res);
        }

        public async Task<IEnumerable<ManufacturerModel>> GetManufacturersAsync()
        {
            IEnumerable<Manufacturer> data = await dataProvider.GetManufacturersAsync();

            if (!data.Any())
            {
                return Enumerable.Empty<ManufacturerModel>();
            }

            return data.Select(e => new ManufacturerModel(e));
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerModel newManufacturer)
        {
            IConveyOperationResult res = await dataProvider.CreateManufacturerAsync(newManufacturer);

            return new ManufacturerModel(res.Result as Manufacturer);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerModel updatedManufacturer)
        {
            IConveyOperationResult res = await dataProvider.UpdateManufacturerAsync(updatedManufacturer);

            return new ManufacturerModel(res.Result as Manufacturer);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteManufacturerAsync(int id)
        {
            IConveyOperationResult res = await dataProvider.DeleteManufacturerAsync(id);

            return new ManufacturerModel(res.Result as Manufacturer);
        }
        #endregion
    }
}
