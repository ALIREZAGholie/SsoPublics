using Webgostar.Framework.Application.QueryCommandTools;

namespace Application.Queries._SystemErrorQueries.SystemErrorQuery
{
    public record SystemErrorGetListQuery() : IQuery<bool>;

    public class SystemErrorGetListHandler() : IQueryHandler<SystemErrorGetListQuery, bool>
    {
        public async Task<bool> Handle(SystemErrorGetListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
