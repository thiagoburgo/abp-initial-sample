using Abp.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Domain.Entities.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
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