using Application.Dto.LocationDtos;

namespace Application.Queries.AuthQueries.LocationQuery.GetCityByProvince
{
    public record LocationGetCityByProvinceQuery(long ProvinceId) : IQuery<List<LocationDto>>;

}