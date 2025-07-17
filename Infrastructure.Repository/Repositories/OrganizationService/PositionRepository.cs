using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.PositionEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.OrganizationService
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
