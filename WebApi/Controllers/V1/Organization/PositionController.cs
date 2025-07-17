using Application.Dto.OrganizationDtos.PositionDtos;
using Application.Queries.OrganizationQueries.PositionQuery;
using Application.UseCases.OrganizationCases.PositionCase;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels.GridData;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Organization
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
    public class PositionController : ApiController
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public async Task<ApiResult<bool>> Insert(PositionAddCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CommandResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Update")]
        public async Task<ApiResult<bool>> Update(PositionEditCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CommandResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("BindGrid")]
        public async Task<ApiResult<GridData<PositionGetGridDto>>> BindGrid(string Grid = "")
        {
            try
            {
                BaseGrid grid = new();

                grid.Set(Grid);

                var result = await _mediator.Send(new PositionGetGridQuery(grid));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ApiResult<PositionGetGridDto>> GetById(long Id)
        {
            try
            {
                var result = await _mediator.Send(new PositionGetByIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
