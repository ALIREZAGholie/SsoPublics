using Domain.RoleAgg.RoleEntity;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.IRepositories.IRoleRepositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<List<Role>> AddList(List<Role> entity);
        Task<string> GetParents(long? parentId, long childId);
    }
}
