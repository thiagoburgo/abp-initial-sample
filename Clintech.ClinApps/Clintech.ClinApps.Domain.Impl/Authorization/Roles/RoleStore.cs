using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Clintech.ClinApps.Domain.Contracts.Services;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Domain.Impl.Authorization.Roles
{
    public class RoleStore : AbpRoleStore<Tenant, Role, User>, IRoleStore
    {
        public RoleStore(
            IRepository<Role> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}