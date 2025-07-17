using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationTypeEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.LocationRepositories
{
    public class LocationTypeRepository : BaseRepository<LocationType>, ILocationTypeRepository
    {
        public LocationTypeRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
