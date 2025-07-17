using Application.Queries.AuthQueries.RoleQuery;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Auth
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ApiController
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<ApiResult<bool>> Add()
        {
            return CommandResult(OperationResult<bool>.Error());
        }

        [HttpGet("GetUserRoleId")]
        public async Task<ApiResult<long>> GetUserRoleId()
        {
            try
            {
                var result = await _mediator.Send(new RoleGetUserRoleIdQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetUserRoleId/{UserId}/{RoleId}")]
        public async Task<ApiResult<long>> GetUserRoleId(string UserId, long RoleId)
        {
            try
            {
                var result = await _mediator.Send(new RoleGetUserRoleIdCustomQuery(UserId, RoleId));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
