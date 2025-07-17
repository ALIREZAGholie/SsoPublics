namespace Application.Dto.CompanyDtos
{
    public class CompanyDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
    }
}
