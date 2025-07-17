using Application._ApplicationException;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Application.IRepositories.IUserRepositories;
using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.AuthCases
{
    public record RegisterUserCommand(string Username, string Password, string FirstName, string LastName) : ICommand<bool>;

    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userManager;

        public RegisterUserHandler(IUserRepository userManager)
        {
            _userManager = userManager;
        }

        public async Task<OperationResult<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FirstName, request.LastName, request.Username);

                var result = await _userManager.UserManager.CreateAsync(user, request.Password);

                if (result.Succeeded) return OperationResult<bool>.Success(result.Succeeded);
                var error = new StringBuilder();

                foreach (var e in result.Errors)
                {
                    error.AppendLine(e.Description);
                }

                throw new AuthException(error.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
