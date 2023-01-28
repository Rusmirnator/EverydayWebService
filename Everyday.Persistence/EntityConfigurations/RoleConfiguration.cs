using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
