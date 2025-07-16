using Application.IRepositories.IAuthRepositories;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Infrastructure.Repository.Repositories.AuthRepositories
{
    public class AuthRepository(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IIdentityServerTokenService tokenService)
        : IAuthRepository
    {
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var user = new User { UserName = request.Email };
            var result = await userManager.CreateAsync(user, request.Password);
            return result.Succeeded;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Email);
            if (user == null) return null;

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded) return null;

            var token = await tokenService.GetTokenAsync(request.Email, request.Password);
            return token;
        }
    }
}
