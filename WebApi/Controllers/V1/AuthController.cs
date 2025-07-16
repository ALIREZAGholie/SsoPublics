using Application.IRepositories.IAuthRepositories;
using Application.UseCases.AuthCases;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
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
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
            => Ok(await mediator.Send(command));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
            => Ok(await mediator.Send(command));
    }
}
