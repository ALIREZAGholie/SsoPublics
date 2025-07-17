using Domain.OrganizationAgg.ConfigOrganizationEntity;
using Domain.OrganizationAgg.SectionEntity;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.IRepositories.IOrganization
{
    public interface IConfigOrganizationRepository : IBaseRepository<ConfigOrganization>
    {
        Task BuildTree(long configOrganizationId);
        Task<string> PrintTree(long configOrganizationId, string result = "", int level = 0);
        Task<Section?> GetSection(long configOrganizationId);
    }
}
