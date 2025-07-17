using Domain.CompanyAgg.CompanyEntity;
using Domain.OrganizationAgg.PositionEntity;
using Domain.OrganizationAgg.SectionEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.OrganizationAgg.ConfigOrganizationEntity;

public class ConfigOrganization : AggregateRoot
{
    public ConfigOrganization()
    {

    }

    public long CompanyId { get; private set; }
    public long ConfigOrganizationTypeId { get; private set; }
    public long? ParentId { get; private set; }
    public long? SectionId { get; private set; }
    public long? PositionId { get; private set; }


    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }
    [ForeignKey(nameof(ParentId))]
    public ConfigOrganization ConfigOrganizationParent { get; set; }
    [ForeignKey(nameof(ConfigOrganizationTypeId))]
    public ConfigOrganizationType ConfigOrganizationType { get; set; }
    [ForeignKey(nameof(SectionId))]
    public Section Section { get; set; }
    [ForeignKey(nameof(PositionId))]
    public Position Position { get; set; }
    public ICollection<ConfigOrganization> ConfigOrganizationChildren { get; set; } = [];
    public ICollection<ConfigOrganizationRank> OrganizationRanks { get; set; } = [];


    public ConfigOrganization(long companyId, long configOrganizationTypeId)
    {
        CompanyId = companyId;
        ConfigOrganizationTypeId = configOrganizationTypeId;
    }


}