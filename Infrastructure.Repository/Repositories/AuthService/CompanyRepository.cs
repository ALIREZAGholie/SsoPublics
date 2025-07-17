using Application.IRepositories.ICompanyRepositories;
using Domain.CompanyAgg.CompanyEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.AuthService
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }

        public async Task<string> GetParents(long parentId, long childId)
        {
            try
            {
                bool noParent = true;
                string parents = "]";
                parents = parents.Insert(0, childId.ToString());
                parents = parents.Insert(0, ",");

                while (noParent)
                {
                    var parent = await GetByIdAsync(parentId);
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
