using Application.IRepositories.IUserRepositories;
using Duende.IdentityModel;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Security.Claims;

namespace Infrastructure.Repository.Repositories.ClientStoreServices
{
    public class CustomProfileService : IProfileService
    {
        private readonly IUserRepository _userManager;

        public CustomProfileService(IUserRepository userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.UserManager.FindByIdAsync(context.Subject.GetSubjectId());
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, user.UserName),
            };

            var roles = await _userManager.UserManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(JwtClaimTypes.Role, r)));

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.UserManager.FindByIdAsync(context.Subject.GetSubjectId());
            context.IsActive = user != null;
        }
    }

}
