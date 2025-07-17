using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.RankEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.OrganizationService
{
    public class RankRepository : BaseRepository<Rank>, IRankRepository
    {
        public RankRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
