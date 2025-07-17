using Domain.OrganizationAgg.ConfigOrganizationEntity;

namespace Domain.OrganizationAgg.PositionEntity
{
    /// <summary>
    /// واحد کارکنان
    /// </summary>
    public class Position : AggregateRoot
    {
        public Position()
        {

        }

        public string Name { get; private set; }
        public int GKey { get; set; }
        public string? Description { get; private set; }

        public ICollection<ConfigOrganization> ConfigOrganizations { get; set; } = [];

        public Position(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

        public Position Edit(string name, string? description = null)
        {
            Name = name;
            Description = description;
            return this;
        }
    }
}
