using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.RoleRepositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleRepository(EfContext context, IRepositoryServices repositoryServices, IUnitOfWork unitOfWork) : base(context, repositoryServices)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Role>> AddList(List<Role> entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                foreach (var i in entity)
                {
                    await Add(i);
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

        public async Task<string> GetParents(long? parentId, long childId)
        {
            try
            {
                var noParent = true;
                var parents = "]";
                parents = parents.Insert(0, childId.ToString());
                parents = parents.Insert(0, ",");

                while (noParent)
                {
                    var parent = await GetByIdAsync(parentId.GetValueOrDefault(0));

                    if (parent is null)
                    {
                        noParent = false;
                        parents = parents.Remove(0, 1);
                        continue;
                    }

                    parents = parents.Insert(0, parent.Id.ToString());
                    parentId = parent.ParentId.GetValueOrDefault(0);

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
