using Application.IRepositories.IAuthRepositories;
using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.AuthCases.AuthCase
{
    public record LoginCommand(string Username, string Password) : ICommand<string>;

    public class LoginHandler(
        IIdentityServerTokenService serverTokenService)
        : ICommandHandler<LoginCommand, string>
    {
        public async Task<OperationResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await serverTokenService.GetTokenAsync(request.Username, request.Password);

                return OperationResult<string>.Success(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
