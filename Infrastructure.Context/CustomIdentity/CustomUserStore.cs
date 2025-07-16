using Domain.UserAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Domain.UserAgg.UserRoleEntity;
using Infrastructure.Context.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Context.CustomIdentity
{
    public class CustomUserStore : UserStore<User, Role, EfContext, string, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public CustomUserStore(EfContext context, IdentityErrorDescriber describer = null) : base(context, describer) { }
    }
}
