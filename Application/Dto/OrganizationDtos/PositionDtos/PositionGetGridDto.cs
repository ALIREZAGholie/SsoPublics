namespace Application.Dto.OrganizationDtos.PositionDtos
{
    public class PositionGetGridDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
