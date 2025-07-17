using Application.Dto.CompanyDtos;
using Application.IRepositories.ICompanyRepositories;
using Domain.CompanyAgg.CompanyEntity;

namespace Application.Queries.AuthQueries.CompanyQuery.GetList
{
    public class CompanyGetListQuery : IQuery<List<CompanyDto>>
    {
    }

    public class CompanyGetListQueryHandler : IQueryHandler<CompanyGetListQuery, List<CompanyDto>>
    {
        private readonly ICompanyRepository _repository;


        public CompanyGetListQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyDto>> Handle(CompanyGetListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Company> company = await _repository.GetAll(cancellationToken);

                List<CompanyDto> response = company.Adapt<List<CompanyDto>>();

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
