using Application.Dto.LocationDtos;

namespace Application.Queries.AuthQueries.LocationQuery.GetProvince
{
    public record LocationGetProvinceQuery() : IQuery<List<LocationDto>>;

}