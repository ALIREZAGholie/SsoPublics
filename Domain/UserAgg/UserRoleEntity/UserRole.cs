using Domain.UserAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.UserAgg.UserRoleEntity
{
    public class UserRole : IdentityUserRole<string>
    {
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
    }
}
