using Microsoft.EntityFrameworkCore;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.Queries.AuthQueries.RoleQuery
{
    public record RoleGetUserRoleIdQuery : IQuery<long>;

    public class RoleGetUserRoleIdHandler : IQueryHandler<RoleGetUserRoleIdQuery, long>
    {
        private readonly IAuthService _authService;
        //private readonly IUserRoleRepository _repository;

        public RoleGetUserRoleIdHandler(IAuthService authService
            //, IUserRoleRepository repository
            )
        {
            _authService = authService;
            //_repository = repository;
        }

        public async Task<long> Handle(RoleGetUserRoleIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var roleId = _authService.GetRoleId();
                //var userId = _authService.GetUserId();

                //var userRole = await _repository.Table()
                //    .Where(x => x.RoleId == roleId && x.UserId == userId)
                //    .Select(x => x.Id)
                //    .ToListAsync(cancellationToken);

                //return !userRole.Any() ? 0 : userRole.FirstOrDefault();

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
