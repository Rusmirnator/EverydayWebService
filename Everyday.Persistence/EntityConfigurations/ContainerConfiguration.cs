using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreateDT).HasDefaultValue(DateTime.Now);

            builder.HasOne(d => d.Item)
                .WithMany(p => p.Containers)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("containers_itemid_fkey");
        }
    }
}
