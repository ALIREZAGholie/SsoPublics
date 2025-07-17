using Application.Dto.LocationDtos;
using Application.Queries.AuthQueries.LocationQuery.GetById;
using Application.Queries.AuthQueries.LocationQuery.GetCity;
using Application.Queries.AuthQueries.LocationQuery.GetCityByProvince;
using Application.Queries.AuthQueries.LocationQuery.GetList;
using Application.Queries.AuthQueries.LocationQuery.GetParentId;
using Application.Queries.AuthQueries.LocationQuery.GetProvince;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Auth
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "Location V1")]
    public class LocationController : ApiController
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ApiResult<LocationDto>> GetById(long Id)
        {
            try
            {
                LocationDto result = await _mediator.Send(new LocationGetByIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetParentId/{Id}")]
        public async Task<ApiResult<long>> GetParentId(long Id)
        {
            try
            {
                long result = await _mediator.Send(new LocationGetParentIdQuery(Id));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetCity")]
        public async Task<ApiResult<List<LocationDto>>> GetCity()
        {
            try
            {
                List<LocationDto> result = await _mediator.Send(new LocationGetCityQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCityByProvince/{ProvinceId}")]
        public async Task<ApiResult<List<LocationDto>>> GetCityByProvince(long ProvinceId)
        {
            try
            {
                List<LocationDto> result = await _mediator.Send(new LocationGetCityByProvinceQuery(ProvinceId));

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetList")]
        public async Task<ApiResult<List<LocationDto>>> GetList()
        {
            try
            {
                List<LocationDto> result = await _mediator.Send(new LocationGetListQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProvince")]
        public async Task<ApiResult<List<LocationDto>?>> GetProvince()
        {
            try
            {
                List<LocationDto> result = await _mediator.Send(new LocationGetProvinceQuery());

                return QueryResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
