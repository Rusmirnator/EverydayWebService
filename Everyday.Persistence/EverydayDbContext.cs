using Everyday.Application.Common.Interfaces.DataAccess;
using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Application.Common.Models;
using Everyday.Domain.Entities;
using Everyday.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Everyday.Persistence
{
    public partial class EverydayDbContext : DbContext, IEverydayDbContext
    {
        #region Fields & Properties
        private readonly ILogger<EverydayDbContext> logger;

        public virtual DbSet<Consumable> Consumables { get; private set; }
        public virtual DbSet<Container> Containers { get; private set; }
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<DictionaryCategory> DictionaryCategories { get; private set; }
        public virtual DbSet<ExistingItem> ExistingItems { get; private set; }
        public virtual DbSet<Item> Items { get; private set; }
        public virtual DbSet<ItemDefinition> ItemDefinitions { get; private set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; private set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; private set; }
        public virtual DbSet<Role> Roles { get; private set; }
        public virtual DbSet<User> Users { get; private set; }
        public virtual DbSet<UserRole> UserRoles { get; private set; }
        #endregion

        #region CTOR
        public EverydayDbContext(DbContextOptions<EverydayDbContext> options, ILogger<EverydayDbContext> logger)
            : base(options)
        {
            this.logger = logger;
        }
        #endregion

        #region Public API
        public async Task<IOperationResult> SaveChangesAsync()
        {
            string message = string.Empty;

            try
            {
                _ = await base.SaveChangesAsync();

                return new OperationResultModel(true, message);
            }
            catch (Exception ex)
            {
                message = ex.Message;

                logger.LogError(message, ex);
            }

            return new OperationResultModel(false, message);
        }
        #endregion

        #region Shared API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Relational:Collation", "en_US.UTF-8")
                .ApplyConfiguration(new ConsumableConfiguration())
                .ApplyConfiguration(new ContainerConfiguration())
                .ApplyConfiguration(new DictionaryConfiguration())
                .ApplyConfiguration(new DictionaryCategoryConfiguration())
                .ApplyConfiguration(new ExistingItemConfiguration())
                .ApplyConfiguration(new ItemConfiguration())
                .ApplyConfiguration(new ItemDefinitionConfiguration())
                .ApplyConfiguration(new ManufacturerConfiguration())
                .ApplyConfiguration(new MeasureUnitConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserRoleConfiguration());
        }
        #endregion
    }
}
