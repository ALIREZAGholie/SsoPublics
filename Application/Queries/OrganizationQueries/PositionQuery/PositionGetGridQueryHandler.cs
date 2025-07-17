using Application.Dto.OrganizationDtos.PositionDtos;
using Application.IRepositories.IOrganization;
using Webgostar.Framework.Base.BaseModels.GridData;

namespace Application.Queries.OrganizationQueries.PositionQuery
{
    public class PositionGetGridQuery : QueryGrid<PositionGetGridDto>
    {
        public PositionGetGridQuery(BaseGrid baseGrid) : base(baseGrid)
        {
        }
    }

    public class PositionGetGridHandler : IQueryGridHandler<PositionGetGridQuery, PositionGetGridDto>
    {
        private readonly IPositionRepository _repository;

        public PositionGetGridHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GridData<PositionGetGridDto>> Handle(PositionGetGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetFilterPagingDto<PositionGetGridDto>(request.BaseGrid, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
