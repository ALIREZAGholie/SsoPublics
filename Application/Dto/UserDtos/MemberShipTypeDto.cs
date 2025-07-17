namespace Application.Dto.UserDtos
{
    public class MemberShipTypeDto : BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
