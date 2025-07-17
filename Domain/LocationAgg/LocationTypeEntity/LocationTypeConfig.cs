using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.LocationAgg.LocationTypeEntity
{
    public class LocationTypeConfig : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            builder.Property(o => o.GKey)
                    .HasDefaultValueSql("NEXT VALUE FOR LocationType_GKey");
        }
    }
}
