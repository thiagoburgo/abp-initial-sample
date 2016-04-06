using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Clintech.ClinApps.Domain.Contracts.Services;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Domain.Impl.Users
{
    public class UserStore : AbpUserStore<Tenant, Role, User>, IUserStore
    {
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
              userRepository,
              userLoginRepository,
              userRoleRepository,
              roleRepository,
              userPermissionSettingRepository,
              unitOfWorkManager)
        {
            
        }
    }
}