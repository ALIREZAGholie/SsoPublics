using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class ApiEndpointTypeConfig:IEntityTypeConfiguration<ApiEndpointType>
    {
        public void Configure(EntityTypeBuilder<ApiEndpointType> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR ApiEndpointType_GKey");
        }
    }
}
