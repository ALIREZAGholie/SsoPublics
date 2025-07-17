using Application.Dto.LocationDtos;
using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AuthQueries.LocationQuery.GetProvince
{
    public class LocationGetProvinceQueryHandler : IQueryHandler<LocationGetProvinceQuery, List<LocationDto>>
    {
        private readonly ILocationRepository _repository;

        public LocationGetProvinceQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LocationDto>> Handle(LocationGetProvinceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Location> locations = _repository.Table()
                    .Include(x => x.LocationType)
                    .Where(x => x.LocationType.GKey == 2);

                List<LocationDto> data = locations.Select(x => new LocationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    LocationTypeId = x.LocationTypeId,
                    Parent = x.Parent,
                    ParentId = x.ParentId
                }).ToList();

                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
