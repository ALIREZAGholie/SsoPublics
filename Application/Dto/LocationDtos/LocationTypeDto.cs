namespace Application.Dto.LocationDtos
{
    public class LocationTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GKey { get; set; }

        public List<LocationDto> Locations { get; set; }
    }
}
