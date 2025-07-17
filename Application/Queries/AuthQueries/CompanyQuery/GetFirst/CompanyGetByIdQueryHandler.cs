using Application.Dto.CompanyDtos;
using Application.IRepositories.ICompanyRepositories;

namespace Application.Queries.AuthQueries.CompanyQuery.GetFirst
{
    public record CompanyGetByIdQuery(long Id) : IQuery<CompanyGetByIdDto>;


    public class CompanyGetByIdHandler : IQueryHandler<CompanyGetByIdQuery, CompanyGetByIdDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyGetByIdHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyGetByIdDto> Handle(CompanyGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var position = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);

                return position.Adapt<CompanyGetByIdDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
