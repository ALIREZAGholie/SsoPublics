using Application.IRepositories.IRoleApiPermissionRepositories;
using Domain.ApiEndpointAgg.ApiEndpointEntity;
using Webgostar.Framework.Infrastructure.BaseServices;
using Webgostar.Framework.Infrastructure.BaseServices.IDIContainer;
using Webgostar.Framework.Infrastructure.Contexts;

namespace Infrastructure.Repository.Repositories.RoleApiPermissionRepositories
{
    public class RoleApiPermissionRepository(EfBaseContext context, IRepositoryServices repositoryServices)
        : BaseRepository<RoleApiPermission>(context, repositoryServices), IRoleApiPermissionRepository;
}
