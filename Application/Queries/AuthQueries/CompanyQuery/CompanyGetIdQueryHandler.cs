using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.Queries.AuthQueries.CompanyQuery
{
    public record CompanyGetIdQuery : IQuery<long>;

    public class CompanyGetIdHandler : IQueryHandler<CompanyGetIdQuery, long>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthService _authService;

        public CompanyGetIdHandler(IRoleRepository roleRepository, IAuthService authService)
        {
            _roleRepository = roleRepository;
            _authService = authService;
        }

        public async Task<long> Handle(CompanyGetIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roleId = _authService.GetRoleId();

                var role = await _roleRepository.RoleManager.Roles
                    .Where(x => x.Id == roleId)
                    .Select(x => x.CompanyId)
                    .ToListAsync(cancellationToken);

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
