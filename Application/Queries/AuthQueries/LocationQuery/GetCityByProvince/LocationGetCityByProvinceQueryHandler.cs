using Application.Dto.LocationDtos;
using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;

namespace Application.Queries.AuthQueries.LocationQuery.GetCityByProvince
{
    public class LocationGetCityByProvinceQueryHandler : IQueryHandler<LocationGetCityByProvinceQuery, List<LocationDto>>
    {
        private readonly ILocationRepository _repository;

        public LocationGetCityByProvinceQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LocationDto>> Handle(LocationGetCityByProvinceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Location> locations = _repository.Table()
                     .Where(x => x.ParentId == request.ProvinceId)
                     .ToList();

                return locations.Adapt<List<LocationDto>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
