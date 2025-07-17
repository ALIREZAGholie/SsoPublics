namespace Application.Dto.OrganizationDtos.RankDtos
{
    public class RankGetForEmployeWorkPlaceDto : BaseDto
    {
        public long SectionId { get; set; }
        public string SectionName { get; set; }
        public long PositionId { get; set; }
        public string PositionName { get; set; }
        public long RankId { get; set; }
        public string RankName { get; set; }
    }
}
