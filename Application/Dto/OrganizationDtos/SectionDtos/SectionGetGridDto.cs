namespace Application.Dto.OrganizationDtos.SectionDtos
{
    public class SectionGetGridDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
