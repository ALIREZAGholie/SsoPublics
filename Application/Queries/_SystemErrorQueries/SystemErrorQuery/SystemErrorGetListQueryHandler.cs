using Application.Dto.SystemErrorDtos;
using Application.IRepositories.ISystemErrorRepositories;
using Mapster;
using Webgostar.Framework.Application.QueryCommandTools;

namespace Application.Queries._SystemErrorQueries.SystemErrorQuery
{
    public record SystemErrorGetListQuery() : IQuery<List<SystemErrorGetListDto>>;

    public class SystemErrorGetListHandler(ISystemErrorRepository errorRepository) : IQueryHandler<SystemErrorGetListQuery, List<SystemErrorGetListDto>>
    {
        public async Task<List<SystemErrorGetListDto>> Handle(SystemErrorGetListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await errorRepository.GetAll(cancellationToken);

                var result = entity.Adapt<List<SystemErrorGetListDto>>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
