using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleEntity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository.Repositories.RoleRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleRepository(RoleManager<Role> roleManager)
        {
            RoleManager = roleManager;
        }

        public RoleManager<Role> RoleManager { get; set; }

        public async Task<List<Role>> AddList(List<Role> entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                foreach (Role i in entity)
                {
                    await RoleManager.CreateAsync(i);
                }
                await _unitOfWork.CommitTransactionAsync();

                return entity;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(CancellationToken.None);
                throw;
            }
        }

        public async Task<string> GetParents(string parentId, string childId)
        {
            try
            {
                bool noParent = true;
                string parents = "]";
                parents = parents.Insert(0, childId.ToString());
                parents = parents.Insert(0, ",");

                while (noParent)
                {
                    var parent = await RoleManager.FindByIdAsync(parentId);
                    parents = parents.Insert(0, parent.Id);
                    parentId = parent.ParentId;

                    if (parent.Id == parent.ParentId || parent.ParentId == null)
                    {
                        noParent = false;
                    }
                    else
                    {
                        parents = parents.Insert(0, ",");
                    }
                }

                parents = parents.Insert(0, "[");

                return parents;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
