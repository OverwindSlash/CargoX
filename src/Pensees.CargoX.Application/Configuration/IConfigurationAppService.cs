using System.Threading.Tasks;
using Pensees.CargoX.Configuration.Dto;

namespace Pensees.CargoX.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
