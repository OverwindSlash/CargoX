using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.Controllers;

namespace Pensees.CargoX.Web.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : CargoXControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}