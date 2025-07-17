using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.LocationRepositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
