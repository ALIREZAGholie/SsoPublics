using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.OrganizationAgg.ConfigOrganizationEntity
{
    public class ConfigOrganizationTypeConfig : IEntityTypeConfiguration<ConfigOrganizationType>
    {
        public void Configure(EntityTypeBuilder<ConfigOrganizationType> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR ConfigOrganizationType_GKey");
        }
    }
}
