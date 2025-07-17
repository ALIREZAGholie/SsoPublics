using Application.IRepositories.IAuthRepositories;
using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;
using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.AuthCases
{
    public record LoginCommand(string Username, string Password) : ICommand<string>;

    public class LoginHandler(
        SignInManager<User> signInManager,
        IUserRepository userManager,
        ITokenService tokenService)
        : ICommandHandler<LoginCommand, string>
    {
        public async Task<OperationResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.UserManager.FindByNameAsync(request.Username);
                if (user == null) return null;

                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!result.Succeeded) return null;

                var token = await tokenService.GenerateTokenAsync(user);
                return string.IsNullOrEmpty(token) ?
                    OperationResult<string>.Error("Token generation failed.") :
                        OperationResult<string>.Success(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
