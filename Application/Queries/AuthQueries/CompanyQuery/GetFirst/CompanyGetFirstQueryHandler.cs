using Application.Dto.CompanyDtos;
using Application.IRepositories.ICompanyRepositories;
using Domain.CompanyAgg.CompanyEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AuthQueries.CompanyQuery.GetFirst
{
    public class CompanyGetFirstQuery : IQuery<CompanyDto>
    {
    }

    public class CompanyGetFirstHandler : IQueryHandler<CompanyGetFirstQuery, CompanyDto>
    {
        private readonly ICompanyRepository _repository;

        public CompanyGetFirstHandler(ICompanyRepository repository)
        {

            _repository = repository;
        }

        public async Task<CompanyDto> Handle(CompanyGetFirstQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Company? response = await _repository.Table().FirstOrDefaultAsync(cancellationToken: cancellationToken);

                return response.Adapt<CompanyDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
