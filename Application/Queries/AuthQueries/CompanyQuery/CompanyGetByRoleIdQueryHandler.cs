using Application.IRepositories.IRoleRepositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AuthQueries.CompanyQuery
{
    public record CompanyGetByRoleIdQuery(string RoleId) : IQuery<long>;

    public class CompanyGetByRoleIdHandler : IQueryHandler<CompanyGetByRoleIdQuery, long>
    {
        private readonly IRoleRepository _roleRepository;

        public CompanyGetByRoleIdHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<long> Handle(CompanyGetByRoleIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _roleRepository.RoleManager.Roles.Where(x => x.Id == request.RoleId).Select(x => x.CompanyId).ToListAsync(cancellationToken);

                if (!role.Any())
                {
                    return 0;
                }

                var companyId = role.FirstOrDefault();

                return companyId;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
