using Application.Dto.SystemErrorDtos;
using Application.Queries._SystemErrorQueries.SystemErrorQuery;
using Application.UseCases._SystemErrorCases;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels.GridData;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "SystemError V1")]
    public class SystemErrorController(IMediator _mediator) : ApiController
    {
        [HttpGet]
        public async Task<ApiResult<GridData<SystemErrorGetGridDto>>> GetGrid(string Grid = "")
        {
            try
            {
                BaseGrid grid = new();

                grid.Set(Grid);

                var result = await _mediator.Send(new SystemErrorGetGridQuery(grid));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{Id}")]
        public async Task<ApiResult<SystemErrorGetByIdDto>> GetById(long Id)
        {
            try
            {
                var result = await _mediator.Send(new SystemErrorGetByIdQuery(Id));

                return QueryResult(result)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ApiResult<bool>> Insert(SystemErrorAddCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CommandResult(result)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(SystemErrorEditCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CommandResult(result)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}