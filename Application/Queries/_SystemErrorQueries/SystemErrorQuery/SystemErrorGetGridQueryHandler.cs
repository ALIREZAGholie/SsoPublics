using Application.Dto.SystemErrorDtos;
using Application.IRepositories.ISystemErrorRepositories;
using Webgostar.Framework.Application.QueryCommandTools;
using Webgostar.Framework.Base.BaseModels.GridData;

namespace Application.Queries._SystemErrorQueries.SystemErrorQuery
{
    public class SystemErrorGetGridQuery(BaseGrid baseGrid) : QueryGrid<SystemErrorGetGridDto>(baseGrid);

    public class SystemErrorGetGridHandler(ISystemErrorRepository errorRepository) : IQueryGridHandler<SystemErrorGetGridQuery, SystemErrorGetGridDto>
    {
        public Task<GridData<SystemErrorGetGridDto>> Handle(SystemErrorGetGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return errorRepository.GetFilterPagingDto<SystemErrorGetGridDto>(request.BaseGrid, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
