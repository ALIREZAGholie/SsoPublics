using Application.Dto.OrganizationDtos.RankDtos;
using Application.IRepositories.IOrganization;

namespace Application.Queries.OrganizationQueries.RankQuery
{
    public record RankGetByIdQuery(long Id) : IQuery<RankGetGridDto>;

    public class RankGetByIdHandler : IQueryHandler<RankGetByIdQuery, RankGetGridDto>
    {
        private readonly IRankRepository _repository;

        public RankGetByIdHandler(IRankRepository repository)
        {
            _repository = repository;
        }

        public async Task<RankGetGridDto> Handle(RankGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

                return model.Adapt<RankGetGridDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
