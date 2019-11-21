using Abp.Authorization;
using Pensees.CargoX.Authorization.Roles;
using Pensees.CargoX.Authorization.Users;

namespace Pensees.CargoX.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
