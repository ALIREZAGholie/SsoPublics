using Domain.UserAgg.RoleEntity;
using Domain.UserAgg.UserRoleEntity;
using Infrastructure.Context.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Context.CustomIdentity
{
    public class CustomRoleStore : RoleStore<Role, EfContext, long, UserRole, RoleClaim>
    {
        public CustomRoleStore(EfContext context, IdentityErrorDescriber describer = null) : base(context, describer) { }
    }

}
