using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.ItemDefinition)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemDefinitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_itemdefinitionid_fkey");

            builder.HasOne(d => d.Manufacturer)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("items_manufacturerid_fkey");
        }
    }
}
