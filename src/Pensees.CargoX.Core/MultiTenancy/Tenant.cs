using Abp.MultiTenancy;
using Pensees.CargoX.Authorization.Users;

namespace Pensees.CargoX.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
