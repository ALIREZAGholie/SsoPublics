namespace Domain.OrganizationAgg.ConfigOrganizationEntity
{
    public class ConfigOrganizationType : AggregateRoot
    {
        public ConfigOrganizationType()
        {

        }

        public string Name { get; set; }
        public int GKey { get; set; }

        public ICollection<ConfigOrganization> ConfigOrganizations { get; set; } = [];

        public ConfigOrganizationType(string name)
        {
            Name = name;
        }
    }
}
