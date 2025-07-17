namespace Application.Dto.OrganizationDtos.RankDtos
{
    public class RankGetGridDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
