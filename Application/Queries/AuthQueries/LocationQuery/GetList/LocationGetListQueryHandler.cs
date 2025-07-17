using Application.Dto.LocationDtos;
using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;

namespace Application.Queries.AuthQueries.LocationQuery.GetList
{
    public class LocationGetListQueryHandler : IQueryHandler<LocationGetListQuery, List<LocationDto>>
    {
        private readonly ILocationRepository _repository;

        public LocationGetListQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LocationDto>> Handle(LocationGetListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Location> locations = await _repository.GetAll(cancellationToken);

                return locations.Adapt<List<LocationDto>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
