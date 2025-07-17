using Domain.CompanyAgg.CompanyEntity;
using Domain.LocationAgg.LocationTypeEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LocationAgg.LocationEntity
{
    public class Location : AggregateRoot
    {
        public Location(long? parentId, string name, string parent)
        {
            ParentId = parentId;
            Name = name;
            Parent = parent;
        }

        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public long? LocationTypeId { get; set; }

        [ForeignKey(nameof(LocationTypeId))]
        public virtual LocationType? LocationType { get; set; }
        public virtual ICollection<Company>? Companies { get; set; }
    }
}
