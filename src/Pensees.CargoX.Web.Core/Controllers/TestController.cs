using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pensees.CargoX.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : CargoXControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Test OK");
        }
    }
}
