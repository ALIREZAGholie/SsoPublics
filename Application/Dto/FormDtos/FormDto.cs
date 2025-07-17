namespace Application.Dto.FormDtos
{
    public class FormDto : BaseDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long FormTypeId { get; set; }
        public string FormNamePersian { get; set; }
        public string FormUrl { get; set; }
        public string Parent { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
    }
}
