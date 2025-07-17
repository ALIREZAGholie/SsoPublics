using Application.Dto.LocationDtos;
using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;


namespace Application.Queries.AuthQueries.LocationQuery.GetById
{
    public class LocationGetByIdQueryHandler : IQueryHandler<LocationGetByIdQuery, LocationDto>
    {
        private readonly ILocationRepository _repository;

        public LocationGetByIdQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<LocationDto> Handle(LocationGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Location? position = await _repository.GetByIdAsync(request.Id, cancellationToken);

                return position.Adapt<LocationDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
