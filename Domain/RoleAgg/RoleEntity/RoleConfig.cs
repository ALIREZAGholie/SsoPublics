using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.RoleAgg.RoleEntity
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(o => o.GKey)
                .HasDefaultValueSql("NEXT VALUE FOR Role_GKey");

            builder.HasOne(r => r.ParentRole)
                .WithMany(r => r.SubRoles)
                .HasForeignKey(r => r.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
