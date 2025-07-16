using Application.IRepositories.IAuthRepositories;
using Asp.Versioning;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Auth V1")]
    public class AuthController(IAuthRepository authService) : ApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await authService.RegisterAsync(request);
            if (!result)
                return BadRequest("ثبت نام ناموفق بود");

            return Ok("ثبت نام موفق بود");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await authService.LoginAsync(request);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
