using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Clintech.ClinApps.Domain.Entities.Users;
using Microsoft.AspNet.Identity;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IUserStore
    {
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> FindByIdAsync(long userId);
        Task<User> FindByNameAsync(string userName);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByNameOrEmailAsync(string userNameOrEmailAddress);
        Task<User> FindByNameOrEmailAsync(int? tenantId, string userNameOrEmailAddress);
        Task SetPasswordHashAsync(User user, string passwordHash);
        Task<string> GetPasswordHashAsync(User user);
        Task<bool> HasPasswordAsync(User user);
        Task SetEmailAsync(User user, string email);
        Task<string> GetEmailAsync(User user);
        Task<bool> GetEmailConfirmedAsync(User user);
        Task SetEmailConfirmedAsync(User user, bool confirmed);
        Task AddLoginAsync(User user, UserLoginInfo login);
        Task RemoveLoginAsync(User user, UserLoginInfo login);
        Task<IList<UserLoginInfo>> GetLoginsAsync(User user);
        Task<User> FindAsync(UserLoginInfo login);
        Task<List<User>> FindAllAsync(UserLoginInfo login);
        Task<User> FindAsync(int? tenantId, UserLoginInfo login);
        Task AddToRoleAsync(User user, string roleName);
        Task RemoveFromRoleAsync(User user, string roleName);
        Task<IList<string>> GetRolesAsync(User user);
        Task<bool> IsInRoleAsync(User user, string roleName);
        Task AddPermissionAsync(User user, PermissionGrantInfo permissionGrant);
        Task RemovePermissionAsync(User user, PermissionGrantInfo permissionGrant);
        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(long userId);
        Task<bool> HasPermissionAsync(long userId, PermissionGrantInfo permissionGrant);
        Task RemoveAllPermissionSettingsAsync(User user);
        void Dispose();
        IQueryable<User> Users { get; }
    }
}