using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Zero.Configuration;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Microsoft.AspNet.Identity;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IRoleManager
    {
        Task<bool> HasPermissionAsync(string roleName, string permissionName);
        Task<bool> HasPermissionAsync(int roleId, string permissionName);
        Task<bool> HasPermissionAsync(Role role, Permission permission);
        Task<bool> HasPermissionAsync(int roleId, Permission permission);
        Task<bool> IsGrantedAsync(string roleName, string permissionName);
        Task<bool> IsGrantedAsync(int roleId, string permissionName);
        Task<bool> IsGrantedAsync(Role role, Permission permission);
        Task<bool> IsGrantedAsync(int roleId, Permission permission);
        Task<IReadOnlyList<Permission>> GetGrantedPermissionsAsync(int roleId);
        Task<IReadOnlyList<Permission>> GetGrantedPermissionsAsync(string roleName);
        Task<IReadOnlyList<Permission>> GetGrantedPermissionsAsync(Role role);
        Task SetGrantedPermissionsAsync(int roleId, IEnumerable<Permission> permissions);
        Task SetGrantedPermissionsAsync(Role role, IEnumerable<Permission> permissions);
        Task GrantPermissionAsync(Role role, Permission permission);
        Task ProhibitPermissionAsync(Role role, Permission permission);
        Task ProhibitAllPermissionsAsync(Role role);
        Task ResetAllPermissionsAsync(Role role);
        Task<IdentityResult> CreateAsync(Role role);
        Task<IdentityResult> UpdateAsync(Role role);
        Task<IdentityResult> DeleteAsync(Role role);
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task GrantAllPermissionsAsync(Role role);
        Task<IdentityResult> CreateStaticRoles(int tenantId);
        Task<IdentityResult> CheckDuplicateRoleNameAsync(int? expectedRoleId, string name, string displayName);
        ILocalizationManager LocalizationManager { get; set; }
        IAbpSession AbpSession { get; set; }
        IRoleManagementConfig RoleManagementConfig { get; }
        IIdentityValidator<Role> RoleValidator { get; set; }
        IQueryable<Role> Roles { get; }
        void Dispose();
        Task<bool> RoleExistsAsync(string roleName);
        Task<Role> FindByIdAsync(int roleId);
        Task<Role> FindByNameAsync(string roleName);
    }
}