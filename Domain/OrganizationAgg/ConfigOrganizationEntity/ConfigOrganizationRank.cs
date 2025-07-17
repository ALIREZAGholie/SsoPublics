using Domain.OrganizationAgg.RankEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.OrganizationAgg.ConfigOrganizationEntity
{
    public class ConfigOrganizationRank : AggregateRoot
    {
        public ConfigOrganizationRank() { }

        public long ConfigOrganizationId { get; private set; }
        public long RankId { get; private set; }


        [ForeignKey(nameof(ConfigOrganizationId))]
        public ConfigOrganization ConfigOrganization { get; set; }
        [ForeignKey(nameof(RankId))]
        public Rank Rank { get; set; }


        public ConfigOrganizationRank(long configOrganizationId, long rankId)
        {
            ConfigOrganizationId = configOrganizationId;
            RankId = rankId;
        }
    }
}
