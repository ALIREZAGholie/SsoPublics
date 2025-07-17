using Application.Dto.CompanyDtos;

namespace Application.Dto.LocationDtos
{
    public class LocationDto : BaseDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public long? LocationTypeId { get; set; }

        public LocationTypeDto? LocationType { get; set; }
        public List<CompanyDto>? Companies { get; set; }
    }
}
