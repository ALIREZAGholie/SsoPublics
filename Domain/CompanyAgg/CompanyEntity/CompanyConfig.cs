using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.CompanyAgg.CompanyEntity
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasOne(g => g.ParentCompany)
                .WithMany(g => g.SubCompanies)
                .HasForeignKey(g => g.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
