using Domain.LocationAgg.LocationEntity;

namespace Domain.LocationAgg.LocationTypeEntity
{
    public class LocationType : AggregateRoot
    {

        public string Name { get; private set; } = null!;
        public long GKey { get; private set; }
        public LocationType(string name)
        {
            Name = name;
        }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
