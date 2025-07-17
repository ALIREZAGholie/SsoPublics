using Application.Dto.UserRoleDtos;

namespace Application.Dto.UserDtos
{
    public class UserDto : BaseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AccessAll { get; set; }
        public bool AccessAllSoldier { get; set; }
        public string MemberShipType { get; set; }

        public ICollection<UserRoleDto>? UserRoles { get; set; }
    }
}
