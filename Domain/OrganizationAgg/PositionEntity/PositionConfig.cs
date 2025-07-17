using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.OrganizationAgg.PositionEntity
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR Position_GKey");
        }
    }
}
