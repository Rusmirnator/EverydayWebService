using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Everyday.Core.Entities
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
        public virtual DbSet<DepletedItem> DepletedItems { get; set; }
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<DictionaryCategory> DictionaryCategories { get; set; }
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
                optionsBuilder.UseNpgsql();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Consumables)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Consumables_Items_Id");
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Containers)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Containers_Items_Id");
            });

            modelBuilder.Entity<DepletedItem>(entity =>
            {
                entity.Property(e => e.DepleteDt)
                    .HasColumnType("datetime")
                    .HasColumnName("DepleteDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepletionReason)
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Dictionaries)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Dictionaries_DictionaryCategories_Id");
            });

            modelBuilder.Entity<DictionaryCategory>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Dictiona__737584F6F36D6186")
                    .IsUnique();

                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemDefinition)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemDefinitionId)
                    .HasConstraintName("FK_Items_ItemDefinitions_Id");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Items_Manufacturers_Id");
            });

            modelBuilder.Entity<ItemDefinition>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreateDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
