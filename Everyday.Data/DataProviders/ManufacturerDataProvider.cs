using Everyday.Core.EntitiesPg;
using Everyday.Core.Interfaces;
using Everyday.Core.Models;
using Everyday.Data.DataSource;
using Everyday.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyday.Data.DataProviders
{
    public class ManufacturerDataProvider : IManufacturerDataProvider
    {
        #region Fields & Properties
        private readonly EverydayContext dbContext;
        #endregion

        #region CTOR
        public ManufacturerDataProvider(EverydayContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region READ
        public async Task<Manufacturer> GetManufacturerByNameAsync(string name)
        {
            return await dbContext.Manufacturers.FirstOrDefaultAsync(e => e.Name.Equals(name));
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersAsync()
        {
            return await dbContext.Manufacturers.ToListAsync();
        }
        #endregion

        #region CREATE
        public async Task<IConveyOperationResult> CreateManufacturerAsync(ManufacturerDTO newManufacturer)
        {
            Manufacturer newEntry = await GetManufacturerByNameAsync(newManufacturer.Name);

            if (newEntry is not null)
            {
                return IConveyOperationResult.Create(1, "Manufacturer with given name already exists!", newEntry);
            }

            newEntry = newManufacturer.ToEntity();

            dbContext.Manufacturers.Add(newEntry);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, "Manufacturer created successfuly!", newEntry);
        }
        #endregion

        #region UPDATE
        public async Task<IConveyOperationResult> UpdateManufacturerAsync(ManufacturerDTO updatedManufacturer)
        {
            Manufacturer existingEntry = await GetManufacturerByNameAsync(updatedManufacturer.Name);

            if (existingEntry is null)
            {
                return IConveyOperationResult.Create(-1, "Manufacturer with given name doesn't exist!");
            }

            existingEntry.Sync(updatedManufacturer);

            dbContext.Manufacturers.Update(existingEntry);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, "Manufacturer updated successfuly!", existingEntry);
        }
        #endregion

        #region DELETE
        public async Task<IConveyOperationResult> DeleteManufacturerAsync(int id)
        {
            Manufacturer existingEntry = await dbContext.Manufacturers.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEntry is null)
            {
                return IConveyOperationResult.Create(-1, "Manufacturer with given name doesn't exist!");
            }

            dbContext.Manufacturers.Remove(existingEntry);

            if (!await SaveChangesAsync())
            {
                return IConveyOperationResult.Create(1, "Couldn't save changes!");
            }

            return IConveyOperationResult.Create(0, "Manufacturer deleted successfuly!", existingEntry);
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            int res = await dbContext.SaveChangesAsync();

            return res > 0;
        }
    }
}
