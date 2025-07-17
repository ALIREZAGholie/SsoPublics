namespace Application.Dto.RoleDtos
{
    public class RoleDto : BaseDto
    {
        public long Id { get; set; }
        public string ViewName { get; set; }
        public string RoleName { get; set; }
        public string HeaderName { get; set; }
    }
}
