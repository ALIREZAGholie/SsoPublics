using Application.Dto.FormDtos;

namespace Application.Dto.RoleDtos
{
    public class RoleFormDto : BaseDto
    {
        public long Id { get; set; }
        public long FormId { get; set; }
        public long RoleId { get; set; }

        public RoleDto Role { get; set; }
        public FormDto Form { get; set; }
    }
}
