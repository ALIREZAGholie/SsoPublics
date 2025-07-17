using Application.Dto.OrganizationDtos.PositionDtos;
using Application.IRepositories.IOrganization;

namespace Application.Queries.OrganizationQueries.PositionQuery
{
    public record PositionGetByIdQuery(long Id) : IQuery<PositionGetGridDto>;

    public class PositionGetByIdHandler : IQueryHandler<PositionGetByIdQuery, PositionGetGridDto>
    {
        private readonly IPositionRepository _repository;

        public PositionGetByIdHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PositionGetGridDto> Handle(PositionGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

                var result = model.Adapt<PositionGetGridDto>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
