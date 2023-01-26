using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class ItemDefinitionConfiguration : IEntityTypeConfiguration<ItemDefinition>
    {
        public void Configure(EntityTypeBuilder<ItemDefinition> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreateDT).HasDefaultValue(DateTime.Now);
        }
    }
}
