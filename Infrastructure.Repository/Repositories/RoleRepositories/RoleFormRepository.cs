using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleFormEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.RoleRepositories
{
    public class RoleFormRepository : BaseRepository<RoleForm>, IRoleFormRepository
    {
        public RoleFormRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
