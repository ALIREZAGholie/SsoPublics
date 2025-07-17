using Application.Dto.UserDtos;
using Application.UseCases.AuthCases.UserCase.Add;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Auth
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ApiResult<bool>> Register(UserAddCommand registerCommand)
        {
            try
            {
                if (User.Identity!.IsAuthenticated)
                {
                    return CommandResult(OperationResult<bool>.Error("شما در حساب خود وارد شده اید"));
                }

                var accessToken = await _mediator.Send(registerCommand);

                //if (accessToken.Data != null)
                //{
                //    Response.Cookies.Append("AccessToken", accessToken.Data,
                //        new CookieOptions
                //        {
                //            Secure = true,
                //            MaxAge = TimeSpan.FromMinutes(int.Parse(_configuration["JwtConfig:ExpireToken"]!)),
                //            SameSite = SameSiteMode.None,
                //            Domain = Request.Host.ToString(),
                //            Path = "/",
                //            //HttpOnly = true
                //        }
                //    );
                //}

                return CommandResult(accessToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("IsLogin")]
        [AllowAnonymous]
        public ApiResult<bool> IsLogin()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return CommandResult(OperationResult<bool>.Success(true));
                }

                return CommandResult(OperationResult<bool>.Success(false));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
