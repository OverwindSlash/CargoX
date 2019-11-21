using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Pensees.CargoX.Controllers
{
    public abstract class CargoXControllerBase: AbpController
    {
        protected CargoXControllerBase()
        {
            LocalizationSourceName = CargoXConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
