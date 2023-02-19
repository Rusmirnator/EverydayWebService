using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Everyday.Application.Common.Interfaces.DataAccess
{
    public interface IEverydayDbContext
    {
        public DbSet<Consumable> Consumables { get; }
        public DbSet<Container> Containers { get; }
        public DbSet<Dictionary> Dictionaries { get; }
        public DbSet<DictionaryCategory> DictionaryCategories { get; }
        public DbSet<ExistingItem> ExistingItems { get; }
        public DbSet<Item> Items { get; }
        public DbSet<ItemDefinition> ItemDefinitions { get; }
        public DbSet<Manufacturer> Manufacturers { get; }
        public DbSet<MeasureUnit> MeasureUnits { get; }
        public DbSet<Role> Roles { get; }
        public DbSet<User> Users { get; }
        public DbSet<UserRole> UserRoles { get; }

        public Task<IOperationResult> SaveChangesAsync(CancellationToken cancellationRequest = default);
    }
}
