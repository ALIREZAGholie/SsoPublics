using Application.Dto.OrganizationDtos.SectionDtos;
using Application.IRepositories.IOrganization;
using Webgostar.Framework.Base.BaseModels.GridData;

namespace Application.Queries.OrganizationQueries.SectionQuery
{
    public class SectionGetGridQuery : QueryGrid<SectionGetGridDto>
    {
        public SectionGetGridQuery(BaseGrid baseGrid) : base(baseGrid)
        {
        }
    }

    public class SectionGetGridHandler : IQueryGridHandler<SectionGetGridQuery, SectionGetGridDto>
    {
        private readonly ISectionRepository _repository;

        public SectionGetGridHandler(ISectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GridData<SectionGetGridDto>> Handle(SectionGetGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetFilterPagingDto<SectionGetGridDto>(request.BaseGrid, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
