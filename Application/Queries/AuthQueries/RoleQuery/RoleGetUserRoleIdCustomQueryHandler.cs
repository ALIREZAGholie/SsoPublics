using Application.IRepositories.IUserRepositories;

namespace Application.Queries.AuthQueries.RoleQuery
{
    public record RoleGetUserRoleIdCustomQuery(string userId, long roleId) : IQuery<long>;

    public class RoleGetUserRoleIdCustomHandler : IQueryHandler<RoleGetUserRoleIdCustomQuery, long>
    {
        private readonly IUserRepository _repository;

        public RoleGetUserRoleIdCustomHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(RoleGetUserRoleIdCustomQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var user = _repository.FindByIdAsync(request.userId);

                //var userRole = await _repository.GetRolesAsync()
                //    .Where(x => x.RoleId == request.roleId && x.UserId == request.userId)
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
