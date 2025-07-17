using Domain.OrganizationAgg.ConfigOrganizationEntity;

namespace Domain.OrganizationAgg.RankEntity
{
    /// <summary>
    /// واحد سربازان
    /// </summary>
    public class Rank : AggregateRoot
    {
        public Rank()
        {

        }

        public string Name { get; private set; }
        public int GKey { get; set; }
        public string? Description { get; private set; }

        public ICollection<ConfigOrganizationRank> ConfigOrganizationRanks { get; set; } = [];


        public Rank(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

        public Rank Edit(string name, string? description = null)
        {
            Name = name;
            Description = description;
            return this;
        }
    }
}
