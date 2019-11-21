using Microsoft.AspNetCore.Antiforgery;
using Pensees.CargoX.Controllers;

namespace Pensees.CargoX.Web.Host.Controllers
{
    public class AntiForgeryController : CargoXControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
