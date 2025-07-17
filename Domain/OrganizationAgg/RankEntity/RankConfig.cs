using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.OrganizationAgg.RankEntity
{
    public class RankConfig : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR Rank_GKey");
        }
    }
}
