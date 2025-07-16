using Application.Dto.SystemErrorDtos;
using Application.IRepositories.ISystemErrorRepositories;
using Mapster;
using Webgostar.Framework.Application.QueryCommandTools;

namespace Application.Queries._SystemErrorQueries.SystemErrorQuery
{
    public record SystemErrorGetByIdQuery(long Id) : IQuery<SystemErrorGetByIdDto>;

    public class SystemErrorGetByIdHandler(ISystemErrorRepository errorRepository) : IQueryHandler<SystemErrorGetByIdQuery, SystemErrorGetByIdDto>
    {
        public async Task<SystemErrorGetByIdDto> Handle(SystemErrorGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await errorRepository.GetByIdAsync(request.Id, cancellationToken);

                var dto = entity.Adapt<SystemErrorGetByIdDto>();

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
