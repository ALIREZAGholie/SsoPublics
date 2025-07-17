using Application.Dto.OrganizationDtos.RankDtos;
using Application.Queries.OrganizationQueries.RankQuery;
using Application.UseCases.OrganizationCases.RankCase;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels.GridData;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Organization
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "Rank V1")]
    public class RankController : ApiController
    {
        private readonly IMediator _mediator;

        public RankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public async Task<ApiResult<bool>> Insert(RankAddCommand command)
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
        public async Task<ApiResult<bool>> Update(RankEditCommand command)
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
        public async Task<ApiResult<GridData<RankGetGridDto>>> BindGrid(string Grid = "")
        {
            try
            {
                BaseGrid grid = new();

                grid.Set(Grid);

                var result = await _mediator.Send(new RankGetGridQuery(grid));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ApiResult<RankGetGridDto>> GetById(long Id)
        {
            try
            {
                var result = await _mediator.Send(new RankGetByIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetForEmployeWorkPlace/{RankId}")]
        public async Task<ApiResult<RankGetForEmployeWorkPlaceDto>> GetForEmployeWorkPlace(long RankId)
        {
            try
            {
                var result = await _mediator.Send(new RankGetForEmployeWorkPlaceQuery(RankId));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetHumanResourcesRank")]
        public async Task<ApiResult<long>> GetHumanResourcesRank()
        {
            try
            {
                var result = await _mediator.Send(new RankGetHumanResourceRankIdQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
