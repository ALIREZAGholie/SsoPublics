using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories.IUserRepositories;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using Newtonsoft.Json;

namespace Infrastructure.Repository.Repositories.ClientStoreServices
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userService;

        public CustomResourceOwnerPasswordValidator(IUserRepository userService)
        {
            _userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userService.ValidateCredentialsAsync(context.UserName, context.Password);

            if (user != null)
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims:
                    [
                        new Claim("sub", user.Id.ToString()),
                        new Claim("name", user.UserName),
                        new Claim("role", JsonConvert.SerializeObject(user.Roles))
                    ]);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid credentials");
            }
        }
    }
}
