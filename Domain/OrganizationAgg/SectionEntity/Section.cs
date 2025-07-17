using Domain.OrganizationAgg.ConfigOrganizationEntity;

namespace Domain.OrganizationAgg.SectionEntity
{
    /// <summary>
    /// معاونت
    /// </summary>
    public class Section : AggregateRoot
    {
        public Section()
        {

        }

        public string Name { get; private set; }
        public int GKey { get; set; }
        public string? Description { get; private set; }

        public ICollection<ConfigOrganization> ConfigOrganizations { get; set; } = [];

        public Section(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

        public Section Edit(string name, string? description = null)
        {
            Name = name;
            Description = description;
            return this;
        }
    }
}
