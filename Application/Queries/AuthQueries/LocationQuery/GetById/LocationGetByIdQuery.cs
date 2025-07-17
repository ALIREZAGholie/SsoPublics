using Application.Dto.LocationDtos;

namespace Application.Queries.AuthQueries.LocationQuery.GetById
{
    public record LocationGetByIdQuery(long Id) : IQuery<LocationDto>;
}
