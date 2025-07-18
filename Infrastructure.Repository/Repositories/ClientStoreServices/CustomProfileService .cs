using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserRoleEntity;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Infrastructure.Repository.Repositories.ClientStoreServices
{
    public class CustomProfileService(IUserRepository userRepository) : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await userRepository.Table()
                .Include(x=>x.Roles)
                .FirstOrDefaultAsync(x => x.Id == long.Parse(userId));

            var roles = user.Roles;

            List<Claim> claims =
            [
                new Claim("Id", user.Id.ToString()),
                new Claim("FullName", user.FullName),
                new Claim("UserName", user.UserName),
                new Claim("UserGuid", user.Guid.ToString()),
            ];

            if (roles.Any())
            {
                claims.Add(new Claim("RoleId", roles.First().Id.ToString()));
            }

            JArray rolesClaim = [];

            foreach (var role in roles)
            {
                JObject jObject = new()
                {
                    ["RoleGuid"] = role.Guid,
                    ["RoleId"] = role.Id
                };

                rolesClaim.Add(jObject);
            }

            Claim claimRoles = new("Roles", JsonConvert.SerializeObject(rolesClaim));

            claims.Add(claimRoles);

            context.IssuedClaims.AddRange(claims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true; // یا بررسی کن کاربر غیر فعال نباشه
            return Task.CompletedTask;
        }
    }
}
