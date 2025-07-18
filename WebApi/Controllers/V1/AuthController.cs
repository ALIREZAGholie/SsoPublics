using Application.UseCases.AuthCases.AuthCase;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Auth V1")]
    [AllowAnonymous]
    [Route("")]
    public class AuthController(IMediator mediator) : ApiController
    {
        [HttpPost("Register")]
        public async Task<ApiResult<bool>> Register(RegisterUserCommand command)
            => CommandResult(await mediator.Send(command));

        [HttpPost("Login")]
        public async Task<ApiResult<string>> Login(LoginCommand command)
            => CommandResult(await mediator.Send(command));
    }
}
