using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Session;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Microsoft.AspNet.Identity;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user);
        Task<bool> IsGrantedAsync(long userId, string permissionName);
        Task<bool> IsGrantedAsync(User user, Permission permission);
        Task<bool> IsGrantedAsync(long userId, Permission permission);
        Task<IReadOnlyList<Permission>> GetGrantedPermissionsAsync(User user);
        Task SetGrantedPermissionsAsync(User user, IEnumerable<Permission> permissions);
        Task ProhibitAllPermissionsAsync(User user);
        Task ResetAllPermissionsAsync(User user);
        Task GrantPermissionAsync(User user, Permission permission);
        Task ProhibitPermissionAsync(User user, Permission permission);
        Task<User> FindByNameOrEmailAsync(string userNameOrEmailAddress);
        Task<List<User>> FindAllAsync(UserLoginInfo login);
        Task<AbpUserManager<Tenant, Role, User>.AbpLoginResult> LoginAsync(UserLoginInfo login, string tenancyName);
        Task<AbpUserManager<Tenant, Role, User>.AbpLoginResult> LoginAsync(string userNameOrEmailAddress, string plainPassword, string tenancyName);
        Task<User> GetUserByIdAsync(long userId);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> DeleteAsync(User user);
        Task<IdentityResult> ChangePasswordAsync(User user, string newPassword);
        Task<IdentityResult> CheckDuplicateUsernameOrEmailAddressAsync(long? expectedUserId, string userName, string emailAddress);
        Task<IdentityResult> SetRoles(User user, string[] roleNames);
        Task<bool> IsInOrganizationUnitAsync(long userId, long ouId);
        Task<bool> IsInOrganizationUnitAsync(User user, OrganizationUnit ou);
        Task AddToOrganizationUnitAsync(long userId, long ouId);
        Task AddToOrganizationUnitAsync(User user, OrganizationUnit ou);
        Task RemoveFromOrganizationUnitAsync(long userId, long ouId);
        Task RemoveFromOrganizationUnitAsync(User user, OrganizationUnit ou);
        Task SetOrganizationUnitsAsync(long userId, params long[] organizationUnitIds);
        Task SetOrganizationUnitsAsync(User user, params long[] organizationUnitIds);
        Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(User user);
        Task<List<User>> GetUsersInOrganizationUnit(OrganizationUnit organizationUnit, bool includeChildren);
        ILocalizationManager LocalizationManager { get; set; }
        IAbpSession AbpSession { get; set; }
        IAuditInfoProvider AuditInfoProvider { get; set; }
        FeatureDependencyContext FeatureDependencyContext { get; set; }
        IPasswordHasher PasswordHasher { get; set; }
        IIdentityValidator<User> UserValidator { get; set; }
        IIdentityValidator<string> PasswordValidator { get; set; }
        IClaimsIdentityFactory<User, long> ClaimsIdentityFactory { get; set; }
        IIdentityMessageService EmailService { get; set; }
        IIdentityMessageService SmsService { get; set; }
        IUserTokenProvider<User, long> UserTokenProvider { get; set; }
        bool UserLockoutEnabledByDefault { get; set; }
        int MaxFailedAccessAttemptsBeforeLockout { get; set; }
        TimeSpan DefaultAccountLockoutTimeSpan { get; set; }
        bool SupportsUserTwoFactor { get; }
        bool SupportsUserPassword { get; }
        bool SupportsUserSecurityStamp { get; }
        bool SupportsUserRole { get; }
        bool SupportsUserLogin { get; }
        bool SupportsUserEmail { get; }
        bool SupportsUserPhoneNumber { get; }
        bool SupportsUserClaim { get; }
        bool SupportsUserLockout { get; }
        bool SupportsQueryableUsers { get; }
        IQueryable<User> Users { get; }
        IDictionary<string, IUserTokenProvider<User, long>> TwoFactorProviders { get; }
        void Dispose();
        Task<User> FindByIdAsync(long userId);
        Task<User> FindByNameAsync(string userName);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<User> FindAsync(string userName, string password);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> HasPasswordAsync(long userId);
        Task<IdentityResult> AddPasswordAsync(long userId, string password);
        Task<IdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
        Task<IdentityResult> RemovePasswordAsync(long userId);
        Task<string> GetSecurityStampAsync(long userId);
        Task<IdentityResult> UpdateSecurityStampAsync(long userId);
        Task<string> GeneratePasswordResetTokenAsync(long userId);
        Task<IdentityResult> ResetPasswordAsync(long userId, string token, string newPassword);
        Task<User> FindAsync(UserLoginInfo login);
        Task<IdentityResult> RemoveLoginAsync(long userId, UserLoginInfo login);
        Task<IdentityResult> AddLoginAsync(long userId, UserLoginInfo login);
        Task<IList<UserLoginInfo>> GetLoginsAsync(long userId);
        Task<IdentityResult> AddClaimAsync(long userId, Claim claim);
        Task<IdentityResult> RemoveClaimAsync(long userId, Claim claim);
        Task<IList<Claim>> GetClaimsAsync(long userId);
        Task<IdentityResult> AddToRoleAsync(long userId, string role);
        Task<IdentityResult> AddToRolesAsync(long userId, params string[] roles);
        Task<IdentityResult> RemoveFromRolesAsync(long userId, params string[] roles);
        Task<IdentityResult> RemoveFromRoleAsync(long userId, string role);
        Task<IList<string>> GetRolesAsync(long userId);
        Task<bool> IsInRoleAsync(long userId, string role);
        Task<string> GetEmailAsync(long userId);
        Task<IdentityResult> SetEmailAsync(long userId, string email);
        Task<User> FindByEmailAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(long userId);
        Task<IdentityResult> ConfirmEmailAsync(long userId, string token);
        Task<bool> IsEmailConfirmedAsync(long userId);
        Task<string> GetPhoneNumberAsync(long userId);
        Task<IdentityResult> SetPhoneNumberAsync(long userId, string phoneNumber);
        Task<IdentityResult> ChangePhoneNumberAsync(long userId, string phoneNumber, string token);
        Task<bool> IsPhoneNumberConfirmedAsync(long userId);
        Task<string> GenerateChangePhoneNumberTokenAsync(long userId, string phoneNumber);
        Task<bool> VerifyChangePhoneNumberTokenAsync(long userId, string token, string phoneNumber);
        Task<bool> VerifyUserTokenAsync(long userId, string purpose, string token);
        Task<string> GenerateUserTokenAsync(string purpose, long userId);
        void RegisterTwoFactorProvider(string twoFactorProvider, IUserTokenProvider<User, long> provider);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(long userId);
        Task<bool> VerifyTwoFactorTokenAsync(long userId, string twoFactorProvider, string token);
        Task<string> GenerateTwoFactorTokenAsync(long userId, string twoFactorProvider);
        Task<IdentityResult> NotifyTwoFactorTokenAsync(long userId, string twoFactorProvider, string token);
        Task<bool> GetTwoFactorEnabledAsync(long userId);
        Task<IdentityResult> SetTwoFactorEnabledAsync(long userId, bool enabled);
        Task SendEmailAsync(long userId, string subject, string body);
        Task SendSmsAsync(long userId, string message);
        Task<bool> IsLockedOutAsync(long userId);
        Task<IdentityResult> SetLockoutEnabledAsync(long userId, bool enabled);
        Task<bool> GetLockoutEnabledAsync(long userId);
        Task<DateTimeOffset> GetLockoutEndDateAsync(long userId);
        Task<IdentityResult> SetLockoutEndDateAsync(long userId, DateTimeOffset lockoutEnd);
        Task<IdentityResult> AccessFailedAsync(long userId);
        Task<IdentityResult> ResetAccessFailedCountAsync(long userId);
        Task<int> GetAccessFailedCountAsync(long userId);
    }
}