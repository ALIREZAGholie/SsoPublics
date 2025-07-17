using Application.Dto.OrganizationDtos.SectionDtos;
using Application.Queries.OrganizationQueries.SectionQuery;
using Application.UseCases.OrganizationCases.SectionCase;
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
    public class SectionController : ApiController
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public async Task<ApiResult<bool>> Insert(SectionAddCommand command)
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
        public async Task<ApiResult<bool>> Update(SectionEditCommand command)
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
        public async Task<ApiResult<GridData<SectionGetGridDto>>> BindGrid(string Grid = "")
        {
            try
            {
                BaseGrid grid = new();

                grid.Set(Grid);

                var result = await _mediator.Send(new SectionGetGridQuery(grid));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ApiResult<SectionGetGridDto>> GetById(long Id)
        {
            try
            {
                var result = await _mediator.Send(new SectionGetByIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetByCompany/{CompanyId}")]
        public async Task<ApiResult<List<SectionGetByCompanyDto>>> GetByCompany(long CompanyId)
        {
            try
            {
                var result = await _mediator.Send(new SectionGetByCompanyQuery(CompanyId));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
