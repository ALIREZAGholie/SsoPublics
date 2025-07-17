using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.OrganizationAgg.SectionEntity
{
    public class SectionConfig : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR Section_GKey");
        }
    }
}
