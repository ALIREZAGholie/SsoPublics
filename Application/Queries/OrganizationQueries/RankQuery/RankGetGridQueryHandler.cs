using Application.Dto.OrganizationDtos.RankDtos;
using Application.IRepositories.IOrganization;
using Webgostar.Framework.Base.BaseModels.GridData;

namespace Application.Queries.OrganizationQueries.RankQuery
{
    public class RankGetGridQuery : QueryGrid<RankGetGridDto>
    {
        public RankGetGridQuery(BaseGrid baseGrid) : base(baseGrid)
        {
        }
    }

    public class RankGetGridHandler : IQueryGridHandler<RankGetGridQuery, RankGetGridDto>
    {
        private readonly IRankRepository _repository;

        public RankGetGridHandler(IRankRepository repository)
        {
            _repository = repository;
        }

        public async Task<GridData<RankGetGridDto>> Handle(RankGetGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetFilterPagingDto<RankGetGridDto>(request.BaseGrid, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
