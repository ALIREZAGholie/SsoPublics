using Application.Dto.CompanyDtos;
using Application.Queries.AuthQueries.CompanyQuery;
using Application.Queries.AuthQueries.CompanyQuery.GetFirst;
using Application.UseCases.AuthCases.CompanyCase.Add;
using Application.UseCases.AuthCases.CompanyCase.Edit;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Auth
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "Company V1")]
    public class CompanyController : ApiController
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResult<bool>> Insert(CompanyAddCommand command)
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

        [HttpPut]
        public async Task<ApiResult<bool>> Update(CompanyEditCommand command)
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

        [HttpGet("BindSingle")]
        public async Task<ApiResult<CompanyDto>> BindSingle()
        {
            try
            {
                var result = await _mediator.Send(new CompanyGetFirstQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCompanyId/{RoleId:long}")]
        public async Task<ApiResult<long>> GetCompanyId(long RoleId)
        {
            try
            {
                var result = await _mediator.Send(new CompanyGetByRoleIdQuery(RoleId));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCompanyId")]
        public async Task<ApiResult<long>> GetCompanyId()
        {
            try
            {
                var result = await _mediator.Send(new CompanyGetIdQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ApiResult<CompanyGetByIdDto>> GetById(long Id)
        {
            try
            {
                var result = await _mediator.Send(new CompanyGetByIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
