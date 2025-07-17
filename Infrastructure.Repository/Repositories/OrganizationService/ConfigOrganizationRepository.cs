using Application.IRepositories.IOrganization;
using Domain.OrganizationAgg.ConfigOrganizationEntity;
using Domain.OrganizationAgg.SectionEntity;
using Infrastructure.Context.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories.OrganizationService
{
    public class ConfigOrganizationRepository : BaseRepository<ConfigOrganization>, IConfigOrganizationRepository
    {
        public ConfigOrganizationRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }


        public async Task BuildTree(long configOrganizationId)
        {
            var node = await Table().FirstOrDefaultAsync(x => x.Id == configOrganizationId);

            if (node != null)
            {
                node.ConfigOrganizationChildren = Table().Where(co => co.ParentId == node.Id).ToList();

                foreach (var child in node.ConfigOrganizationChildren)
                {
                    await BuildTree(child.Id);
                }
            }
        }

        public async Task<Section?> GetSection(long configOrganizationId)
        {
            var sectionTypeId = 2;
            var node = await Table().FirstOrDefaultAsync(x => x.Id == configOrganizationId);

            if (node == null) return null;

            node.ConfigOrganizationParent = await Table().FirstOrDefaultAsync(co => co.Id == node.ParentId);

            if (node.ConfigOrganizationParent.ConfigOrganizationTypeId != sectionTypeId)
                return await GetSection(node.ParentId.GetValueOrDefault(0));

            var section = await Table()
                .Include(x => x.Section)
                .FirstOrDefaultAsync(co => co.Id == node.ParentId);

            return section.Section;
        }

        public async Task<string> PrintTree(long configOrganizationId, string result = "", int level = 0)
        {
            var node = await Table()
                .Include(x => x.ConfigOrganizationType)
                .Include(x => x.Section)
                .Include(x => x.Position)
                .FirstOrDefaultAsync(x => x.Id == configOrganizationId);

            if (node == null) return result;

            var indent = new string('_', level * 2);  // فاصله برای نمایش سطح‌ها
            var type = node.ConfigOrganizationType.Name;
            var name = node.ConfigOrganizationType.GKey == 1 ? node.Section.Name : node.Position.Name;

            Console.WriteLine($"{indent}- {type}: {name}");

            result += $"{indent}- {type}: {name}";

            foreach (var child in node.ConfigOrganizationChildren)
            {
                result = await PrintTree(child.Id, result, level + 1);
            }

            return result;
        }
    }
}
