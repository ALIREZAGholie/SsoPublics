using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class ApiMethodTypeConfig : IEntityTypeConfiguration<ApiMethodType>
    {
        public void Configure(EntityTypeBuilder<ApiMethodType> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR ApiMethodType_GKey");
        }
    }
}
