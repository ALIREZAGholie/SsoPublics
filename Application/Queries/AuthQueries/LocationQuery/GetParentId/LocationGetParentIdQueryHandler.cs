using Application.IRepositories.ILocationRepositories;
using Domain.LocationAgg.LocationEntity;

namespace Application.Queries.AuthQueries.LocationQuery.GetParentId
{
    public class LocationGetParentIdQueryHandler : IQueryHandler<LocationGetParentIdQuery, long>
    {
        private readonly ILocationRepository _repository;

        public LocationGetParentIdQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(LocationGetParentIdQuery request, CancellationToken cancellationToken)
        {

            try
            {
                Location? position = await _repository.GetByIdAsync(request.Id, cancellationToken);

                return position.ParentId.GetValueOrDefault(0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
