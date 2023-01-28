using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class ExistingItemConfiguration : IEntityTypeConfiguration<ExistingItem>
    {
        public void Configure(EntityTypeBuilder<ExistingItem> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);

            builder.HasOne(d => d.Item)
                .WithMany(p => p.ExistingItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("existingitems_itemid_fkey");
        }
    }
}
