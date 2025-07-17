using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.OrganizationAgg.ConfigOrganizationEntity
{
    public class ConfigOrganizationConfig : IEntityTypeConfiguration<ConfigOrganization>
    {
        public void Configure(EntityTypeBuilder<ConfigOrganization> builder)
        {
            builder.HasOne(x => x.ConfigOrganizationParent)
                .WithMany(x => x.ConfigOrganizationChildren)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
