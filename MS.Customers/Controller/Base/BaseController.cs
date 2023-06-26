using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Customer.Domain.Helpers;
using System;
using System.Linq;

namespace MS.Customer.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _log;

        private Guid? AppEstablishmentId;

        public BaseController(ILogger<BaseController> log)
        {
            _log = log;
        }

        public BaseController(ILogger<BaseController> log, IHttpContextAccessor httpContextAccessor)
        {
            _log = log;

            //var appId = httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "establishmentid");

            //if (appId.Key != null && Guid.TryParse(appId.Value, out Guid appEstablishmentId))
            //    AppEstablishmentId = appEstablishmentId;
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (result == null || (ConvertToListHelper.Try(result) && !ConvertToListHelper.Any(result)))
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}