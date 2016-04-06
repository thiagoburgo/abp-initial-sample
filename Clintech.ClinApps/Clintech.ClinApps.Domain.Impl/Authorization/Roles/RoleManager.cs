using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using Clintech.ClinApps.Domain.Contracts.Services;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Domain.Impl.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>, IRoleManager
    {
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager)
        {
        }
    }
}