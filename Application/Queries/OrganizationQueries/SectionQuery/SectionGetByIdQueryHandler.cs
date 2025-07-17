using Application.Dto.OrganizationDtos.SectionDtos;
using Application.IRepositories.IOrganization;

namespace Application.Queries.OrganizationQueries.SectionQuery
{
    public record SectionGetByIdQuery(long Id) : IQuery<SectionGetGridDto>;

    public class SectionGetByIdHandler : IQueryHandler<SectionGetByIdQuery, SectionGetGridDto>
    {
        private readonly ISectionRepository _repository;

        public SectionGetByIdHandler(ISectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<SectionGetGridDto> Handle(SectionGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

                return model.Adapt<SectionGetGridDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
