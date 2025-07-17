using Application.Dto.LocationDtos;

namespace Application.Queries.AuthQueries.LocationQuery.GetCity
{
    public record LocationGetCityQuery() : IQuery<List<LocationDto>>;

}