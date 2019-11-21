using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Pensees.CargoX.Configuration.Dto;

namespace Pensees.CargoX.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CargoXAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
