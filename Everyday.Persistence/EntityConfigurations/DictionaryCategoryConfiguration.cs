using Everyday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everyday.Persistence.EntityConfigurations
{
    public class DictionaryCategoryConfiguration : IEntityTypeConfiguration<DictionaryCategory>
    {
        public void Configure(EntityTypeBuilder<DictionaryCategory> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
