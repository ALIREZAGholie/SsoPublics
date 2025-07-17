using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.ConfigOrganizationEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.OrganizationService
{
    public class ConfigOrganizationRankRepository : BaseRepository<ConfigOrganizationRank>, IConfigOrganizationRankRepository
    {
        public ConfigOrganizationRankRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
