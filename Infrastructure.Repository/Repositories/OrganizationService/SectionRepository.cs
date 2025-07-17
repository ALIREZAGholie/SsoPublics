using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.SectionEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.OrganizationService
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
