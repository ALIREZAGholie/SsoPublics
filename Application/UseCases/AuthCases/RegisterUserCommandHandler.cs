using System.Text;
using Application._ApplicationException;
using Domain.UserAgg.UserEntity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Webgostar.Framework.Application.QueryCommandTools;
using Webgostar.Framework.Base.BaseModels;

namespace Application.UseCases.AuthCases
{
    public record RegisterUserCommand(string Username, string Password, string FirstName, string LastName) : ICommand<bool>;

    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OperationResult<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FirstName, request.LastName, request.Username);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded) return OperationResult<bool>.Success(result.Succeeded);
                var error = new StringBuilder();

                foreach (var e in result.Errors)
                {
                    error.AppendLine(e.Description);
                }

                throw new AuthException(error.ToString());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
