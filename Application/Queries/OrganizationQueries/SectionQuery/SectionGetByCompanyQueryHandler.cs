using Application.Dto.OrganizationDtos.SectionDtos;
using Application.IRepositories.IOrganization;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.OrganizationQueries.SectionQuery
{
    public record SectionGetByCompanyQuery(long CompanyId) : IQuery<List<SectionGetByCompanyDto>>;

    public class SectionGetByCompanyHandler : IQueryHandler<SectionGetByCompanyQuery, List<SectionGetByCompanyDto>>
    {
        private readonly IConfigOrganizationRepository _configOrganizationRepository;

        public SectionGetByCompanyHandler(IConfigOrganizationRepository configOrganizationRepository)
        {
            _configOrganizationRepository = configOrganizationRepository;
        }

        public async Task<List<SectionGetByCompanyDto>> Handle(SectionGetByCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _configOrganizationRepository.Table()
                    .Include(x => x.Section)
                    .Where(x => x.CompanyId == request.CompanyId).Select(x => x.Section);

                var dto = new List<SectionGetByCompanyDto>();

                query.Adapt(dto);

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
