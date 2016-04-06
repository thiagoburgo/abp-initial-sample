using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Clintech.ClinApps.Domain.Entities.Authorization;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IRoleStore
    {
        Task CreateAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);
        Task<Role> FindByIdAsync(int roleId);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByDisplayNameAsync(string displayName);
        Task AddPermissionAsync(Role role, PermissionGrantInfo permissionGrant);
        Task RemovePermissionAsync(Role role, PermissionGrantInfo permissionGrant);
        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(Role role);
        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(int roleId);
        Task<bool> HasPermissionAsync(int roleId, PermissionGrantInfo permissionGrant);
        Task RemoveAllPermissionSettingsAsync(Role role);
        void Dispose();
        IQueryable<Role> Roles { get; }
    }
}