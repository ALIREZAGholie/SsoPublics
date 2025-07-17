using Domain.RoleAgg.RoleEntity;
using Microsoft.AspNetCore.Identity;

namespace Application.IRepositories.IRoleRepositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> AddList(List<Role> entity);
        Task<string> GetParents(string parentId, string childId);
        RoleManager<Role> RoleManager { get; set; }
    }
}
