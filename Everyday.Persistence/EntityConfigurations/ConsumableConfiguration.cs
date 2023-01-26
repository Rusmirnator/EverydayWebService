using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class ConsumableConfiguration : IEntityTypeConfiguration<Consumable>
    {
        public void Configure(EntityTypeBuilder<Consumable> builder)
        {

            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreateDT).HasDefaultValue(DateTime.Now);

            builder.HasOne(d => d.Item)
                .WithMany(p => p.Consumables)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("consumables_itemid_fkey");
        }
    }
}
