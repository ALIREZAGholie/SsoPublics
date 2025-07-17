namespace Application.Dto.UserRoleDtos
{
    public class UserRoleDto : BaseDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
