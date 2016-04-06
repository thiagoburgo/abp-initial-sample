using Abp.Authorization.Roles;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Domain.Entities.Authorization
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}