using System;
using Everyday.Core.EntitiesPg;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Data.DataSource
{
    public partial class EverydayContext : DbContext
    {
        public EverydayContext()
        {
        }

        public EverydayContext(DbContextOptions<EverydayContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<Container> Containers { get; set; }
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<DictionaryCategory> DictionaryCategories { get; set; }
        public virtual DbSet<ExistingItem> ExistingItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemDefinition> ItemDefinitions { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql(BuildConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL")), options =>
                    {
                        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Consumables)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("consumables_itemid_fkey");
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Containers)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("containers_itemid_fkey");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Dictionaries)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dict_dictcat_fk_categoryid");
            });

            modelBuilder.Entity<DictionaryCategory>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<ExistingItem>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ExistingItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("existingitems_itemid_fkey");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.ItemDefinition)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("items_itemdefinitionid_fkey");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("items_manufacturerid_fkey");
            });

            modelBuilder.Entity<ItemDefinition>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDT).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static string BuildConnectionString(string databaseUrl)
        {
            if (Uri.TryCreate(databaseUrl, UriKind.Absolute, out Uri url))
            {
                return $"Host={url.Host};Username={url.UserInfo.Split(':')[0]};Password={url.UserInfo.Split(':')[1]};Database={url.LocalPath[1..]};Port={url.Port};sslmode=Require;Trust Server Certificate=true";
            }
            return string.Empty;
        }
    }
}
