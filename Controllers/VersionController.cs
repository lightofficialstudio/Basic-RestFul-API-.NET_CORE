using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/versions")]
    [ApiController]
    public class VersionController : ControllerBase
    {
      
        [HttpGet]
        public IActionResult GetVersion()
        {
            var version = "1.0.0";

            var objectData = new {
                version
            };

            return Ok(ApiResponseHelper.Success(objectData));
        }
    }
}