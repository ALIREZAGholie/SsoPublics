using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Presentation.Web.ControllerTools;

namespace WebApi.Controllers.V1.Auth
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "Form V1")]
    public class FormController : ApiController
    {
        [HttpPost("Add")]
        public async Task<ApiResult<bool>> Add()
        {
            return CommandResult(OperationResult<bool>.Error());
        }
    }
}
