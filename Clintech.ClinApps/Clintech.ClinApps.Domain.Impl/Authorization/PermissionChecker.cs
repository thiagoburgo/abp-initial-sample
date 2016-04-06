using Abp.Authorization;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Clintech.ClinApps.Domain.Impl.Users;

namespace Clintech.ClinApps.Domain.Impl.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
