using Domain.CompanyAgg.CompanyEntity;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.IRepositories.ICompanyRepositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<string> GetParents(long parentId, long childId);
    }
}
