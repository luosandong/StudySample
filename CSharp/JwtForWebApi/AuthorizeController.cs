using ExOrg.Models.ViewModels;
using System.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Security.Claims;
using ExOrg.Filters;

namespace ExOrg.Controllers
{
    public class AuthorizeController : BaseController
    {
        [Route("api/auth/token")]
        [HttpGet]
        [AllowAnonymous]
        public JsonResult<ResultMessage> Token()
        {
            Result = new Models.ViewModels.ResultMessage();
            Result.Data = TokenHelper.GenerateToken("lsd");
            Result.StatusCode = Models.MessageCodeEnum.Success;
            return Json(Result);
        }
    }
}
